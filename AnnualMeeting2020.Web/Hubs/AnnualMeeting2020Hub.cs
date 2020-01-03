using AnnualMeeting2020.Common;
using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AnnualMeeting2020.Web.Hubs
{
    [HubName(nameof(AnnualMeeting2020Hub))]
    public class AnnualMeeting2020Hub : Hub
    {
        private readonly AnnualMeetingContext _db;

        public AnnualMeeting2020Hub(AnnualMeetingContext db)
        {
            _db = db;
        }

        #region 实时推送相关
        //private Barrage _barrage;
        //public AnnualMeeting2020Hub() : this(Barrage.Instance)
        //{

        //}

        //public AnnualMeeting2020Hub(Barrage barrage)
        //{

        //} 
        #endregion

        /// <summary>
        /// 发送弹幕
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="message"></param>
        [HubMethodName(nameof(SendMessage)), Authorize]
        public async Task SendMessage(string message)
        {
            var isMessage = (Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY] == null ? true : Convert.ToBoolean(Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY]));
            if (isMessage == false)     //弹幕开关
            {
                Clients.Client(connectionId: Context.ConnectionId).rest("弹幕功能已关闭！");
                return;
            }
            if (Cache.Instance[AnnualMeeting2020Key.CACHE_SEND_MESSAGE_KEY + Context.User.Identity.Name] != null)
            {
                var cacheDate = Convert.ToDateTime(Cache.Instance[AnnualMeeting2020Key.CACHE_SEND_MESSAGE_KEY + Context.User.Identity.Name]);
                if (cacheDate.AddSeconds(AnnualMeeting2020Key.TIME_INTERVAL) > DateTime.Now)
                {
                    Clients.Client(connectionId: Context.ConnectionId).rest("您的操作太频繁了！");
                    return;
                }
            }
            Cache.Instance[AnnualMeeting2020Key.CACHE_SEND_MESSAGE_KEY + Context.User.Identity.Name] = DateTime.Now;
            var user = _db.User.Find(Convert.ToInt32(Context.User.Identity.Name));
            Clients.All.addMessage(user.UserName, message.MessageFilter());      //前端发送弹幕
            _db.Message.Add(new Message
            {
                User = user,
                UserId = user.Id,
                Text = message,
                UserName = user.UserName,
            });
            await _db.SaveChangesAsync();
            //db.Configuration.ProxyCreationEnabled = false;
            //var messageList = db.Message.AsNoTracking().OrderByDescending(x => x.CreateTime).ToListAsync();
            //Cache.Instance[AnnualMeeting2020Key.CacheMessageKey] = messageList;
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <returns></returns>
        [HubMethodName(nameof(Vote))]
        public async Task Vote(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var idList = ids.Split(',');
                if (idList.Length > 0)
                {
                    try
                    {
                        var currUser = _db.User.Find(Convert.ToInt32(Context.User.Identity.Name));
                        if (currUser.UserType == UserType.普通用户)
                        {
                            var listVote = new List<int>();
                            if (currUser.TicketCount < (idList.Length - 1))
                            {
                                Clients.Client(connectionId: Context.ConnectionId).voteResult("投票失败！票数不足！");
                                return;
                            }
                            foreach (var item in idList)
                            {
                                if (string.IsNullOrEmpty(item))
                                    continue;
                                var itemId = Convert.ToInt32(item);

                                //投票
                                _db.User_Performer.Add(new User_Performer
                                {
                                    UserId = currUser.Id,
                                    PerformerId = itemId
                                });
                                currUser.TicketCount--;

                                //实时推送投票结果页
                                Clients.All.finalVote(itemId, (await _db.User_Performer.CountAsync(x => x.PerformerId == itemId) + 1));

                            }
                            _db.Entry(currUser).State = EntityState.Modified;
                            var result = await _db.SaveChangesAsync();

                            //为当前选手加票数
                            if (Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] != null)
                            {
                                var player = Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] as Performer;

                                //当前票数
                                Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_TICKET_KEY] = await _db.User_Performer.CountAsync(x => x.PerformerId == player.Id);

                                //推送票数
                                Clients.All.currTicketCount(Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_TICKET_KEY]);

                            }

                            if (result > 0)
                            {
                                Clients.Client(connectionId: Context.ConnectionId).voteResult("投票成功！");
                                return;
                            }
                        }
                        else
                        {
                            Clients.Client(connectionId: Context.ConnectionId).voteResult("只有普通用户才能投票！");
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Clients.Client(connectionId: Context.ConnectionId).voteResult("投票失败！" + e.Message);
                        return;
                    }
                    Clients.Client(connectionId: Context.ConnectionId).voteResult("投票失败！");
                    return;
                }
            }
            Clients.Client(connectionId: Context.ConnectionId).voteResult("请先选择！");
        }


        /// <summary>
        /// 切歌
        /// </summary>
        /// <returns></returns>
        [HubMethodName(nameof(Switch))]
        public async Task Switch(int performerId)
        {
            var uid = Convert.ToInt32(Context.User.Identity.Name);
            var curruser = _db.User.Find(uid);
            if (curruser.UserType.HasFlag(UserType.管理员))
            {
                _db.Configuration.LazyLoadingEnabled = false;
                var performer = await _db.Performer.Include(x => x.Team).Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == performerId);
                if (!performer.IdPerform)
                {
                    performer.IdPerform = true;
                    _db.Entry(performer).State = EntityState.Modified;
                    var result = await _db.SaveChangesAsync();
                }

                Refresh();  //刷新评委页面

                Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] = performer;
                Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_TICKET_KEY] = await _db.User_Performer.CountAsync(x => x.PerformerId == performer.Id);

                var userName = string.Empty;
                if (string.IsNullOrEmpty(performer.CombinationName))
                {
                    foreach (var name in performer.Users.Select(x => x.UserName))
                    {
                        userName += name + "|";
                    }
                }
                else
                {
                    userName = performer.CombinationName;
                }
                userName = userName.Trim('|');

                Clients.All.switchCurrent($"{performer.Team.Name}{AnnualMeeting2020Key.SPLIT_CHAR}{userName}{AnnualMeeting2020Key.SPLIT_CHAR}{performer.ProgramName}", Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_TICKET_KEY]);
                Clients.Client(connectionId: Context.ConnectionId).switchResult("切换成功！");
            }
            else
            {
                Clients.Client(connectionId: Context.ConnectionId).switchResult("你没有权限！");
            }
        }


        /// <summary>
        /// 开启弹幕
        /// </summary>
        /// <returns></returns>
        [HubMethodName(nameof(SwitchMessage))]
        public async Task SwitchMessage()
        {
            var isMessage = (Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY] == null ? true : Convert.ToBoolean(Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY]));
            Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY] = !isMessage;
            Clients.Client(connectionId: Context.ConnectionId).switchMessageResult("操作成功！");
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <returns></returns>
        [HubMethodName(nameof(Refresh))]
        public async Task Refresh()
        {
            Clients.All.refresh();      //刷新页面
        }

        ///// <summary>
        ///// 关闭弹幕
        ///// </summary>
        ///// <returns></returns>
        //[HubMethodName(nameof(CloseMessage))]
        //public async Task CloseMessage()
        //{
        //    Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY] = false;
        //    Clients.Client(connectionId: Context.ConnectionId).switchMessageResult("操作成功！");
        //}

        ///// <summary>
        ///// 评委评分
        ///// </summary>
        ///// <returns></returns>
        //[HubMethodName(nameof(Judges))]
        //public async Task Judges(int pid, double fraction)
        //{
        //     
        //    {
        //        var currUser = db.User.Find(Convert.ToInt32(Context.User.Identity.Name));
        //        if (!currUser.UserType.HasFlag(UserType.评委))
        //        {
        //            Clients.Client(connectionId: Context.ConnectionId).voteResult("投票失败！当前账号不是评委！");
        //            return;
        //        }
        //        db.User_Performer.Add(new Judges_Performer
        //        {
        //            UserId = currUser.Id,
        //            PerformerId = itemId
        //        });
        //    }
        //}

        public override Task OnConnected()
        {
            //Clients.Client(connectionId: Context.ConnectionId).connectioned("弹幕连接成功！");
            return base.OnConnected();
        }

    }
}