using Autofac;
using Autofac.Integration.Mvc;
using Blogging.Controllers;
using System.Web.Mvc;


namespace Blogging.Models
{
    public static class AutoFac
    {
        public static IContainer Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();         //Register Generic repository
            builder.RegisterControllers(typeof(BlogsController).Assembly);                                              //Register BlogsController
            builder.RegisterType<ApplicationDbContext>();                                                               //Register ApplicationDbContext
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));                                   //Resolve Dependency

            return container;
        }
    }
}