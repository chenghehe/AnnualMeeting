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
        [MaxLength(15)]
        public string Name { get; set; }
        /// <summary>
        /// 排序标识
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 该队表演者
        /// </summary>
        public ICollection<Performer> Performers { get; set; }
    }
}
