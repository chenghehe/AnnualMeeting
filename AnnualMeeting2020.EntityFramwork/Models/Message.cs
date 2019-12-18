using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 描述：弹幕
    /// 创建时间：2019/12/3 10:10:20
    /// </summary>
    public class Message : BaseModel
    {
        /// <summary>
        /// 消息文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 发送的用户
        /// </summary>
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
    }
}
