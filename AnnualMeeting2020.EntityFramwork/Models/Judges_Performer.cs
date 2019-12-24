using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        ///// <summary>
        ///// 总分数
        ///// </summary>
        //[NotMapped]
        //public double Fraction => (Feeling + Pronounce + Intonation + Performance + Progress);

        /// <summary>
        /// 感情分数
        /// </summary>
        public double Feeling { get; set; }

        /// <summary>
        /// 咬字分数
        /// </summary>
        public double Pronounce { get; set; }

        /// <summary>
        /// 音准节奏分数
        /// </summary>
        public double Intonation { get; set; }

        /// <summary>
        /// 舞台表现分数
        /// </summary>
        public double Performance { get; set; }

        /// <summary>
        /// 完成度分数
        /// </summary>
        public double Progress { get; set; }
    }
}
