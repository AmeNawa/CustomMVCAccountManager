using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models.Entity
{
    public class UserFile
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public UserFile()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public UserFile(User user)
        {
            User = user;
            UserId = user.Id;
        }
    }
}