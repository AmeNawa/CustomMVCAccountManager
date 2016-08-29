using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Models.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace MvcTest.Migrations
{
    public class AppContex : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        private static AppContex _instance;


        /// <summary>
        /// Alawys return same instance, ctor cannot be private
        /// </summary>
        /// <returns></returns>
        public static AppContex GetInstance()
        {
            if (_instance == null)
                return _instance = new AppContex();

            else return _instance;
        }
    }
}