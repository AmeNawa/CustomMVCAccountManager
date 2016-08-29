using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Models.Entity;
using MvcTest.Migrations;
using System.IO;

namespace MvcTest.Repositories
{
    public class FileRepository : IFileRepository
    {
        private AppContex db = AppContex.GetInstance();


        /// <summary>
        /// Add file(name and path) to database
        /// </summary>
        /// <param name="userFile"></param>
        public void Add(UserFile userFile)
        {
            try
            {
                userFile.Name = Path.GetFileName(userFile.Name);
                db.UserFiles.Add(userFile);
                db.SaveChanges();
            }
            catch
            {
                db.Entry(db.UserFiles.First(e => e.Id == userFile.Id)).CurrentValues.SetValues(userFile);
            }

        }


        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="userFile"></param>
        public void Delete(UserFile userFile)
        {
            try
            {
                var tempFile = db.UserFiles.First(f => f.Id == userFile.Id);
                db.UserFiles.Remove(tempFile);
                db.SaveChanges();
            }
            catch
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserFile GetById(int? Id)
        {
            try
            {
                return db.UserFiles.First(u => u.Id == Id);
            }
            catch
            {
                return new UserFile();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserFile> GetAll()
        {
            try
            {
                return db.UserFiles.ToList();
            }
            catch
            {
                return new List<UserFile>();
            }
        }


        /// <summary>
        /// Return all files owned by certain user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<UserFile> GetAllByUser(User user)
        {
            try
            {
                return db.UserFiles.Where(f => f.UserId == user.Id).ToList();
            }
            catch
            {
                return new List<UserFile>();
            }
        }
    }
}