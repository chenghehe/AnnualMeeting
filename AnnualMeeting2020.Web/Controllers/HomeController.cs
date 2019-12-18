using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using AnnualMeeting2020.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AnnualMeetingContext _db;

        public HomeController(AnnualMeetingContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 背景
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Background()
        {
            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var uId = Convert.ToInt32(User.Identity.Name);
            var user = _db.User.Find(uId);
            if (user != null)
            {
                ViewBag.Count = user.TicketCount;
                ViewBag.Surplus = AnnualMeeting2020Key.TICKET_COUNT - user.TicketCount;

                var list = await _db.Performer.GroupJoin(_db.User_Performer, x => new
                {
                    PerformerId = x.Id,
                    UserId = uId
                }, x => new
                {
                    x.PerformerId,
                    x.UserId
                }, (Performer, User_Performer) => new
                {
                    Performer,
                    User_Performer,
                }).SelectMany(x => x.User_Performer.DefaultIfEmpty(), (x, User_Performer) => new
                {
                    x.Performer.Id,
                    x.Performer.ProgramName,
                    x.Performer.Users,
                    x.Performer.IdPerform,
                    x.Performer.CombinationName,
                    TeamName = x.Performer.Team.Name,
                    IsSelect = x.User_Performer.Any(),
                }).Select(x => new PerformerOut
                {
                    Id = x.Id,
                    IsSelect = x.IsSelect,
                    ProgramName = x.ProgramName,
                    CombinationName = x.CombinationName,
                    TeamName = x.TeamName,
                    IdPerform = x.IdPerform,
                    //x.Users,
                    UserName = x.Users.Select(u => u.UserName)
                })/*.GroupJoin(db.User_Performer, x => x.Id)*/
                .ToListAsync();

                //var list = await db.Performer.Include(x => x.Users).AsNoTracking().ToListAsync(cancellationToken);
                //var result = list.Select(x =>
                //{
                //    var name = string.Empty;
                //    foreach (var item in x.Users)
                //    {
                //        name += item.UserName + "|";
                //    }
                //    name = name.Trim('|') + (x.IsSelect ? " (已投)" : "");
                //    return new PerformerOut
                //    {
                //        Id = x.Id,
                //        ProgramName = x.ProgramName,
                //        UserName = name,
                //        IsSelect = x.IsSelect,
                //        IdPerform = x.IdPerform,
                //        TeamName = x.TeamName
                //    };
                //});
                return View(list);
            }
            else
            {
                return Redirect(Url.Action("Index", "Account"));
            }
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Vote(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var idList = ids.Split(',');
                if (idList.Length > 0)
                {
                    var currUId = Convert.ToInt32(User.Identity.Name);
                    foreach (var item in idList)
                    {
                        var itemId = Convert.ToInt32(item);
                        _db.User_Performer.Add(new User_Performer
                        {
                            UserId = currUId,
                            PerformerId = itemId
                        });
                    }
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                        return Json(new
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,
                            Result = "投票成功！"
                        });
                }
            }
            return Json(new
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Result = "请先选择！"
            });
        }

        /// <summary>
        /// 弹幕互动
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            return View();
        }

        /// <summary>
        /// 发送弹幕
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<bool> Send(string text)
        {
            try
            {
                var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
                _db.Message.Add(new Message
                {
                    Text = text,
                    UserId = uid,
                });
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}