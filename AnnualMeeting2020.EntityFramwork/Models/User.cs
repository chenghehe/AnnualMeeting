using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 描述：用户表
    /// 创建时间：2019/11/26 9:51:15
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// 名字
        /// </summary>
        [Required, MaxLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required, MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 票数
        /// </summary>        
        public int TicketCount { get; set; } = 7;

        /// <summary>
        /// 用户身份
        /// </summary>
        public UserType UserType { get; set; } = UserType.普通用户;

        /// <summary>
        /// 身份
        /// </summary>
        [NotMapped]
        public string Type => UserType.ToString();
    }
}
