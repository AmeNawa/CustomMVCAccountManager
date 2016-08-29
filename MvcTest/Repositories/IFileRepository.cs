using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTest.Models.Entity;

namespace MvcTest.Repositories
{
    public interface IFileRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<UserFile> GetAll();


        /// <summary>
        /// Return all files owned by certain user
        /// </summary>
        /// <returns></returns>
        List<UserFile> GetAllByUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserFile GetById(int? Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFile"></param>
        void Add(UserFile userFile);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userFile"></param>
        void Delete(UserFile userFile);
    }
}
