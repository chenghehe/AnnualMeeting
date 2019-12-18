using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork.Models
{
    /// <summary>
    /// 功能描述: 用户类型
    /// 创建时间: 2019/12/9 15:51:05
    /// <see cref="UserType" langword="" />
    /// </summary>
    [Flags]
    public enum UserType
    {
        普通用户 = 1,
        评委 = 1 << 1,
        管理员 = 1 << 2,
    }
}
