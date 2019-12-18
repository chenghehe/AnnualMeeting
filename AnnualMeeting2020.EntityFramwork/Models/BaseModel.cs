using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 描述：BaseModel
    /// 创建时间：2019/11/26 10:11:03
    /// </summary>
    public class BaseModel
    {
        public BaseModel()
        {
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
