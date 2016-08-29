using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Common.Secure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcTest.Common.Consts;
using MvcTest.Models.Entity;

namespace MvcTest.Models.Entity
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Changable only from database, if true, then user can show all files from database in Uploads/ShowFiles
        /// </summary>
        public Boolean SuperAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [EmailAddress(ErrorMessage = "E-mail format is not correct.")]
        public string Email { get; set; }
        
        /// <summary>
        /// File list
        /// </summary>
        public virtual ICollection<UserFile> Files { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        private string password;
        [Required]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public User()
        {
            SuperAdmin = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public String GetFullName()
        {
            return FirstName + " " + Surname;
        }

    }
}