using MvcTest.Models.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;

namespace MvcTest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MvcTest.Migrations.AppContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcTest.Migrations.AppContex context)
        {
            //  This method will be called after migrating to the latest version.
            var users = new List<User>
            {
              //  new User { FirstName = "Adam", Surname = "Nowak", Email = "admin@admin.pl", Password = "admin" }
            };

            users.ForEach(u => context.Users.AddOrUpdate(u));
            context.SaveChanges();
        }
    }
}
