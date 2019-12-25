using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.Common
{
    /// <summary>
    /// 功能描述: <功能描述>
    /// 创建时间: 2019/12/25 14:40:39
    /// <see cref="NumberHelper" langword="" />
    /// </summary>
    public class NumberHelper
    {

        /// <summary>
        /// 中文数字转数字
        /// </summary>
        /// <param name="chineseStr1"></param>
        /// <returns></returns>
        public static string ChineseTONumber(string chineseStr1)
        {
            string numStr = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c = chineseStr1.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = chineseStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = numStr.ToCharArray()[index];
            }
            return new string(c);
        }

        /// <summary>
        /// 数字转中文数字
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns></returns>
        public static string NumberToChinese(string numberStr)
        {
            string numStr = "0123456789";
            string chineseStr = "零一二三四五六七八九";
            char[] c = numberStr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                int index = numStr.IndexOf(c[i]);
                if (index != -1)
                    c[i] = chineseStr.ToCharArray()[index];
            }
            return new string(c);
        }
    }
}
