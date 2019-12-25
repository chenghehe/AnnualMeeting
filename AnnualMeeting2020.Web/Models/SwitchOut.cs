using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class SwitchOut
    {
        /// <summary>
        /// 节目名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 是否已经上台
        /// </summary>
        public bool IdPerform { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public IEnumerable<string> UserName { get; set; }

        /// <summary>
        /// 方块队名
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// 组合名字
        /// </summary>
        public string CombinationName { get; set; }

        /// <summary>
        /// 团队id
        /// </summary>
        public int TeamId { get; set; }

    }
}