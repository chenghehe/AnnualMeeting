using AnnualMeeting2020.EntityFramwork.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AnnualMeeting2020.EntityFramwork
{
    public class AnnualMeetingContext : DbContext
    {
        public AnnualMeetingContext()
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// 用户
        /// </summary>
        public IDbSet<User> User { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        public IDbSet<Performer> Performer { get; set; }

        /// <summary>
        /// 弹幕
        /// </summary>
        public IDbSet<Message> Message { get; set; }

        /// <summary>
        /// 组队表
        /// </summary>
        public IDbSet<Team> Team { get; set; }

        /// <summary>
        /// 评委评分
        /// </summary>
        public IDbSet<Judges_Performer> Judges_Performer { get; set; }

        /// <summary>
        /// 得分结果
        /// </summary>
        public IDbSet<MatchResult> MatchResult { get; set; }

        /// <summary>
        /// 投票表，多对多，中间表
        /// </summary>
        public IDbSet<User_Performer> User_Performer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ////添加唯一约束
            modelBuilder.Entity<User_Performer>().HasIndex(x => new
            {
                x.UserId,
                x.PerformerId,
            }).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => new
            {
                x.UserName,
                x.Phone,
            }).IsUnique();
            modelBuilder.Entity<Judges_Performer>().HasIndex(x => new
            {
                x.PerformerId,
                x.UserId,
            }).IsUnique();
            modelBuilder.Entity<MatchResult>().HasIndex(x => new
            {
                x.PerformerId,
            }).IsUnique();
        }
    }
}
