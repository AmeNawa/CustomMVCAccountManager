using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using MvcTest.Repositories;
using MvcTest.Models;
using MvcTest.Common.Secure;

namespace MvcTest.Common.Infrastructure
{
    public class RepositoryContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<ICrypt>().To<MD5Hash>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IFileRepository>().To<FileRepository>();
        }
    }
}