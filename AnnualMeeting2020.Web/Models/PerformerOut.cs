using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnnualMeeting2020.Web.Models
{
    public class PerformerOut
    {
        /// <summary>
        /// 排序标识
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 表演表id
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
        /// 选手名称，多个选手用|分割
        /// </summary>
        public IEnumerable<string> UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
        /// 是否已投/已评
        /// </summary>
        public bool IsSelect { get; set; }

        /// <summary>
        /// 是否已经上台
        /// </summary>
        //[Description("是否已经上台")]
        public bool IdPerform { get; set; }

        /// <summary>
        /// 方块名
        /// </summary>
        [Description("方块名")]
        public string TeamName { get; set; }


        /// <summary>
        /// 最终得分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Description("最终得分")]
        public string ScoreStr => Score.ToString("F2");
    }
}