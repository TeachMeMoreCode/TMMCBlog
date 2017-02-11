[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GamingGuruBlog.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GamingGuruBlog.Web.App_Start.NinjectWebCommon), "Stop")]

namespace GamingGuruBlog.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Domain.Interfaces;
    using Data.Repositories;
    using Domain;
    using Domain.Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<IBlogPostRepository>().To<BlogPostRepository>();
            kernel.Bind<IBlogCategoryRepository>().To<BlogCategoryRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IStaticPageRepository>().To<StaticPageRepository>();
            kernel.Bind<IBlogTagRepository>().To<BlogTagRepository>();
            kernel.Bind<IBlogServices>().To<BlogServices>();
            kernel.Bind<IStaticPageServices>().To<StaticPageServices>();
            kernel.Bind<ICategoryServices>().To<CategoryServices>();
            kernel.Bind<IUserServices>().To<UserServices>();
        }
    }
}
