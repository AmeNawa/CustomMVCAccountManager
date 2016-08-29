using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Models.Entity;

namespace MvcTest.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User GetById(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<User> GetAll();


        /// <summary>
        ///
        /// </summary>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        Boolean ContainsEmail(string newEmail);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetByEmail(string email);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Boolean VerifyAccount(string email, string password);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignIn(string email, string password);


        /// <summary>
        /// Sign up validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool SignUp(string email);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        void SignUp(User user);
    }
}
