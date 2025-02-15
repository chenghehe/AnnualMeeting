﻿using AnnualMeeting2020.Common;
using AnnualMeeting2020.EntityFramwork;
using AnnualMeeting2020.EntityFramwork.Models;
using AnnualMeeting2020.Web.Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AnnualMeetingContext _db;
        private readonly NPOIExcelHelper nPOIExcelHelper;

        public AdminController(AnnualMeetingContext db, NPOIExcelHelper nPOIExcelHelper)
        {
            _db = db;
            this.nPOIExcelHelper = nPOIExcelHelper;
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
                var list = await _db.Performer.Select(x => new SwitchOut
                {
                    Id = x.Id,
                    IdPerform = x.IdPerform,
                    ProgramName = x.ProgramName,
                    TeamName = x.Team.Name,
                    TeamId = x.TeamId,
                    Sort = x.Sort,
                    CombinationName = x.CombinationName,
                    UserName = x.Users.Select(u => u.UserName),
                }).OrderBy(x => x.Sort).AsNoTracking().ToListAsync();
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
                            x.Performer.Sort,
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
                        Sort = x.Sort,
                        UserName = x.Users.Select(u => u.UserName)
                    })
                    .Where(x => !x.IsSelect)
                    .OrderBy(x => x.Sort)
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
                        .Select(x => new JudgesOut
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
                        .Select(x => new Judges_PerformerOut
                        {
                            UserName = x.User.UserName,
                            CombinationName = x.Performer.CombinationName,
                            ProgramName = x.Performer.ProgramName,
                            PerformerUserName = x.Performer.Users.Select(u => u.UserName),
                            Fraction = /*x.Fraction*/(x.Feeling + x.Pronounce + x.Intonation + x.Performance + x.Progress),
                            Sort = x.Performer.Sort,
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
        public async Task<ActionResult> UserList(string searchText)
        {
            var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
            if (await _db.User.AnyAsync(x => x.Id == uid && x.UserType.HasFlag(UserType.管理员)))
            {
                var users = string.IsNullOrEmpty(searchText) ? _db.User.ToListAsync() : _db.User.Where(x => x.Phone.Contains(searchText) || x.UserName.Contains(searchText)).ToListAsync();
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
            var queryResult = _db.Database.SqlQuery<PerformerTicketResultOut>(sql)/*.GroupBy(x=>x.TeamName)*/.OrderBy(x => x.Sort).ToList();
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
        [AllowAnonymous]
        public async Task<ActionResult> Ranking(CancellationToken cancellationToke)
        {
            var rankModel = new RankingOut
            {
                Performers = await _db.Performer
                .AsNoTracking()
                .OrderByDescending(x => x.Score)
                .Select(x => new PerformerOut
                {
                    ProgramName = x.ProgramName,
                    CombinationName = x.CombinationName,
                    TeamName = x.Team.Name,
                    IdPerform = x.IdPerform,
                    Score = x.Score,
                    UserName = x.Users.Select(u => u.UserName),
                })
                .Take(3)
                .ToListAsync(cancellationToke),
                Teams = await _db.Team
                .OrderByDescending(x => x.Fraction)
                .Select(x => new TeamOut
                {
                    Name = x.Name,
                    Fraction = x.Fraction,
                })
                //.Take(3)
                .ToListAsync(cancellationToke)
            };
            return View(rankModel);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AddUser()
        {
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="tel">手机号</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(string name, string tel)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(tel))
            {
                return Json(new
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Result = "添加失败，必填项不能为空！",
                });
            }
            else
            {
                var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
                if (await _db.User.AnyAsync(x => x.Id == uid && x.UserType.HasFlag(UserType.管理员)))
                {
                    _db.User.Add(new User
                    {
                        UserName = name.Trim(),
                        Phone = tel.Trim(),
                    });
                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Json(new
                        {
                            StatusCode = HttpStatusCode.OK,
                            Result = "添加成功！",
                        });
                    }
                }
            }
            return Json(new
            {
                StatusCode = HttpStatusCode.BadGateway,
                Result = "添加失败！权限不足！",
            });
        }

        /// <summary>
        /// 各环节加分项
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AddFraction(CancellationToken cancellationToke)
        {
            var list = _db.Team/*.Where(x => !x.IsAdditionalFraction)*/.ToListAsync(cancellationToke);
            return View(await list);
        }

        /// <summary>
        /// 各环节加分项
        /// </summary>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFraction(int tid, /*double youAndMeSing,*/ double interaction)
        {
            var uid = Convert.ToInt32(HttpContext.User.Identity.Name);
            if (await _db.User.AnyAsync(x => x.Id == uid && x.UserType.HasFlag(UserType.管理员)))
            {
                var team = _db.Team.Find(tid);

                //team.YouAndMeSing = youAndMeSing;
                team.Interaction += interaction;
                team.IsAdditionalFraction = true;
                _db.Entry(team).State = EntityState.Modified;
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                    return Json(new
                    {
                        StatusCode = HttpStatusCode.OK,
                        Result = "修改成功！"
                    });
                return Json(new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = "修改失败！"
                });
            }
            return Json(new
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Result = "修改失败,权限不足！"
            });
        }

        /// <summary>
        /// 计算最终得分
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Calculation(CancellationToken cancellationToken)
        {
            try
            {
                #region 个人选手计算得分
                //用户总数
                var userCount = await _db.User.CountAsync(x => x.UserType == UserType.普通用户, cancellationToken);

                //选手表
                var performers = await _db.Performer.ToListAsync(cancellationToken);

                //评委表
                var judges_Performers = await _db.Judges_Performer.AsNoTracking().ToListAsync(cancellationToken);

                //用户投票表
                var user_Performers = await _db.User_Performer.AsNoTracking().ToListAsync(cancellationToken);

                foreach (var item in performers)
                {
                    //1.评委
                    var pwagv = judges_Performers
                        .Where(x => x.PerformerId == item.Id).Any() ? judges_Performers
                        .Where(x => x.PerformerId == item.Id)
                        .Average(x => (x.Feeling + x.Pronounce + x.Intonation + x.Performance + x.Progress)) : 0;
                    var pw = pwagv > 0 ? Convert.ToDouble(pwagv) * 0.6 : 0;

                    //2. 大众
                    var dzf = user_Performers
                        .Where(x => x.PerformerId == item.Id)
                        .DefaultIfEmpty()
                        .Count();
                    var dz = (userCount == 0 ? 0 : dzf / (userCount * 1.00)) * 100 * 0.35;
                    item.Score = item.FabulousFraction + pw + dz;
                    _db.Entry(item).State = EntityState.Modified;
                }
                await _db.SaveChangesAsync();
                #endregion

                #region 方队计算得分

                //方队
                var teams = await _db.Team.ToListAsync(cancellationToken);

                teams.ForEach(item =>
                {
                    Debug.WriteLine(item.Name);
                    //当前方队选手
                    var ps = performers.Where(x => x.TeamId == item.Id);
                    if (ps.Any())
                    {
                        //当前方队选手数量
                        var psCount = ps.DefaultIfEmpty().Count();

                        //得分1，1. 方队3位歌手/组合总分取平均值，占比70%
                        var scoreSum = ps.DefaultIfEmpty().Sum(x => x.Score);
                        var f1 = (psCount == 0 ? 0 : scoreSum / (psCount * 1.00)) * 0.7;

                        //最终得分
                        item.Fraction = item.Preliminaries + item.YouAndMeSing + item.Interaction + f1;
                        _db.Entry(item).State = EntityState.Modified;
                    }
                });
                await _db.SaveChangesAsync();
                #endregion
            }
            catch (Exception e)
            {
                return Content("操作失败！");
                //throw;
            }
            return Content("操作成功！");
        }

        /// <summary>
        /// 导出excl
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> Execl(CancellationToken cancellationToke)
        {
            var rankModel = new RankingOut
            {
                Performers = await _db.Performer
              .AsNoTracking()
              .OrderByDescending(x => x.Score)
              .Select(x => new PerformerOut
              {
                  ProgramName = x.ProgramName,
                  CombinationName = x.CombinationName,
                  TeamName = x.Team.Name,
                  IdPerform = x.IdPerform,
                  Score = x.Score,
                  UserName = x.Users.Select(u => u.UserName),
              })
              .ToListAsync(cancellationToke),

                Teams = await _db.Team
              .OrderByDescending(x => x.Fraction)
              .Select(x => new TeamOut
              {
                  Name = x.Name,
                  Fraction = x.Fraction,
              })
              .ToListAsync(cancellationToke)
            };

            //歌手得票
            var sql = "select b.Name as TeamName, a.*, (select count(*) from [dbo].[User_Performer] where PerformerId=a.Id) as Count from [dbo].[Performer] as a left join [dbo].[Team] as b on b.Id=a.TeamId ";
            var queryResult = _db.Database.SqlQuery<PerformerTicketResultOut>(sql)/*.GroupBy(x=>x.TeamName)*/.OrderBy(x => x.Count).ToList();
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


            //评委打分
            var judges_Performer = await _db.Judges_Performer
                        .Select(x => new JudgesOut
                        {
                            Name = x.User.UserName,
                            Fraction = (x.Feeling + x.Pronounce + x.Intonation + x.Performance + x.Progress),
                            ProgramName = x.Performer.ProgramName,
                            TeamName = x.Performer.Team.Name,
                            UserName = x.Performer.Users.Select(u => u.UserName),
                        })
                        .OrderByDescending(x => x.Fraction)
                        .ToListAsync(cancellationToke);


            nPOIExcelHelper.SimpleTableToExcel(nPOIExcelHelper.ToDataTable(queryResult, tableName: "歌手票数"), Path.Combine(@"D:\", "歌手票数.xlsx"));

            nPOIExcelHelper.SimpleTableToExcel(nPOIExcelHelper.ToDataTable(rankModel.Performers, tableName: "歌手得分"), Path.Combine(@"D:\", "歌手得分.xlsx"));

            nPOIExcelHelper.SimpleTableToExcel(nPOIExcelHelper.ToDataTable(rankModel.Teams, "方队得分"), Path.Combine(@"D:\", "方队得分.xlsx"));

            nPOIExcelHelper.SimpleTableToExcel(nPOIExcelHelper.ToDataTable(judges_Performer, "评委打分"), Path.Combine(@"D:\", "评委打分.xlsx"));

            return View(rankModel);
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