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
                    Name = "����һ��",
                });
                var t2 = context.Team.Add(new Team
                {
                    Name = "�������",
                });
                var t3 = context.Team.Add(new Team
                {
                    Name = "��������",
                });
                var t4 = context.Team.Add(new Team
                {
                    Name = "�����Ķ�",
                });
                var t5 = context.Team.Add(new Team
                {
                    Name = "�������",
                });
                var user1 = new User { UserName = "һ����Ա", Phone = "123456789" };
                var user2 = new User { UserName = "������Ա", Phone = "123456895" };
                var user3 = new User { UserName = "������Ա", Phone = "12345659559" };
                var user4 = new User { UserName = "�ĺ���Ա", Phone = "12345609559" };
                var user5 = new User { UserName = "�����Ա", Phone = "12345629559" };
                var user6 = new User { UserName = "������Ա", Phone = "12345649559" };
                var user7 = new User { UserName = "�ߺ���Ա", Phone = "12345969559" };
                var user8 = new User { UserName = "�˺���Ա", Phone = "12345379559" };
                var user9 = new User { UserName = "�ź���Ա", Phone = "12345959559" };
                context.User.Add(new User { UserName = "һ�Ź���", Phone = "1388888888" });
                context.User.Add(new User { UserName = "���Ź���", Phone = "1398888888" });
                context.User.Add(new User { UserName = "���Ź���", Phone = "1368888888" });
                context.User.Add(new User { UserName = "�ĺŹ��� ", Phone = "1358888888" });
                context.User.Add(new User { UserName = "��Ź��� ", Phone = "1348888888" });
                context.User.Add(new User
                {
                    UserName = "admin ",
                    Phone = "jjck123",
                    UserType = UserType.����Ա,
                    TicketCount = int.MaxValue
                });

                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user1 },
                    ProgramName = "ϲ����",
                    Team = t1
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user2, user3 },
                    ProgramName = "�����ԭ",
                    Team = t2
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user4, user5 },
                    ProgramName = "�����ԭ",
                    Team = t2,
                    CombinationName = "���һ",
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user9, user8 },
                    ProgramName = "ʮ��",
                    Team = t3
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user7 },
                    ProgramName = "ƽ��֮·",
                    Team = t3,
                    CombinationName = "��϶�",
                });
                context.Performer.Add(new Performer
                {
                    Users = new List<User> { user6 },
                    ProgramName = "��������",
                    Team = t4
                });
            }
        }
    }
}
