using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMo.WebAPI.App_Start
{
    public class DependencyConfig
    {
        public static Autofac.IContainer RegisterDependencyResolvers()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterDependencies(builder);
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }

        public static void RegisterDependencies(ContainerBuilder builder)
        {

        }
    }
}