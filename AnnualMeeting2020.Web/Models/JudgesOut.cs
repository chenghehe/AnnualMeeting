using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class JudgesOut
    {
        [Description("评委")]
        public string Name { get; set; }

        /// <summary>
        /// 节目名称
        /// </summary>
        [Description("节目名称")]
        public string ProgramName { get; set; }

        /// <summary>
        /// 选手名称，多个选手用|分割
        /// </summary>
        public IEnumerable<string> UserName { get; set; }


        [Description("选手名称")]
        public string UserNames
        {
            get
            {
                var name = string.Empty;
                foreach (var item in UserName)
                {
                    name += item + "|";
                }
                return name.Trim('|');
            }
        }

        /// <summary>
        /// 方块队名
        /// </summary>
        [Description("方队名")]
        public string TeamName { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [Description("分数")]
        public double Fraction { get; set; }

    }
}