using AnnualMeeting2020.Common;
using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;

namespace AnnualMeeting2020.Web.Hubs
{
    /// <summary>
    /// 弹幕相关
    /// </summary>
    public class Barrage
    {
        private readonly static Lazy<Barrage> _instance =
            new Lazy<Barrage>(() => new Barrage());

        private readonly IHubContext _hubContext;

        private Timer _broadcastLoop;

        /// <summary>
        /// 时间
        /// </summary>
        private int time = 1000;

        public Barrage()
        {
            //i = 0;
            //// 获取所有连接的句柄，方便后面进行消息广播
            //_hubContext = GlobalHost.ConnectionManager.GetHubContext<AnnualMeeting2020Hub>();
            //// Start the broadcast loop
            //_broadcastLoop = new Timer(
            //    BroadcastShape,
            //    null,
            //    time,
            //    time);
        }

        private static int i;

        private async void BroadcastShape(object state)
        {
            // 定期执行的方法
            var message = Cache.Instance[AnnualMeeting2020Key.CACHE_MESSAGE_KEY] as List<Message>;
            if (message == default)
            {
                using (AnnualMeetingContext db = new AnnualMeetingContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    message = await db.Message.AsNoTracking().ToListAsync();
                    db.Dispose();
                    Cache.Instance[AnnualMeeting2020Key.CACHE_MESSAGE_KEY] = message;
                }
            }
            _hubContext.Clients.All.getMessage(message);
        }

        public static Barrage Instance => _instance.Value;
    }
}