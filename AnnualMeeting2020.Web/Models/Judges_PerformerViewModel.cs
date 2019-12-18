using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    /// <summary>
    /// 评分打分
    /// </summary>
    public class Judges_PerformerViewModel
    {
        /// <summary>
        /// 评委
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 团队名
        /// </summary>
        public string TemaName { get; set; }

        /// <summary>
        /// 相关表演的人员名字
        /// </summary>
        public IEnumerable<string> PerformerUserName { get; set; }

        /// <summary>
        /// 节目名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 组合名
        /// </summary>
        public string CombinationName { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public double Fraction { get; set; }

    }
}