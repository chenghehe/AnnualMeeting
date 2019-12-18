using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 功能描述: 评委评分
    /// 创建时间: 2019/12/9 11:45:26
    /// <see cref="Judges_Performer" langword="" />
    /// </summary>
    public class Judges_Performer : BaseModel
    {
        /// <summary>
        /// 选手
        /// </summary>
        public virtual Performer Performer { get; set; }
        public virtual int PerformerId { get; set; }

        /// <summary>
        /// 评委
        /// </summary>
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public double Fraction { get; set; }
    }
}
