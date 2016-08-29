using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcTest.Models.Entity;
using MvcTest.Models.Views;
using MvcTest.Repositories;
using Ninject;
using MvcTest.Common.Infrastructure;
using MvcTest.Models;
using MvcTest.Common.Consts;

namespace MvcTest.Controllers
{
    public class UploadsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public UploadsController()
        {
            LogedRequirement = true;
        }


        // GET: Uploads/Index/
        public ActionResult Index()
        {
            return RouteTo();
        }


        // GET: Uploads/ShowFiles
        public ActionResult ShowFiles()
        {
            try
            {
                IKernel kernel = Factory.CreateKernel();
                IFileRepository fileRepo = kernel.Get<IFileRepository>();
                FileViewModel model = new FileViewModel();
                if (Authorization.User.SuperAdmin)
                    model.UserFiles = fileRepo.GetAll();
                else
                    model.UserFiles = fileRepo.GetAllByUser(Authorization.User);
                return RouteTo(model);
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }


        // GET: Uploads/Add
        public ActionResult Add()
        {
            UploadViewModel model = new UploadViewModel();
            return RouteTo(model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newFile"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UploadViewModel newFile)
        {
            String path = String.Empty;
            bool added = false;
            try
            {
                var fileName = Path.GetFileName(newFile.UserFile.FileName);
                path = AppConst.FILES_STORE_LOCATION + fileName;
                // Attempting to add file to database
                IKernel kernel = Factory.CreateKernel();
                IFileRepository fileRepo = kernel.Get<IFileRepository>();

                UserFile file = new UserFile(Authorization.User);
                file.Name = path;
                file.Description = newFile.Description;
                newFile.UserFile.SaveAs(path);
                added = true;
                
                fileRepo.Add(file);
                return RouteTo(null, "ShowImages", "Uploads", true);
            }
            catch
            {
                if (added)
                    System.IO.File.Delete(path);
                HttpContext.Response.Cookies["UploadError"].Value = "True";
                HttpContext.Response.Cookies["UploadError"].Expires = DateTime.Now.AddSeconds(5);
                return RouteTo(null, "ShowImages", "Uploads", true);
            }
        }

        // GET: Uploads/Delete
        public ActionResult Delete(UserFile file)
        {
            try
            {
                IKernel kernel = Factory.CreateKernel();
                IFileRepository fileRepo = kernel.Get<IFileRepository>();
                if (Authorization.User.Id == file.UserId || Authorization.User.SuperAdmin)
                    fileRepo.Delete(file);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public FileContentResult Download(int? Id)
        {
            try
            {
                byte[] result = null;
                String fileName = String.Empty;
                String filePath = String.Empty;


                IKernel kernel = Factory.CreateKernel();
                IFileRepository fileRepo = kernel.Get<IFileRepository>();

                // Get file from repository
                UserFile file = fileRepo.GetById(Id);
                fileName = file.Name;

                // Create full path
                filePath = Path.Combine(AppConst.FILES_STORE_LOCATION, fileName);

                // Return data 
                result = System.IO.File.ReadAllBytes(filePath);
                return File(result, "application / octet - stream", fileName);
            }
            catch
            {
                RedirectToAction("Index");
                return null;
            }
        }
    }
}