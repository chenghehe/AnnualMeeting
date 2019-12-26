namespace AnnualMeeting2020.EntityFramwork.Migrations
{
    using AnnualMeeting2020.EntityFramwork.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

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
                new InitData().Send(context);
            }
        }

    }
}
