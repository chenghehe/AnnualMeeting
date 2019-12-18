namespace AnnualMeeting2020.EntityFramwork.Migrations
{
    using AnnualMeeting2020.EntityFramwork.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnnualMeeting2020.EntityFramwork.AnnualMeetingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AnnualMeeting2020.EntityFramwork.AnnualMeetingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var user = context.User.FirstOrDefault();
            if (user == null)
            {
                var t1 = context.Team.Add(new Team
                {
                    Name = "方块一队",
                });
                var t2 = context.Team.Add(new Team
                {
                    Name = "方块二队",
                });
                var t3 = context.Team.Add(new Team
                {
                    Name = "方块三队",
                });
                var t4 = context.Team.Add(new Team
                {
                    Name = "方块四队",
                });
                var t5 = context.Team.Add(new Team
                {
                    Name = "方块五队",
                });
                var user1 = new User { UserName = "一号演员", Phone = "123456789" };
                var user2 = new User { UserName = "二号演员", Phone = "123456895" };
                var user3 = new User { UserName = "三号演员", Phone = "12345659559" };
                var user4 = new User { UserName = "四号演员", Phone = "12345609559" };
                var user5 = new User { UserName = "五号演员", Phone = "12345629559" };
                var user6 = new User { UserName = "六号演员", Phone = "12345649559" };
                var user7 = new User { UserName = "七号演员", Phone = "12345969559" };
                var user8 = new User { UserName = "八号演员", Phone = "12345379559" };
                var user9 = new User { UserName = "九号演员", Phone = "12345959559" };
                context.User.Add(new User { UserName = "一号观众", Phone = "1388888888" });
                context.User.Add(new User { UserName = "二号观众", Phone = "1398888888" });
                context.User.Add(new User { UserName = "三号观众", Phone = "1368888888" });
                context.User.Add(new User { UserName = "四号观众 ", Phone = "1358888888" });
                context.User.Add(new User { UserName = "五号观众 ", Phone = "1348888888" });
                context.User.Add(new User
                {
                    UserName = "admin ",
                    Phone = "jjck123",
                    UserType = UserType.管理员,
                    TicketCount = int.MaxValue
                });

                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user1 },
                    ProgramName = "喜羊羊",
                    Team = t1
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user2, user3 },
                    ProgramName = "青青草原",
                    Team = t2
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user4, user5 },
                    ProgramName = "青青草原",
                    Team = t2,
                    CombinationName = "组合一",
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user9, user8 },
                    ProgramName = "十年",
                    Team = t3
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user7 },
                    ProgramName = "平凡之路",
                    Team = t3,
                    CombinationName = "组合二",
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user6 },
                    ProgramName = "最后的我们",
                    Team = t4
                });
            }
        }
    }
}
