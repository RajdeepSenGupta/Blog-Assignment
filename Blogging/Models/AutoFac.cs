using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Blogging.Controllers;
using Autofac.Integration.Mvc;
using System.Web.Mvc;


namespace Blogging.Models
{
    public static class AutoFac
    {
        public static void Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();         //Register Generic repository
            builder.RegisterControllers(typeof(BlogsController).Assembly);                                              //Register BlogsController
            builder.RegisterType<ApplicationDbContext>();                                                               //Register ApplicationDbContext
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));                                   //Resolve Dependency
        }
    }
}