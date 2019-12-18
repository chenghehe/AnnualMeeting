using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class JudgesViewModel
    {
        /// <summary>
        /// 节目名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 选手名称，多个选手用|分割
        /// </summary>
        public IEnumerable<string> UserName { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public double Fraction { get; set; }

        /// <summary>
        /// 方块队名
        /// </summary>
        public string TeamName { get; set; }
    }
}