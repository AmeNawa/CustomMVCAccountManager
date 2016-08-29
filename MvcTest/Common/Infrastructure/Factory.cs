using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;

namespace MvcTest.Common.Infrastructure
{
    public class Factory
    {
        private static IKernel kernel;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IKernel CreateKernel()
        {
            if (kernel == null)
            {
                var modules = new INinjectModule[]
                {
                    new RepositoryContainer()
                };

                kernel = new StandardKernel(modules);
            }

            return kernel;
        }
    }
}