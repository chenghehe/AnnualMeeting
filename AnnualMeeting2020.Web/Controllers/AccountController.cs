using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using AnnualMeeting2020.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace AnnualMeeting2020.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AnnualMeetingContext _db;

        public AccountController(AnnualMeetingContext db)
        {
            _db = db;
        }

        // GET: Account
        public async Task<ActionResult> Index()       
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Login(LoginInput input)
        {
            if (ModelState.IsValid)
            {
                var user = _db.User.FirstOrDefault(x => x.UserName == input.UserName.Trim() && x.Phone == input.Phone.Trim());
                if (user != default)
                {
                    var url = _getLoginUrl(user);
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    Session[AnnualMeeting2020Key.SESSION_USER_KEY] = user;

                    return Json(new
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Result = url,
                    });
                }
                return Json(new
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Result = "该用户不存在！"
                });
            }
            return Json(new
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Result = "输入不规范！"
            });
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session[AnnualMeeting2020Key.SESSION_USER_KEY] = null;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 根据用户身份获取跳转页面
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string _getLoginUrl(User user)
        {
            return Url.Action("Background", "Home");
            if (user.UserType.HasFlag(UserType.管理员))
                return Url.Action("Index", "Home");
            if (user.UserType.HasFlag(UserType.评委))
                return Url.Action("Index", "Home");
            return Url.Action("Index", "Home");
        }
    }
}