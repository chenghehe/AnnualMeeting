using AnnualMeeting2020.EntityFramwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.EntityFramwork
{
    /// <summary>
    /// 功能描述: <功能描述>
    /// 创建时间: 2019/12/26 10:48:21
    /// <see cref="InitData" langword="" />
    /// </summary>
    public class InitData
    {
        public void Send(AnnualMeetingContext context)
        {
            //管理员
            context.User.Add(new User
            {
                UserName = "admin",
                Phone = "adminjjck",
                UserType = UserType.管理员,
            });

            #region 评委
            for (int i = 1; i < 5; i++)
            {
                context.User.Add(new User
                {
                    UserName = "评委" + i,
                    Phone = "jjck" + i,
                    UserType = UserType.评委,
                });
            }
            #endregion

            #region 普通用户
            var 曾章泉 = context.User.Add(new User { UserName = "曾章泉", Phone = "18978849681" });
            var 陈晓鹏 = context.User.Add(new User { UserName = "陈晓鹏", Phone = "13317716804" });
            var 程军达 = context.User.Add(new User { UserName = "程军达", Phone = "18577616940" });
            var 何国瑞 = context.User.Add(new User { UserName = "何国瑞", Phone = "19163610892" });
            var 苏论 = context.User.Add(new User { UserName = "苏论", Phone = "18775370773" });
            var 张珈铨 = context.User.Add(new User { UserName = "张珈铨", Phone = "18518746986" });
            var 张荣彪 = context.User.Add(new User { UserName = "张荣彪", Phone = "18076549077" });
            var 周治欢 = context.User.Add(new User { UserName = "周治欢", Phone = "13657715018" });
            var 黄春娜 = context.User.Add(new User { UserName = "黄春娜", Phone = "15078866065" });
            var 韦云 = context.User.Add(new User { UserName = "韦云", Phone = "13737033277" });
            var 谢飞 = context.User.Add(new User { UserName = "谢飞", Phone = "13657718614" });
            var 丁薇 = context.User.Add(new User { UserName = "丁薇", Phone = "18777116231" });
            var 黄秋萍 = context.User.Add(new User { UserName = "黄秋萍", Phone = "18076361230" });
            var 余颖颖 = context.User.Add(new User { UserName = "余颖颖", Phone = "15078853064" });
            var 周壁宜 = context.User.Add(new User { UserName = "周壁宜", Phone = "13207718925" });
            var 蔡敏 = context.User.Add(new User { UserName = "蔡敏", Phone = "13877135802" });
            var 罗国华 = context.User.Add(new User { UserName = "罗国华", Phone = "13978749700" });
            var 覃如霞 = context.User.Add(new User { UserName = "覃如霞", Phone = "15289640753" });
            var 肖韬 = context.User.Add(new User { UserName = "肖韬", Phone = "13807715636" });
            var 杜靖 = context.User.Add(new User { UserName = "杜靖", Phone = "13807717573" });
            var 黄家平 = context.User.Add(new User { UserName = "黄家平", Phone = "13077770114" });
            var 梁倩 = context.User.Add(new User { UserName = "梁倩", Phone = "13768883147" });
            var 陈秋锦 = context.User.Add(new User { UserName = "陈秋锦", Phone = "19966725050" });
            var 陈雪莹 = context.User.Add(new User { UserName = "陈雪莹", Phone = "18666035604" });
            var 邓思敏 = context.User.Add(new User { UserName = "邓思敏", Phone = "18376004427" });
            var 邓雄文 = context.User.Add(new User { UserName = "邓雄文", Phone = "18897799077" });
            var 甘飞现 = context.User.Add(new User { UserName = "甘飞现", Phone = "15077197608" });
            var 李帅伦 = context.User.Add(new User { UserName = "李帅伦", Phone = "18877104078" });
            var 覃远阳 = context.User.Add(new User { UserName = "覃远阳", Phone = "15507717782" });
            var 曾皓 = context.User.Add(new User { UserName = "曾皓", Phone = "15994359908" });
            var 甘琦琦 = context.User.Add(new User { UserName = "甘琦琦", Phone = "18378848523" });
            var 黄园园 = context.User.Add(new User { UserName = "黄园园", Phone = "18607713392" });
            var 林冠杰 = context.User.Add(new User { UserName = "林冠杰", Phone = "15577095786" });
            var 罗艳红 = context.User.Add(new User { UserName = "罗艳红", Phone = "15240684467" });
            var 杨彩云 = context.User.Add(new User { UserName = "杨彩云", Phone = "18648809914" });
            var 张睿容 = context.User.Add(new User { UserName = "张睿容", Phone = "18074933101" });
            var 黄小荷 = context.User.Add(new User { UserName = "黄小荷", Phone = "13977196159" });
            var 韦小萍 = context.User.Add(new User { UserName = "韦小萍", Phone = "13457122618" });
            var 严易媛 = context.User.Add(new User { UserName = "严易媛", Phone = "18275895182" });
            var 何姗 = context.User.Add(new User { UserName = "何姗", Phone = "18269066987" });
            var 张南骁 = context.User.Add(new User { UserName = "张南骁", Phone = "13097716213" });
            var 戴鬲森 = context.User.Add(new User { UserName = "戴鬲森", Phone = "18978862395" });
            var 苏河 = context.User.Add(new User { UserName = "苏河", Phone = "15818633219" });
            var 赵秋娥 = context.User.Add(new User { UserName = "赵秋娥", Phone = "13737079491" });
            var 李鑫钰 = context.User.Add(new User { UserName = "李鑫钰", Phone = "13481073757" });
            var 陈玉兰 = context.User.Add(new User { UserName = "陈玉兰", Phone = "13878167171" });
            var 曾冰艺 = context.User.Add(new User { UserName = "曾冰艺", Phone = "18978859088" });
            var 方炳安 = context.User.Add(new User { UserName = "方炳安", Phone = "15977784077" });
            var 何凤梅 = context.User.Add(new User { UserName = "何凤梅", Phone = "15307809344" });
            var 黄仕琴 = context.User.Add(new User { UserName = "黄仕琴", Phone = "18277125367" });
            var 蓝建连 = context.User.Add(new User { UserName = "蓝建连", Phone = "15277137155" });
            var 刘爱群 = context.User.Add(new User { UserName = "刘爱群", Phone = "13807812367" });
            var 彭香连 = context.User.Add(new User { UserName = "彭香连", Phone = "18277367380" });
            var 何少军 = context.User.Add(new User { UserName = "何少军", Phone = "13607862572" });
            var 黄会刚 = context.User.Add(new User { UserName = "黄会刚", Phone = "13878183224" });
            var 梁海 = context.User.Add(new User { UserName = "梁海", Phone = "13807811805" });
            var 陆敬庄 = context.User.Add(new User { UserName = "陆敬庄", Phone = "13978807212" });
            var 梁科 = context.User.Add(new User { UserName = "梁科", Phone = "15277133150" });
            var 周存进 = context.User.Add(new User { UserName = "周存进", Phone = "13557310748" });
            var 梁凤誉 = context.User.Add(new User { UserName = "梁凤誉", Phone = "15177125039" });
            var 刘金丽 = context.User.Add(new User { UserName = "刘金丽", Phone = "18776940920" });
            var 卢晓新 = context.User.Add(new User { UserName = "卢晓新", Phone = "13207808327" });
            var 黄春英 = context.User.Add(new User { UserName = "黄春英", Phone = "18377125052" });
            var 周婷 = context.User.Add(new User { UserName = "周婷", Phone = "13471967507" });
            var 蔡信国 = context.User.Add(new User { UserName = "蔡信国", Phone = "18697904005" });
            var 蒙永露 = context.User.Add(new User { UserName = "蒙永露", Phone = "17376377767" });
            var 韦美面 = context.User.Add(new User { UserName = "韦美面", Phone = "19162315495" });
            var 张贤媛 = context.User.Add(new User { UserName = "张贤媛", Phone = "18172029075" });
            var 蔡松延 = context.User.Add(new User { UserName = "蔡松延", Phone = "18277140602" });
            var 罗敏 = context.User.Add(new User { UserName = "罗敏", Phone = "13669683014" });
            var 米霞 = context.User.Add(new User { UserName = "米霞", Phone = "15878197831" });
            var 全琼 = context.User.Add(new User { UserName = "全琼", Phone = "13558290350" });
            var 钟彩园 = context.User.Add(new User { UserName = "钟彩园", Phone = "18377238469" });
            var 何雪梅 = context.User.Add(new User { UserName = "何雪梅", Phone = "13878636429" });
            var 黄柳榕 = context.User.Add(new User { UserName = "黄柳榕", Phone = "15877244277" });
            var 蓝蕉艳 = context.User.Add(new User { UserName = "蓝蕉艳", Phone = "18376999184" });
            var 梁兵 = context.User.Add(new User { UserName = "梁兵", Phone = "13517712070" });
            var 卢亿 = context.User.Add(new User { UserName = "卢亿", Phone = "13978853652" });
            var 罗丽 = context.User.Add(new User { UserName = "罗丽", Phone = "13877150007" });
            var 黄红成 = context.User.Add(new User { UserName = "黄红成", Phone = "18934722331" });
            var 李强 = context.User.Add(new User { UserName = "李强", Phone = "15078849504" });
            var 曹玉宣 = context.User.Add(new User { UserName = "曹玉宣", Phone = "13481166185" });
            var 党雪梅 = context.User.Add(new User { UserName = "党雪梅", Phone = "15678882702" });
            var 黄雅晴 = context.User.Add(new User { UserName = "黄雅晴", Phone = "18278888426" });
            var 黄艳娘 = context.User.Add(new User { UserName = "黄艳娘", Phone = "15994486451" });
            var 兰天翔 = context.User.Add(new User { UserName = "兰天翔", Phone = "18776202033" });
            var 蓝阳寿 = context.User.Add(new User { UserName = "蓝阳寿", Phone = "18174748164" });
            var 梁河 = context.User.Add(new User { UserName = "梁河", Phone = "13788400399" });
            var 林彩月 = context.User.Add(new User { UserName = "林彩月", Phone = "13617881581" });
            var 卢彩树 = context.User.Add(new User { UserName = "卢彩树", Phone = "17877185240" });
            var 卢春燕 = context.User.Add(new User { UserName = "卢春燕", Phone = "18894835926" });
            var 陆青青 = context.User.Add(new User { UserName = "陆青青", Phone = "15878367723" });
            var 蒙海秀 = context.User.Add(new User { UserName = "蒙海秀", Phone = "18807829264" });
            var 闵剑 = context.User.Add(new User { UserName = "闵剑", Phone = "18775305901" });
            var 潘宇艳 = context.User.Add(new User { UserName = "潘宇艳", Phone = "18707832404" });
            var 邱朝盛 = context.User.Add(new User { UserName = "邱朝盛", Phone = "15177473557" });
            var 覃建富 = context.User.Add(new User { UserName = "覃建富", Phone = "15289669487" });
            var 覃铭华 = context.User.Add(new User { UserName = "覃铭华", Phone = "18378574942" });
            var 陶成昆 = context.User.Add(new User { UserName = "陶成昆", Phone = "14736210192" });
            var 韦嘉娜 = context.User.Add(new User { UserName = "韦嘉娜", Phone = "15778845005" });
            var 肖冬 = context.User.Add(new User { UserName = "肖冬", Phone = "13788370488" });
            var 张永胜 = context.User.Add(new User { UserName = "张永胜", Phone = "14795828406" });
            var 长美凤 = context.User.Add(new User { UserName = "长美凤", Phone = "18775676785" });
            var 陈晚冬 = context.User.Add(new User { UserName = "陈晚冬", Phone = "13788399733" });
            var 黎芳倩 = context.User.Add(new User { UserName = "黎芳倩", Phone = "18377167958" });
            var 梁美美 = context.User.Add(new User { UserName = "梁美美", Phone = "18377160620" });
            var 廖荣景 = context.User.Add(new User { UserName = "廖荣景", Phone = "18249995836" });
            var 卢宗程 = context.User.Add(new User { UserName = "卢宗程", Phone = "18577792349" });
            var 宁霞 = context.User.Add(new User { UserName = "宁霞", Phone = "13788684617" });
            var 农冠敏 = context.User.Add(new User { UserName = "农冠敏", Phone = "18076598530" });
            var 覃文松 = context.User.Add(new User { UserName = "覃文松", Phone = "15078822876" });
            var 唐日云 = context.User.Add(new User { UserName = "唐日云", Phone = "15578976279" });
            var 杜增强 = context.User.Add(new User { UserName = "杜增强", Phone = "13471159445" });
            var 何文基 = context.User.Add(new User { UserName = "何文基", Phone = "13669602730" });
            var 李则远 = context.User.Add(new User { UserName = "李则远", Phone = "13977154520" });
            var 陆庆仙 = context.User.Add(new User { UserName = "陆庆仙", Phone = "15278000701" });
            var 潘世发 = context.User.Add(new User { UserName = "潘世发", Phone = "13471822651" });
            var 孙嘉敏 = context.User.Add(new User { UserName = "孙嘉敏", Phone = "18176884623" });
            var 陶丽葵 = context.User.Add(new User { UserName = "陶丽葵", Phone = "15077100913" });
            var 许春艳 = context.User.Add(new User { UserName = "许春艳", Phone = "18577182346" });
            var 张兰胜 = context.User.Add(new User { UserName = "张兰胜", Phone = "13481046960" });
            var 陈雷 = context.User.Add(new User { UserName = "陈雷", Phone = "15507894593" });
            var 邓大秦 = context.User.Add(new User { UserName = "邓大秦", Phone = "13737145049" });
            var 胡晓清 = context.User.Add(new User { UserName = "胡晓清", Phone = "15994324884" });
            var 李华英 = context.User.Add(new User { UserName = "李华英", Phone = "18176307200" });
            var 梁英武 = context.User.Add(new User { UserName = "梁英武", Phone = "15877188537" });
            var 刘琼华 = context.User.Add(new User { UserName = "刘琼华", Phone = "13978828556" });
            var 罗世强 = context.User.Add(new User { UserName = "罗世强", Phone = "18172374837" });
            var 石建飞 = context.User.Add(new User { UserName = "石建飞", Phone = "13481100513" });
            var 苏大钟 = context.User.Add(new User { UserName = "苏大钟", Phone = "18776939210" });
            var 韦黄康 = context.User.Add(new User { UserName = "韦黄康", Phone = "13737070534" });
            var 杨介兴 = context.User.Add(new User { UserName = "杨介兴", Phone = "13977170280" });
            var 张晨玲 = context.User.Add(new User { UserName = "张晨玲", Phone = "15578878919" });
            var 杜绥就 = context.User.Add(new User { UserName = "杜绥就", Phone = "18978940493" });
            var 吕春玉 = context.User.Add(new User { UserName = "吕春玉", Phone = "15977770929" });
            var 谭志彦 = context.User.Add(new User { UserName = "谭志彦", Phone = "15778033762" });
            var 唐宇平 = context.User.Add(new User { UserName = "唐宇平", Phone = "18275898720" });
            var 黄婷婷 = context.User.Add(new User { UserName = "黄婷婷", Phone = "18169608098" });
            var 黄美秋 = context.User.Add(new User { UserName = "黄美秋", Phone = "18249990205" });
            var 袁小玲 = context.User.Add(new User { UserName = "袁小玲", Phone = "15578160037" });
            var 周玉密 = context.User.Add(new User { UserName = "周玉密", Phone = "18578967892" });
            var 周冬梅 = context.User.Add(new User { UserName = "周冬梅", Phone = "18378069240" });
            var 李文贞 = context.User.Add(new User { UserName = "李文贞", Phone = "15278038212" });
            var 李叶恒 = context.User.Add(new User { UserName = "李叶恒", Phone = "13471038681" });
            var 满永安 = context.User.Add(new User { UserName = "满永安", Phone = "13627715914" });
            var 韦兰映 = context.User.Add(new User { UserName = "韦兰映", Phone = "18777145510" });
            var 余海平 = context.User.Add(new User { UserName = "余海平", Phone = "13077785907" });
            var 雷成 = context.User.Add(new User { UserName = "雷成", Phone = "15977730047" });
            var 张美秋 = context.User.Add(new User { UserName = "张美秋", Phone = "15977717230" });
            var 周小青 = context.User.Add(new User { UserName = "周小青", Phone = "14795556944" });
            var 黄耀涟 = context.User.Add(new User { UserName = "黄耀涟", Phone = "15578963987" });
            var 李学章 = context.User.Add(new User { UserName = "李学章", Phone = "18978878907" });
            var 卢威 = context.User.Add(new User { UserName = "卢威", Phone = "13471033764" });
            var 钟森 = context.User.Add(new User { UserName = "钟森", Phone = "15277184078" });
            var 金键 = context.User.Add(new User { UserName = "金键", Phone = "18377180645" });
            var 梁雪华 = context.User.Add(new User { UserName = "梁雪华", Phone = "18577180480" });
            var 秦连惠 = context.User.Add(new User { UserName = "秦连惠", Phone = "13978603543" });
            var 易丽玲 = context.User.Add(new User { UserName = "易丽玲", Phone = "15296570269" });
            var 罗道志 = context.User.Add(new User { UserName = "罗道志", Phone = "18775392831" });
            var 玉爱秋 = context.User.Add(new User { UserName = "玉爱秋", Phone = "15177463980" });
            var 方思敏 = context.User.Add(new User { UserName = "方思敏", Phone = "15278140203" });
            var 李淑娟 = context.User.Add(new User { UserName = "李淑娟", Phone = "18376673255" });
            var 梁银连 = context.User.Add(new User { UserName = "梁银连", Phone = "15307719323" });
            var 罗彩艳 = context.User.Add(new User { UserName = "罗彩艳", Phone = "15019245794" });
            var 罗芳彩 = context.User.Add(new User { UserName = "罗芳彩", Phone = "15077090463" });
            var 苏耀乐 = context.User.Add(new User { UserName = "苏耀乐", Phone = "18076637991" });
            var 覃正福 = context.User.Add(new User { UserName = "覃正福", Phone = "13607876412" });
            var 韦钰芳 = context.User.Add(new User { UserName = "韦钰芳", Phone = "15296544084" });
            var 杜涛 = context.User.Add(new User { UserName = "杜涛", Phone = "13481103094" });
            var 廖健妙 = context.User.Add(new User { UserName = "廖健妙", Phone = "15289668729" });
            var 韦飞云 = context.User.Add(new User { UserName = "韦飞云", Phone = "13347606986" });
            var 肖金秀 = context.User.Add(new User { UserName = "肖金秀", Phone = "13481010673" });
            var 朱真秀 = context.User.Add(new User { UserName = "朱真秀", Phone = "18376636662" });
            var 覃小宁 = context.User.Add(new User { UserName = "覃小宁", Phone = "15177927682" });
            var 段晓林 = context.User.Add(new User { UserName = "段晓林", Phone = "18587864164" });
            var 郭昊 = context.User.Add(new User { UserName = "郭昊", Phone = "18275762877" });
            var 黄丽华 = context.User.Add(new User { UserName = "黄丽华", Phone = "15296596403" });
            var 蓝雪梅 = context.User.Add(new User { UserName = "蓝雪梅", Phone = "15506816338" });
            var 李秋宇 = context.User.Add(new User { UserName = "李秋宇", Phone = "15677172767" });
            var 彭宇 = context.User.Add(new User { UserName = "彭宇", Phone = "17877104296" });
            var 杨丽丽 = context.User.Add(new User { UserName = "杨丽丽", Phone = "15078899740" });
            var 周晓宁 = context.User.Add(new User { UserName = "周晓宁", Phone = "13877150334" });
            var 李阳其 = context.User.Add(new User { UserName = "李阳其", Phone = "15878123521" });
            var 杨长江 = context.User.Add(new User { UserName = "杨长江", Phone = "18587544827" });
            var 玉桂玲 = context.User.Add(new User { UserName = "玉桂玲", Phone = "13471181207" });
            var 陈颖鑫 = context.User.Add(new User { UserName = "陈颖鑫", Phone = "18177761767" });
            var 黄炎昌 = context.User.Add(new User { UserName = "黄炎昌", Phone = "13321760931" });
            var 莫祖锋 = context.User.Add(new User { UserName = "莫祖锋", Phone = "18077111043" });
            var 王立志 = context.User.Add(new User { UserName = "王立志", Phone = "13558331718" });
            var 袁振杰 = context.User.Add(new User { UserName = "袁振杰", Phone = "18249990201" });
            var 邓家茵 = context.User.Add(new User { UserName = "邓家茵", Phone = "18378723315" });
            var 黄苗苗 = context.User.Add(new User { UserName = "黄苗苗", Phone = "18778997194" });
            var 蒋萍 = context.User.Add(new User { UserName = "蒋萍", Phone = "15578978079" });
            var 兰泽 = context.User.Add(new User { UserName = "兰泽", Phone = "18377181129" });
            var 黎培衡 = context.User.Add(new User { UserName = "黎培衡", Phone = "14777855445" });
            var 梁凤兰 = context.User.Add(new User { UserName = "梁凤兰", Phone = "17878092825" });
            var 罗鑫 = context.User.Add(new User { UserName = "罗鑫", Phone = "13457993262" });
            var 马开洋 = context.User.Add(new User { UserName = "马开洋", Phone = "17877633472" });
            var 齐梓钧 = context.User.Add(new User { UserName = "齐梓钧", Phone = "18178607470" });
            var 覃柳飞 = context.User.Add(new User { UserName = "覃柳飞", Phone = "18378809960" });
            var 唐黎娟 = context.User.Add(new User { UserName = "唐黎娟", Phone = "13707819731" });
            var 万海枫 = context.User.Add(new User { UserName = "万海枫", Phone = "17777555360" });
            var 王颖林 = context.User.Add(new User { UserName = "王颖林", Phone = "18070637217" });
            var 赵鸿琳 = context.User.Add(new User { UserName = "赵鸿琳", Phone = "15296543160" });
            var 钟彩珍 = context.User.Add(new User { UserName = "钟彩珍", Phone = "15877146804" });
            var 苏彩蓬 = context.User.Add(new User { UserName = "苏彩蓬", Phone = "13907860894" });
            var 陈鑫 = context.User.Add(new User { UserName = "陈鑫", Phone = "14777107613" });
            var 葛小云 = context.User.Add(new User { UserName = "葛小云", Phone = "13117601203" });
            var 黄炳芳 = context.User.Add(new User { UserName = "黄炳芳", Phone = "18777134176" });
            var 黄拥军 = context.User.Add(new User { UserName = "黄拥军", Phone = "13978691346" });
            var 蒋霞 = context.User.Add(new User { UserName = "蒋霞", Phone = "18074905899" });
            var 林芳莹 = context.User.Add(new User { UserName = "林芳莹", Phone = "18276675376" });
            var 林卫科 = context.User.Add(new User { UserName = "林卫科", Phone = "18078119053" });
            var 卢远雷 = context.User.Add(new User { UserName = "卢远雷", Phone = "13517558038" });
            var 唐雯钰 = context.User.Add(new User { UserName = "唐雯钰", Phone = "17877188939" });
            var 张敬亮 = context.User.Add(new User { UserName = "张敬亮", Phone = "15778868934" });
            var 朱广梧 = context.User.Add(new User { UserName = "朱广梧", Phone = "15177425845" });
            var 方禧 = context.User.Add(new User { UserName = "方禧", Phone = "13471041259" });
            var 冯彩密 = context.User.Add(new User { UserName = "冯彩密", Phone = "13597286807" });
            var 黄丽霜 = context.User.Add(new User { UserName = "黄丽霜", Phone = "18776700802" });
            var 兰艳 = context.User.Add(new User { UserName = "兰艳", Phone = "15994419212" });
            var 梁艳英 = context.User.Add(new User { UserName = "梁艳英", Phone = "15078869793" });
            var 苏美娜 = context.User.Add(new User { UserName = "苏美娜", Phone = "18776160860" });
            var 苏振兴 = context.User.Add(new User { UserName = "苏振兴", Phone = "15506802806" });
            var 韦小秋 = context.User.Add(new User { UserName = "韦小秋", Phone = "13878195712" });
            var 韦艳玲 = context.User.Add(new User { UserName = "韦艳玲", Phone = "18877834638" });
            var 吴佩芳 = context.User.Add(new User { UserName = "吴佩芳", Phone = "13737154663" });
            var 罗丝 = context.User.Add(new User { UserName = "罗丝", Phone = "18260924808" });
            var 何彩洁 = context.User.Add(new User { UserName = "何彩洁", Phone = "15878775846" });
            var 蓝芬玲 = context.User.Add(new User { UserName = "蓝芬玲", Phone = "18577115816" });
            var 李广清 = context.User.Add(new User { UserName = "李广清", Phone = "13517889332" });
            var 蒙金娜 = context.User.Add(new User { UserName = "蒙金娜", Phone = "13978873292" });
            var 白淼鑫 = context.User.Add(new User { UserName = "白淼鑫", Phone = "18091995556" });
            var 陈建裕 = context.User.Add(new User { UserName = "陈建裕", Phone = "18587690350" });
            var 程世华 = context.User.Add(new User { UserName = "程世华", Phone = "15978145659" });
            var 甘榜运 = context.User.Add(new User { UserName = "甘榜运", Phone = "13457629586" });
            var 苏华浩 = context.User.Add(new User { UserName = "苏华浩", Phone = "15219887889" });
            var 覃先武 = context.User.Add(new User { UserName = "覃先武", Phone = "18077162204" });
            var 奚泽晓 = context.User.Add(new User { UserName = "奚泽晓", Phone = "15177177584" });
            var 谢尚杰 = context.User.Add(new User { UserName = "谢尚杰", Phone = "18577791097" });
            var 曾金凤 = context.User.Add(new User { UserName = "曾金凤", Phone = "18260932099" });
            var 陈明君 = context.User.Add(new User { UserName = "陈明君", Phone = "18978182190" });
            var 邓杰兰 = context.User.Add(new User { UserName = "邓杰兰", Phone = "13878113461" });
            var 董春意 = context.User.Add(new User { UserName = "董春意", Phone = "18078143808" });
            var 黄然芳 = context.User.Add(new User { UserName = "黄然芳", Phone = "18776140987" });
            var 李倩肖 = context.User.Add(new User { UserName = "李倩肖", Phone = "13457081899" });
            var 李小玲 = context.User.Add(new User { UserName = "李小玲", Phone = "13557716925" });
            var 罗淞尹 = context.User.Add(new User { UserName = "罗淞尹", Phone = "17877105700" });
            var 农庆相 = context.User.Add(new User { UserName = "农庆相", Phone = "18376770494" });
            var 滕凤艳 = context.User.Add(new User { UserName = "滕凤艳", Phone = "18677172145" });
            var 杨德丽 = context.User.Add(new User { UserName = "杨德丽", Phone = "13557999176" });
            var 区传桦 = context.User.Add(new User { UserName = "区传桦", Phone = "15678569512" });
            var 王府焕 = context.User.Add(new User { UserName = "王府焕", Phone = "18776775739" });
            var 杨超雄 = context.User.Add(new User { UserName = "杨超雄", Phone = "18376640446" });
            var 钟晴 = context.User.Add(new User { UserName = "钟晴", Phone = "15677149253" });
            var 方诗锋 = context.User.Add(new User { UserName = "方诗锋", Phone = "13407700196" });
            var 黄春荣 = context.User.Add(new User { UserName = "黄春荣", Phone = "15177180494" });
            var 黄皓荣 = context.User.Add(new User { UserName = "黄皓荣", Phone = "15778078805" });
            var 兰梦瑶 = context.User.Add(new User { UserName = "兰梦瑶", Phone = "18776806624" });
            var 黎娟 = context.User.Add(new User { UserName = "黎娟", Phone = "13978852032" });
            var 李彪 = context.User.Add(new User { UserName = "李彪", Phone = "15578092858" });
            var 梁飞翠 = context.User.Add(new User { UserName = "梁飞翠", Phone = "18277167946" });
            var 罗杰 = context.User.Add(new User { UserName = "罗杰", Phone = "18978984755" });
            var 盘庆枭 = context.User.Add(new User { UserName = "盘庆枭", Phone = "18277848258" });
            var 谭振洲 = context.User.Add(new User { UserName = "谭振洲", Phone = "13687815750" });
            var 黄艳芳 = context.User.Add(new User { UserName = "黄艳芳", Phone = "13978669406" });
            var 潘婕 = context.User.Add(new User { UserName = "潘婕", Phone = "15676194844" });
            var 陈嘉成 = context.User.Add(new User { UserName = "陈嘉成", Phone = "15877135242" });
            var 陈丽芳 = context.User.Add(new User { UserName = "陈丽芳", Phone = "18697933326" });
            var 邓金慧 = context.User.Add(new User { UserName = "邓金慧", Phone = "13978850581" });
            var 邓景愿 = context.User.Add(new User { UserName = "邓景愿", Phone = "13377189198" });
            var 黄健斌 = context.User.Add(new User { UserName = "黄健斌", Phone = "18978917549" });
            var 蓝艳美 = context.User.Add(new User { UserName = "蓝艳美", Phone = "18249991148" });
            var 李葵凤 = context.User.Add(new User { UserName = "李葵凤", Phone = "18277126635" });
            var 凌轩 = context.User.Add(new User { UserName = "凌轩", Phone = "18577030726" });
            var 蒙柳忻 = context.User.Add(new User { UserName = "蒙柳忻", Phone = "18172362916" });
            var 覃镇丽 = context.User.Add(new User { UserName = "覃镇丽", Phone = "18078196063" });
            var 滕斐 = context.User.Add(new User { UserName = "滕斐", Phone = "18776648490" });
            var 徐健思 = context.User.Add(new User { UserName = "徐健思", Phone = "18677879775" });
            var 许忠林 = context.User.Add(new User { UserName = "许忠林", Phone = "18377104020" });
            var 赵冯杰 = context.User.Add(new User { UserName = "赵冯杰", Phone = "18376764432" });
            var 周月岚 = context.User.Add(new User { UserName = "周月岚", Phone = "13768171683" });
            var 邹紫曼 = context.User.Add(new User { UserName = "邹紫曼", Phone = "15677132738" });
            var 黄炽 = context.User.Add(new User { UserName = "黄炽", Phone = "18377166682" });
            var 黄玲 = context.User.Add(new User { UserName = "黄玲", Phone = "18577848410" });
            var 李雪伶 = context.User.Add(new User { UserName = "李雪伶", Phone = "13978890253" });
            var 龙小林 = context.User.Add(new User { UserName = "龙小林", Phone = "18378862065" });
            var 陆桂利 = context.User.Add(new User { UserName = "陆桂利", Phone = "13878169556" });
            var 唐利祝 = context.User.Add(new User { UserName = "唐利祝", Phone = "18176894996" });
            var 唐硕 = context.User.Add(new User { UserName = "唐硕", Phone = "15078814268" });
            var 吴娟 = context.User.Add(new User { UserName = "吴娟", Phone = "15677018843" });
            var 张倩 = context.User.Add(new User { UserName = "张倩", Phone = "15277105212" });
            var 黄礼司 = context.User.Add(new User { UserName = "黄礼司", Phone = "18276122076" });
            var 黄礼祝 = context.User.Add(new User { UserName = "黄礼祝", Phone = "13788683814" });
            var 梁娜 = context.User.Add(new User { UserName = "梁娜", Phone = "18074940096" });
            var 刘浩杰 = context.User.Add(new User { UserName = "刘浩杰", Phone = "14795529410" });
            var 罗飞花 = context.User.Add(new User { UserName = "罗飞花", Phone = "13978802940" });
            var 骆晓云 = context.User.Add(new User { UserName = "骆晓云", Phone = "19977414647" });
            var 莫彩音 = context.User.Add(new User { UserName = "莫彩音", Phone = "15978176780" });
            var 韦传华 = context.User.Add(new User { UserName = "韦传华", Phone = "18777109092" });
            var 余柳君 = context.User.Add(new User { UserName = "余柳君", Phone = "15878277842" });
            var 黄玉梅 = context.User.Add(new User { UserName = "黄玉梅", Phone = "13878186610" });
            var 张明玲 = context.User.Add(new User { UserName = "张明玲", Phone = "18776743446" });
            var 蔡意玲 = context.User.Add(new User { UserName = "蔡意玲", Phone = "17877103805" });
            var 方银 = context.User.Add(new User { UserName = "方银", Phone = "15207810058" });
            var 黄春露 = context.User.Add(new User { UserName = "黄春露", Phone = "15978177112" });
            var 黄仁磊 = context.User.Add(new User { UserName = "黄仁磊", Phone = "13737558674" });
            var 黄怡泽 = context.User.Add(new User { UserName = "黄怡泽", Phone = "17878208174" });
            var 雷锦玲 = context.User.Add(new User { UserName = "雷锦玲", Phone = "18697950131" });
            var 黎辉 = context.User.Add(new User { UserName = "黎辉", Phone = "15977487131" });
            var 李惠 = context.User.Add(new User { UserName = "李惠", Phone = "15077744536" });
            var 李静 = context.User.Add(new User { UserName = "李静", Phone = "13978668024" });
            var 李梓健 = context.User.Add(new User { UserName = "李梓健", Phone = "15277303387" });
            var 卢曼婷 = context.User.Add(new User { UserName = "卢曼婷", Phone = "18776730092" });
            var 陆彩红 = context.User.Add(new User { UserName = "陆彩红", Phone = "13788689810" });
            var 马玲杰 = context.User.Add(new User { UserName = "马玲杰", Phone = "15676131780" });
            var 蒙佳群 = context.User.Add(new User { UserName = "蒙佳群", Phone = "18275975950" });
            var 农学杰 = context.User.Add(new User { UserName = "农学杰", Phone = "17677165296" });
            var 王家富 = context.User.Add(new User { UserName = "王家富", Phone = "15177123349" });
            var 吴邕萍 = context.User.Add(new User { UserName = "吴邕萍", Phone = "13707886525" });
            var 杨土康 = context.User.Add(new User { UserName = "杨土康", Phone = "15768671860" });
            var 袁洪源 = context.User.Add(new User { UserName = "袁洪源", Phone = "13367533629" });
            var 何翠华 = context.User.Add(new User { UserName = "何翠华", Phone = "15994431272" });
            var 何嘉桦 = context.User.Add(new User { UserName = "何嘉桦", Phone = "15978123970" });
            var 黄崇光 = context.User.Add(new User { UserName = "黄崇光", Phone = "13977781722" });
            var 黄金莲 = context.User.Add(new User { UserName = "黄金莲", Phone = "13647710434" });
            var 黄艳兴 = context.User.Add(new User { UserName = "黄艳兴", Phone = "17877104297" });
            var 廖树梅 = context.User.Add(new User { UserName = "廖树梅", Phone = "18776982995" });
            var 潘美燕 = context.User.Add(new User { UserName = "潘美燕", Phone = "17687734907" });
            var 覃嘉 = context.User.Add(new User { UserName = "覃嘉", Phone = "18074923602" });
            var 韦海杰 = context.User.Add(new User { UserName = "韦海杰", Phone = "18275914685" });
            var 韦小娇 = context.User.Add(new User { UserName = "韦小娇", Phone = "18377103027" });
            var 许芳本 = context.User.Add(new User { UserName = "许芳本", Phone = "18378929230" });
            var 周增佐 = context.User.Add(new User { UserName = "周增佐", Phone = "18376707223" });
            var 粟伟铭 = context.User.Add(new User { UserName = "粟伟铭", Phone = "13878133014" });
            var 韦珍 = context.User.Add(new User { UserName = "韦珍", Phone = "13377000731" });
            var 杜美华 = context.User.Add(new User { UserName = "杜美华", Phone = "13978695542" });
            var 葛施梦 = context.User.Add(new User { UserName = "葛施梦", Phone = "13877185087" });
            var 关迪康 = context.User.Add(new User { UserName = "关迪康", Phone = "15177114121" });
            var 黄晶晶 = context.User.Add(new User { UserName = "黄晶晶", Phone = "13878165724" });
            var 李志华 = context.User.Add(new User { UserName = "李志华", Phone = "13211350170" });
            var 廖其永 = context.User.Add(new User { UserName = "廖其永", Phone = "15994345676" });
            var 廖青青 = context.User.Add(new User { UserName = "廖青青", Phone = "18777133319" });
            var 蒙美妮 = context.User.Add(new User { UserName = "蒙美妮", Phone = "18376682900" });
            var 庞靖玮 = context.User.Add(new User { UserName = "庞靖玮", Phone = "18978241470" });
            var 王赞君 = context.User.Add(new User { UserName = "王赞君", Phone = "15296585793" });
            var 韦浩 = context.User.Add(new User { UserName = "韦浩", Phone = "18249998662" });
            var 吴倩 = context.User.Add(new User { UserName = "吴倩", Phone = "14795498556" });
            var 姚雪秀 = context.User.Add(new User { UserName = "姚雪秀", Phone = "18776803840" });
            var 张业美 = context.User.Add(new User { UserName = "张业美", Phone = "18894797013" });
            var 钟莎 = context.User.Add(new User { UserName = "钟莎", Phone = "15577307896" });
            var 陈金燕 = context.User.Add(new User { UserName = "陈金燕", Phone = "15277069581" });
            var 陈艳 = context.User.Add(new User { UserName = "陈艳", Phone = "13607875157" });
            var 黄伟琳 = context.User.Add(new User { UserName = "黄伟琳", Phone = "18269166885" });
            var 黄燕萍 = context.User.Add(new User { UserName = "黄燕萍", Phone = "17777173520" });
            var 吴健珍 = context.User.Add(new User { UserName = "吴健珍", Phone = "18977192057" });
            var 黄爱双 = context.User.Add(new User { UserName = "黄爱双", Phone = "15296206478" });
            var 黄文任 = context.User.Add(new User { UserName = "黄文任", Phone = "15778149919" });
            var 刘晶晶 = context.User.Add(new User { UserName = "刘晶晶", Phone = "15676832025" });
            var 卢敏健 = context.User.Add(new User { UserName = "卢敏健", Phone = "13257794365" });
            var 韦宇梅 = context.User.Add(new User { UserName = "韦宇梅", Phone = "18154626531" });
            var 赵小媚 = context.User.Add(new User { UserName = "赵小媚", Phone = "15177798478" });
            var 黄晓玲 = context.User.Add(new User { UserName = "黄晓玲", Phone = "13481110380" });
            var 刘凤娟 = context.User.Add(new User { UserName = "刘凤娟", Phone = "18078169561" });
            var 黄闽 = context.User.Add(new User { UserName = "黄闽", Phone = "15977753442" });
            var 黄雄 = context.User.Add(new User { UserName = "黄雄", Phone = "15277182224" });
            var 黎子鹏 = context.User.Add(new User { UserName = "黎子鹏", Phone = "13471049640" });
            var 李唐军 = context.User.Add(new User { UserName = "李唐军", Phone = "18587885607" });
            var 梁超 = context.User.Add(new User { UserName = "梁超", Phone = "13878131973" });
            var 廖发新 = context.User.Add(new User { UserName = "廖发新", Phone = "18169637483" });
            var 沈健 = context.User.Add(new User { UserName = "沈健", Phone = "15078832830" });
            var 苏伟宇 = context.User.Add(new User { UserName = "苏伟宇", Phone = "13768506809" });
            var 谭超香 = context.User.Add(new User { UserName = "谭超香", Phone = "15078897164" });
            var 温海皇 = context.User.Add(new User { UserName = "温海皇", Phone = "13557582832" });
            var 向长贵 = context.User.Add(new User { UserName = "向长贵", Phone = "13737039837" });
            var 肖超志 = context.User.Add(new User { UserName = "肖超志", Phone = "13978819225" });
            var 张志云 = context.User.Add(new User { UserName = "张志云", Phone = "15078855128" });
            var 钟胜 = context.User.Add(new User { UserName = "钟胜", Phone = "13878843043" });
            var 周光诚 = context.User.Add(new User { UserName = "周光诚", Phone = "18587533306" });
            var 朱欣 = context.User.Add(new User { UserName = "朱欣", Phone = "13481131320" });
            var 甘玉芳 = context.User.Add(new User { UserName = "甘玉芳", Phone = "15077166360" });
            var 黄坛芳 = context.User.Add(new User { UserName = "黄坛芳", Phone = "15240682324" });
            var 欧之元 = context.User.Add(new User { UserName = "欧之元", Phone = "18376602469" });
            var 谭剑雄 = context.User.Add(new User { UserName = "谭剑雄", Phone = "15277047112" });
            var 陈丽莎 = context.User.Add(new User { UserName = "陈丽莎", Phone = "13878832279" });
            var 黄丽云 = context.User.Add(new User { UserName = "黄丽云", Phone = "15578066426" });
            var 张庆忠 = context.User.Add(new User { UserName = "张庆忠", Phone = "13407745305" });
            var 曹璃 = context.User.Add(new User { UserName = "曹璃", Phone = "13878851919" });
            var 古盛琳 = context.User.Add(new User { UserName = "古盛琳", Phone = "13788010506" });
            var 何汾蔓 = context.User.Add(new User { UserName = "何汾蔓", Phone = "18977190832" });
            var 何鹏 = context.User.Add(new User { UserName = "何鹏", Phone = "13978811355" });
            var 柳颖枝 = context.User.Add(new User { UserName = "柳颖枝", Phone = "13077760114" });
            var 农红梅 = context.User.Add(new User { UserName = "农红梅", Phone = "18275727598" });
            var 苏晏卿 = context.User.Add(new User { UserName = "苏晏卿", Phone = "18076536032" });
            var 肖木兰 = context.User.Add(new User { UserName = "肖木兰", Phone = "13878161210" });
            var 邓丽英 = context.User.Add(new User { UserName = "邓丽英", Phone = "13878169592" });
            var 樊柳花 = context.User.Add(new User { UserName = "樊柳花", Phone = "18978817664" });
            var 卢宇 = context.User.Add(new User { UserName = "卢宇", Phone = "13152690717" });
            var 潘凤美 = context.User.Add(new User { UserName = "潘凤美", Phone = "13978673133" });
            var 覃利玲 = context.User.Add(new User { UserName = "覃利玲", Phone = "15177135230" });
            var 韦丽丽 = context.User.Add(new User { UserName = "韦丽丽", Phone = "13558144261" });
            var 张欣 = context.User.Add(new User { UserName = "张欣", Phone = "18076545557" });
            var 赵克清 = context.User.Add(new User { UserName = "赵克清", Phone = "13977135649" });
            var 周艳 = context.User.Add(new User { UserName = "周艳", Phone = "13367711252" });
            var 黎嫣 = context.User.Add(new User { UserName = "黎嫣", Phone = "13978694415" });
            var 陈桥 = context.User.Add(new User { UserName = "陈桥", Phone = "13978628291" });
            var 邱雯 = context.User.Add(new User { UserName = "邱雯", Phone = "13878198527" });
            var 吴振权 = context.User.Add(new User { UserName = "吴振权", Phone = "13471001837" });
            var 李茜茜 = context.User.Add(new User { UserName = "李茜茜", Phone = "15777124241" });
            var 覃文垚 = context.User.Add(new User { UserName = "覃文垚", Phone = "15777155159" });
            var 罗敏芳 = context.User.Add(new User { UserName = "罗敏芳", Phone = "13978893201" });
            var 陈小燕 = context.User.Add(new User { UserName = "陈小燕", Phone = "13768112147" });
            var 韦爱献 = context.User.Add(new User { UserName = "韦爱献", Phone = "13597348430" });
            var 陆丽梅 = context.User.Add(new User { UserName = "陆丽梅", Phone = "13737080895" });
            var 陆双艳 = context.User.Add(new User { UserName = "陆双艳", Phone = "13877178979" });
            var 谭江林 = context.User.Add(new User { UserName = "谭江林", Phone = "15107711717" });
            var 廖程 = context.User.Add(new User { UserName = "廖程", Phone = "18677580740" });
            var 林开国 = context.User.Add(new User { UserName = "林开国", Phone = "18677587087" });
            var 陈国霜 = context.User.Add(new User { UserName = "陈国霜", Phone = "18277550669" });
            var 张军 = context.User.Add(new User { UserName = "张军", Phone = "15207852170" });
            var 周年达 = context.User.Add(new User { UserName = "周年达", Phone = "18376764490" });
            var 庞翠敏 = context.User.Add(new User { UserName = "庞翠敏", Phone = "13557759691" });
            var 谭小平 = context.User.Add(new User { UserName = "谭小平", Phone = "13877561665" });
            var 蒋超敏 = context.User.Add(new User { UserName = "蒋超敏", Phone = "18775075370" });
            var 周博燕 = context.User.Add(new User { UserName = "周博燕", Phone = "18775075171" });
            var 黄素芳 = context.User.Add(new User { UserName = "黄素芳", Phone = "18677585594" });
            var 陈冬梅 = context.User.Add(new User { UserName = "陈冬梅", Phone = "18877542396" });
            var 梁声琼 = context.User.Add(new User { UserName = "梁声琼", Phone = "15677598925" });
            var 谢武燕 = context.User.Add(new User { UserName = "谢武燕", Phone = "15977945257" });
            var 贺艳为 = context.User.Add(new User { UserName = "贺艳为", Phone = "15278525825" });
            var 白世杰 = context.User.Add(new User { UserName = "白世杰", Phone = "19978872241" });
            var 赵春秀 = context.User.Add(new User { UserName = "赵春秀", Phone = "13737580819" });
            var 陈天德 = context.User.Add(new User { UserName = "陈天德", Phone = "15277596770" });
            var 陈建珍 = context.User.Add(new User { UserName = "陈建珍", Phone = "18269201642" });
            var 蒋杰 = context.User.Add(new User { UserName = "蒋杰", Phone = "18077543367" });
            var 梁超1 = context.User.Add(new User { UserName = "梁超", Phone = "13977585605" });
            var 岑雯妤 = context.User.Add(new User { UserName = "岑雯妤", Phone = "15977568621" });
            var 梁春美 = context.User.Add(new User { UserName = "梁春美", Phone = "14795768829" });
            var 罗理旺 = context.User.Add(new User { UserName = "罗理旺", Phone = "15977557426" });
            var 黄盼盼 = context.User.Add(new User { UserName = "黄盼盼", Phone = "13669698402" });
            var 张凤梅 = context.User.Add(new User { UserName = "张凤梅", Phone = "15277511018" });
            var 张雄军 = context.User.Add(new User { UserName = "张雄军", Phone = "18677360166" });
            var 杨杰 = context.User.Add(new User { UserName = "杨杰", Phone = "19977223737" });
            var 李兴 = context.User.Add(new User { UserName = "李兴", Phone = "18407728054" });
            var 陈剑波 = context.User.Add(new User { UserName = "陈剑波", Phone = "13807894310" });
            var 龚晓丹 = context.User.Add(new User { UserName = "龚晓丹", Phone = "18507890664" });
            var 欧宗庆 = context.User.Add(new User { UserName = "欧宗庆", Phone = "13084911689" });
            var 李英德 = context.User.Add(new User { UserName = "李英德", Phone = "13707857586" });
            var 符福伟 = context.User.Add(new User { UserName = "符福伟", Phone = "13807776780" });

            #region 新加用户，学校老师，实习生
            var 赖铭轩 = context.User.Add(new User { UserName = "赖铭轩", Phone = "13277711572" });
            var 韩箐 = context.User.Add(new User { UserName = "韩箐", Phone = "15678169985" });
            var 林峰 = context.User.Add(new User { UserName = "林峰", Phone = "13276062689" });
            var 叶斐愉 = context.User.Add(new User { UserName = "叶斐愉", Phone = "18750959148" });
            var 陈希铨 = context.User.Add(new User { UserName = "陈希铨", Phone = "18477169689" });
            var 刘俊杰 = context.User.Add(new User { UserName = "刘俊杰", Phone = "15578936630" });
            var 李洋鹏 = context.User.Add(new User { UserName = "李洋鹏", Phone = "17344207051" });
            var 廖小连 = context.User.Add(new User { UserName = "廖小连", Phone = "15676792491" });
            var 陈亮 = context.User.Add(new User { UserName = "陈亮", Phone = "13014996371" });
            var 蔡昭禹 = context.User.Add(new User { UserName = "蔡昭禹", Phone = "15676139973" });
            var 陈伟进 = context.User.Add(new User { UserName = "陈伟进", Phone = "17396708124" });
            var 徐妙玲 = context.User.Add(new User { UserName = "徐妙玲", Phone = "18775325815" });
            var 农琪 = context.User.Add(new User { UserName = "农琪", Phone = "17677455208" });
            var 唐睿婕 = context.User.Add(new User { UserName = "唐睿婕", Phone = "18275877934" });
            var 王一全 = context.User.Add(new User { UserName = "王一全", Phone = "13878306291" });
            var 赵新尹 = context.User.Add(new User { UserName = "赵新尹", Phone = "18707760261" });
            var 韦佳杏 = context.User.Add(new User { UserName = "韦佳杏", Phone = "18275720031" });
            var 龚思维 = context.User.Add(new User { UserName = "龚思维", Phone = "15677049753" });
            var 姚业婷 = context.User.Add(new User { UserName = "姚业婷", Phone = "18807891376" });
            var 刘梦彩 = context.User.Add(new User { UserName = "刘梦彩", Phone = "19968180486" });
            var 熊灏 = context.User.Add(new User { UserName = "熊灏", Phone = "18907713928" });
            var 朱华 = context.User.Add(new User { UserName = "朱华", Phone = "13807809180" });
            var 刘善景 = context.User.Add(new User { UserName = "刘善景", Phone = "13877134043" });
            var 易小燕 = context.User.Add(new User { UserName = "易小燕", Phone = "15994312398" });
            var 汤荟琛 = context.User.Add(new User { UserName = "汤荟琛", Phone = "13471196815" });
            #endregion

            #endregion

            #region 方队队伍
            var t1 = context.Team.Add(new Team
            {
                Name = "方队一",
                Preliminaries = 1.2D,
            });
            var t2 = context.Team.Add(new Team
            {
                Name = "方队二",
                Preliminaries = 2.1,
            });
            var t3 = context.Team.Add(new Team
            {
                Name = "方队三",
                Preliminaries = 2.0,
            });
            var t4 = context.Team.Add(new Team
            {
                Name = "方队四",
                Preliminaries = 1.4,
            });
            var t5 = context.Team.Add(new Team
            {
                Name = "方队五",
                Preliminaries = 3.3,
            });
            #endregion

            context.SaveChanges();


            #region 歌手

            #region 方队一
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 张珈铨 },
                ProgramName = "恋爱ing",
                Team = t1,
                Sort = 12,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 谭剑雄 },
                ProgramName = "果汁分你一半",
                Team = t1,
                Sort = 2,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 葛施梦 },
                ProgramName = "我要我们在一起",
                Team = t1,
                Sort = 9,
            });

            #endregion

            #region 方队二
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 谢尚杰 },
                ProgramName = "南方姑娘",
                Team = t2,
                Sort = 10,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 杨超雄 },
                ProgramName = "遥远的她",
                Team = t2,
                Sort = 1,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 陈玉兰 },
                ProgramName = "世界上的另一个我",
                Team = t2,
                Sort = 3,
            });
            #endregion

            #region 方队三
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 潘婕 },
                ProgramName = "最长的电影",
                Team = t3,
                Sort = 13,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 罗敏芳 },
                ProgramName = "可不可以不勇敢",
                Team = t3,
                Sort = 7,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 骆晓云 },
                ProgramName = "少女的祈祷",
                Team = t3,
                Sort = 11,
            });
            #endregion

            #region 方队四
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 张南骁 },
                ProgramName = "Life's A Struggle",
                Team = t4,
                Sort = 8,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 曾皓 },
                ProgramName = "一丝不挂",
                Team = t4,
                Sort = 6,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 陈晚冬 },
                ProgramName = "匆匆那年",
                Team = t4,
                Sort = 4,
            });
            #endregion

            #region 方队五
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 黄苗苗 },
                ProgramName = "青鸟",
                Team = t5,
                Sort = 5,
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 马开洋, 齐梓钧, 郭昊, 王颖林, 黎培衡, 梁凤兰, 万海枫, 唐黎娟, 覃柳飞, 邓家茵 },
                ProgramName = "黄种人",
                Team = t5,
                Sort = 15,
                CombinationName = "创造404组合",
            });
            context.Performer.Add(new Performer
            {
                Users = new List<User> { 潘美燕 },
                ProgramName = "阿刁",
                Team = t5,
                Sort = 14,
            });
            #endregion

            #endregion

            context.SaveChanges();
        }
    }
}
