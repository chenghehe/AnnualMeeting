using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 功能描述: 比赛结果，评分结果
    /// 创建时间: 2019/12/9 11:42:58
    /// <see cref="MatchResult" langword="" />
    /// </summary>
    public class MatchResult : BaseModel
    {
        /// <summary>
        /// 得分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 选手
        /// </summary>
        public virtual Performer Performer { get; set; }
        public int PerformerId { get; set; }

    }
}
