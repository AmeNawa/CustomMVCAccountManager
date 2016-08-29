using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Models.Entity;
using MvcTest.Repositories;
using MvcTest.Migrations;
using MvcTest.Common.Secure;
using Ninject;

namespace MvcTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppContex db = AppContex.GetInstance();

        /// <summary>
        /// If email exists in database, return true
        /// </summary>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        public bool ContainsEmail(string newEmail)
        {
            try
            {
                var temp = db.Users.First(d => d.Email == newEmail);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            try
            {
                return db.Users.ToList();
            }
            catch
            {
                return new List<User>();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            try
            {
                return db.Users.First(d => d.Id == id);
            }
            catch
            {
                return new User();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetByEmail(string email)
        {
            try
            {
                return db.Users.First(d => d.Email == email);
            }
            catch
            {
                return new User();
            }
        }


        /// <summary>
        /// Login and password verification
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean VerifyAccount(string email, string password)
        {
            try
            {
                if (email == String.Empty || password == String.Empty)
                    return false;

                IKernel kernel = Common.Infrastructure.Factory.CreateKernel();
                ICrypt md5Hash = kernel.Get<ICrypt>();
                return GetByEmail(email).Password == md5Hash.Encrypt(password);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Cannot create new account if the same email exists in database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool SignUp(string email)
        {
            return !(ContainsEmail(email));
        }


        /// <summary>
        /// Login validation
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignIn(string email, string password)
        {
            if (ContainsEmail(email))
            {
                IKernel kernel = Common.Infrastructure.Factory.CreateKernel();
                ICrypt md5Hash = kernel.Get<ICrypt>();
                User tempUser = GetByEmail(email);

                return tempUser.Password == password;
            }

            return false;
        }


        /// <summary>
        /// Dodaje nowego użytkownika do bazy
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void SignUp(User user)
        {
            IKernel kernel = Common.Infrastructure.Factory.CreateKernel();
            ICrypt md5Hash = kernel.Get<ICrypt>();
            user.Password = md5Hash.Encrypt(user.Password);
            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                db.Entry(db.Users.First(e => e.Id == user.Id)).CurrentValues.SetValues(user);
            }
        }
    }
}