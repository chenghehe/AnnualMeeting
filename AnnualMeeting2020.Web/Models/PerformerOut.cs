using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class PerformerOut
    {
        /// <summary>
        /// 表演表id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 节目名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 组合名
        /// </summary>
        public string CombinationName { get; set; }

        /// <summary>
        /// 选手名称，多个选手用|分割
        /// </summary>
        public IEnumerable<string> UserName { get; set; }

        /// <summary>
        /// 是否已投/已评
        /// </summary>
        public bool IsSelect { get; set; }

        /// <summary>
        /// 是否已经上台
        /// </summary>
        public bool IdPerform { get; set; }

        /// <summary>
        /// 方块队名
        /// </summary>
        public string TeamName { get; set; }
    }
}