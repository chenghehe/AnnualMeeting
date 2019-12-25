using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class RankingOut
    {
        /// <summary>
        /// 选手
        /// </summary>
        public List<PerformerOut> Performers { get; set; }

        /// <summary>
        /// 方队
        /// </summary>
        public List<TeamOut> Teams { get; set; }
    }
}