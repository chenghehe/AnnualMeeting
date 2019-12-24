using AnnualMeeting2020.Common;
using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using AnnualMeeting2020.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AnnualMeetingContext _db;

        public AdminController(AnnualMeetingContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 实时投票数据展示
        /// </summary>
        /// <returns></returns>
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] != null)
            {
                var player = Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] as Performer;
                var userName = string.Empty;
                if (string.IsNullOrEmpty(player.CombinationName))
                {
                    foreach (var name in player.Users.Select(x => x.UserName))
                    {
                        userName += name + "|";
                    }
                }
                else
                {
                    userName = player.CombinationName;
                }
                userName = userName.Trim('|');
                ViewBag.Player = $"{player.Team.Name}{AnnualMeeting2020Key.SPLIT_CHAR}{userName}{AnnualMeeting2020Key.SPLIT_CHAR}{player.ProgramName}";


                ViewBag.Count = Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_TICKET_KEY];
            }
            else
            {
                ViewBag.Player = "无";
                ViewBag.Count = 0;
            }
            return View();
        }

        /// <summary>
        /// 实时弹幕列表展示
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Message()
        {
            return View();
        }

        /// <summary>
        /// 切歌
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Switch()
        {
            if (_getLoginUser().UserType.HasFlag(UserType.管理员))
            {
                var list = await _db.Performer.Select(x => new SwitchViewModel
                {
                    Id = x.Id,
                    IdPerform = x.IdPerform,
                    ProgramName = x.ProgramName,
                    TeamName = x.Team.Name,
                    TeamId = x.TeamId,
                    CombinationName = x.CombinationName,
                    UserName = x.Users.Select(u => u.UserName),
                }).OrderBy(x => x.TeamId).AsNoTracking().ToListAsync();
                //var result = list.Select(x =>
                // {
                //     var entity = new SwitchViewModel
                //     {
                //         Id = x.Id,
                //         IdPerform = x.IdPerform,
                //         ProgramName = x.ProgramName,
                //         TeamName = x.TeamName,
                //         TeamId = x.TeamId,
                //     };
                //     if (x.Users.Any())
                //     {
                //         var name = string.Empty;
                //         foreach (var item in x.Users)
                //         {
                //             name += item.UserName + "|";
                //         }
                //         name = name.Trim('|');
                //         entity.UserName = name;
                //     }
                //     return entity;
                // });

                var isMessage = (Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY] == null ? true : Convert.ToBoolean(Cache.Instance[AnnualMeeting2020Key.CACHE_IsMessage_KEY]));
                if (isMessage)
                    ViewBag.IsMessage = "关闭";
                else
                    ViewBag.IsMessage = "打开";
                return View(list);
            }
            else
                return Content("权限不足!!!");
        }


        /// <summary>
        /// 评委评分
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Judges()
        {
            if (_getLoginUser().UserType.HasFlag(UserType.评委))
            {
                {
                    var uId = Convert.ToInt32(User.Identity.Name);
                    //var user = db.User.Find(uId);
                    var list = await _db.Performer.GroupJoin(_db.Judges_Performer, x => new
                    {
                        PerformerId = x.Id,
                        UserId = uId
                    }, x => new
                    {
                        x.PerformerId,
                        x.UserId
                    }, (Performer, User_Performer) => new
                    {
                        Performer,
                        User_Performer,
                    })
                        .SelectMany(x => x.User_Performer.DefaultIfEmpty(), (x, User_Performer) => new
                        {
                            x.Performer.Id,
                            x.Performer.ProgramName,
                            x.Performer.Users,
                            x.Performer.IdPerform,
                            x.Performer.CombinationName,
                            TeamName = x.Performer.Team.Name,
                            IsSelect = x.User_Performer.Any(),
                        })
                    .Select(x => new PerformerOut
                    {
                        Id = x.Id,
                        IsSelect = x.IsSelect,
                        ProgramName = x.ProgramName,
                        CombinationName = x.CombinationName,
                        TeamName = x.TeamName,
                        IdPerform = x.IdPerform,
                        //x.Users,
                        UserName = x.Users.Select(u => u.UserName)
                    })
                    .Where(x => !x.IsSelect)
                    .AsNoTracking()
                    .ToListAsync();

                    //var list = await db.Performer.Include(x => x.Users).AsNoTracking().ToListAsync(cancellationToken);
                    //var result = list.Select(x =>
                    //{
                    //    var name = string.Empty;
                    //    foreach (var item in x.Users)
                    //    {
                    //        name += item.UserName + "|";
                    //    }
                    //    name = name.Trim('|') + (x.IsSelect ? " (已评)" : "");
                    //    return new PerformerOut
                    //    {
                    //        Id = x.Id,
                    //        ProgramName = x.ProgramName,
                    //        UserName = name,
                    //        IsSelect = x.IsSelect,
                    //        IdPerform = x.IdPerform,
                    //        TeamName = x.TeamName
                    //    };
                    //});

                    var judges_Performer = await _db.Judges_Performer
                        .Where(x => x.UserId == uId)
                        .Select(x => new JudgesViewModel
                        {
                            Fraction = (x.Feeling + x.Pronounce + x.Intonation + x.Performance + x.Progress),
                            ProgramName = x.Performer.ProgramName,
                            TeamName = x.Performer.Team.Name,
                            UserName = x.Performer.Users.Select(u => u.UserName),
                        })
                        .OrderBy(x => x.Fraction)
                        .AsNoTracking()
                        .ToListAsync();
                    ViewData["My_Judges_Performer"] = judges_Performer;
                    //    judges_Performer.Select(x =>
                    //{
                    //    var judgesViewModel = new JudgesViewModel
                    //    {
                    //        Fraction = x.Fraction,
                    //        ProgramName = x.Performer.ProgramName,
                    //        TeamName = x.TeamName,
                    //    };
                    //    if (x.Users.Any())
                    //    {
                    //        var name = string.Empty;
                    //        foreach (var item in x.Users)
                    //        {
                    //            name += item.UserName + "|";
                    //        }
                    //        name = name.Trim('|');
                    //        judgesViewModel.UserName = name;
                    //    }
                    //    return judgesViewModel;
                    //});
                    return View(list);
                }
            }
            else
                return Content("权限不足!!!");
        }

        /// <summary>
        /// 评委评分
        /// </summary>
        /// <param name="pid">选手编号</param>
        /// <param name="Feeling">感情分数</param>
        /// <param name="Pronounce">咬字分数</param>
        /// <param name="Intonation">音准节奏分数</param>
        /// <param name="Performance">舞台表现分数</param>
        /// <param name="Progress">完成度分数</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Judges(int pid, double Feeling, double Pronounce, double Intonation, double Performance, double Progress)
        {
            if (pid > 0)
            {
                try
                {
                    var currUser = _db.User.Find(Convert.ToInt32(HttpContext.User.Identity.Name));
                    if (!currUser.UserType.HasFlag(UserType.评委))
                    {
                        return Json(new
                        {
                            StatusCode = System.Net.HttpStatusCode.BadRequest,
                            Result = "评分失败！当前账号不是评委！"
                        });
                    }
                    var jp = await _db.Judges_Performer.FirstOrDefaultAsync(x => x.UserId == currUser.Id && x.PerformerId == pid);
                    if (jp != null)       //已经评分过了，修改
                    {
                        jp.Feeling = Feeling;
                        jp.Pronounce = Pronounce;
                        jp.Intonation = Intonation;
                        jp.Performance = Performance;
                        jp.Progress = Progress;
                        _db.Entry(jp).State = EntityState.Modified;
                    }
                    else
                    {
                        _db.Judges_Performer.Add(new Judges_Performer
                        {
                            UserId = currUser.Id,
                            PerformerId = pid,
                            Feeling = Feeling,
                            Pronounce = Pronounce,
                            Intonation = Intonation,
                            Performance = Performance,
                            Progress = Progress,
                        });
                    }
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Json(new
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,
                            Result = "评分成功！"
                        });
                    }
                }
                catch (Exception)
                {

                }
                return Json(new
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Result = "评分失败！"
                });
            }
            else
            {
                return Json(new
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Result = "投票失败！请选择选手！"
                });
            }
        }

        /// <summary>
        /// 评委评分列表
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> JudgesList()
        {
            //if (_getLoginUser().UserType.HasFlag(UserType.管理员))
            {
                var player = Cache.Instance[AnnualMeeting2020Key.CACHE_CURRENT_PLAYER_KEY] as Performer;
                if (player != null)
                {
                    var list = await _db.Judges_Performer
                        .Where(x => x.PerformerId == player.Id)
                        .Select(x => new Judges_PerformerViewModel
                        {
                            UserName = x.User.UserName,
                            CombinationName = x.Performer.CombinationName,
                            ProgramName = x.Performer.ProgramName,
                            PerformerUserName = x.Performer.Users.Select(u => u.UserName),
                            Fraction = /*x.Fraction*/(x.Feeling + x.Pronounce + x.Intonation + x.Performance + x.Progress),
                            TemaName = x.Performer.Team.Name,
                        })
                        .AsNoTracking()
                        .ToListAsync();
                    return View(list);
                }
                return View();
            }
            //else
            //    return Content("权限不足!!!");
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UserList()
        {
            var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
            if (await _db.User.AnyAsync(x => x.Id == uid && x.UserType.HasFlag(UserType.管理员)))
            {
                var users = _db.User.ToListAsync();
                return View(await users);
            }
            else
                return Content("权限不足!!!");
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateUser(int id)
        {
            var user = _db.User.Find(id);
            return View(user);
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateUser(int id, string name, string tel)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(tel))
                return Json(new
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Result = "名字和手机号不能为空！"
                });

            var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
            if (await _db.User.AnyAsync(x => x.Id == uid && x.UserType.HasFlag(UserType.管理员)))
            {
                //var user = db.User.Find(id);
                //user.UserName = name;
                //user.Phone = tel;
                _db.Entry(new User
                {
                    Id = id,
                    UserName = name,
                    Phone = tel
                }).State = EntityState.Modified;
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                    return Json(new
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Result = "修改成功！"
                    });
            }
            else
                return Json(new
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Result = "修改失败，权限不足！"
                });
            return Json(new
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Result = "修改失败！"
            });
        }

        /// <summary>
        /// 选手得票结果
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> PerformerTicketResult()
        {
            /*
             select b.Name as TeamName, a.*, (select count(*) from [dbo].[User_Performer] where PerformerId=a.Id) as Count from [dbo].[Performer] as a left join [dbo].[Team] as b on b.Id=a.TeamId left join [dbo].[User] as c on c.Performer_Id =a.Id
             */
            var sql = "select b.Name as TeamName, a.*, (select count(*) from [dbo].[User_Performer] where PerformerId=a.Id) as Count from [dbo].[Performer] as a left join [dbo].[Team] as b on b.Id=a.TeamId ";
            var queryResult = _db.Database.SqlQuery<PerformerTicketResultViewModel>(sql)/*.GroupBy(x=>x.TeamName)*/.OrderBy(x => x.Sort).ToList();
            queryResult.ForEach(async item =>
            {
                var users = _db.Performer.Find(item.Id).Users;
                var userName = string.Empty;
                if (string.IsNullOrEmpty(item.CombinationName))
                {
                    foreach (var user in users)
                    {
                        userName += user.UserName + "|";
                    }
                }
                else
                {
                    userName = item.CombinationName;
                }
                item.UserName = userName.Trim('|');
            });
            return View(queryResult);
        }

        /// <summary>
        /// 排名
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Ranking()
        {
            return View();
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        [Authorize]
        User _getLoginUser()
        {
            User user = default;
            if (Session[AnnualMeeting2020Key.SESSION_USER_KEY] == null)
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var uid = Convert.ToInt32(User.Identity.Name);
                user = _db.User.Find(uid);
            }
            else
            {
                user = Session[AnnualMeeting2020Key.SESSION_USER_KEY] as User;
            }
            return user;
        }
    }
}