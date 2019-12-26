using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 功能描述: <功能描述>
    /// 创建时间: 2019/12/7 14:34:13
    /// <see cref="Team" langword="" />
    /// </summary>
    public class Team : BaseModel
    {
        [Required, MaxLength(15)]
        public string Name { get; set; }
        /// <summary>
        /// 排序标识
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 方队总得数
        /// </summary>
        public double Fraction { get; set; } = 0;

        /// <summary>
        /// 我想和你唱 环节得分
        /// </summary>        
        public double YouAndMeSing { get; set; } = 0;

        /// <summary>
        /// 互动得分
        /// </summary>
        public double Interaction { get; set; } = 0;

        /// <summary>
        /// 初赛分数
        /// </summary>
        public double Preliminaries { get; set; }

        /// <summary>
        /// 是否已经额外加分
        /// </summary>
        public bool IsAdditionalFraction { get; set; } = false;

        /// <summary>
        /// 该队表演者
        /// </summary>
        public ICollection<Performer> Performers { get; set; }
    }
}
