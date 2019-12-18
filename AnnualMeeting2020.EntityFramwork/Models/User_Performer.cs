using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 描述：投票表
    /// 创建时间：2019/11/26 10:31:50
    /// </summary>
    public class User_Performer : BaseModel
    {
        /// <summary>
        /// 投票用户
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// 演员表
        /// </summary>
         [ForeignKey("PerformerId")]
        public virtual Performer Performer { get; set; }
        public int PerformerId { get; set; }

    }
}
