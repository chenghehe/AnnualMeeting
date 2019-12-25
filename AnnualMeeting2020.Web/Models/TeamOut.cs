using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class TeamOut
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 方队总得数
        /// </summary>
        public double Fraction { get; set; } = 0;
    }
}