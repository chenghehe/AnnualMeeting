using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 描述：演员表
    /// 创建时间：2019/11/26 10:10:43
    /// </summary>
    public class Performer : BaseModel
    {
        /// <summary>
        /// 相关表演的人员
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// 节目名称
        /// </summary>
        [MaxLength(50), Required]
        public string ProgramName { get; set; }

        /// <summary>
        /// 组合名
        /// </summary>
        [MaxLength(50)]
        public string CombinationName { get; set; }

        /// <summary>
        /// 是否已经上台
        /// </summary>
        public bool IdPerform { get; set; } = false;

        /// <summary>
        /// 属于哪个队
        /// </summary>
        public virtual Team Team { get; set; }

        /// <summary>
        /// 所属队的ID
        /// </summary>        
        public virtual int TeamId { get; set; }

        /// <summary>
        /// 排序标识
        /// </summary>
        public int? Sort { get; set; }


        /// <summary>
        /// 朋友圈或者微视频点赞数 得分
        /// </summary>
        public double FabulousFraction { get; set; } = 0;

        /// <summary>
        /// 最终得分
        /// </summary>
        public double Score { get; set; } = 0;
    }
}
