using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class PerformerTicketResultOut
    {
        /// <summary>
        /// 演员表id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 节目名称
        /// </summary>
        [Description("节目名称")]
        public string ProgramName { get; set; }

        /// <summary>
        /// 组合名
        /// </summary>
        [Description("组合名")]
        public string CombinationName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 队名
        /// </summary>
        [Description("方队名")]
        public string TeamName { get; set; }

        /// <summary>
        /// 所属队的ID
        /// </summary>        
        public int TeamId { get; set; }

        /// <summary>
        /// 票数
        /// </summary>
        [Description("票数")]
        public int Count { get; set; }

        /// <summary>
        /// 排序标识
        /// </summary>
        public int Sort { get; set; }
    }
}