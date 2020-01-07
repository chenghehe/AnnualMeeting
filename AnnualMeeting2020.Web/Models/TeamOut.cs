using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class TeamOut
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("方队名称")]
        public string Name { get; set; }

        /// <summary>
        /// 方队总得数
        /// </summary>
        [Description("得分")]
        public double Fraction { get; set; } = 0;
    }
}