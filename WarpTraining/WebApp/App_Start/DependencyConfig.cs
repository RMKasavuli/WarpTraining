using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApp.App_Start
{
	public class DependencyConfig 
	{

		public static void RegisterDependencies()
		{
			// Configure the IoC and DI container
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());
			builder.RegisterModule<AutofacWebTypesModule>();

			// Register Web Api controllers
			//builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// Change controller action parameter injection by changing web.config
			builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>().InstancePerRequest();

			// Inject properties into filter attributes
			builder.RegisterFilterProvider();

			// Register database context
			builder.Register<Library.Data.IDataContext>(c => new Library.Data.DatabaseContextSqlServer()).InstancePerRequest();

			// Register generics
			builder.RegisterGeneric(typeof(Library.Data.DataRepository<>)).As(typeof(Library.Data.IDataRepository<>)).InstancePerRequest();

			builder.RegisterType<Library.Services.Cache.MemoryCacheManager>().As<Library.Services.Cache.ICacheManager>().InstancePerRequest();
			builder.RegisterType<Library.Service.Common.PersonService>().As<Library.Service.Common.IPersonService>().InstancePerRequest();
            builder.RegisterType<Library.Service.Common.GroupService>().As<Library.Service.Common.IGroupService>().InstancePerRequest();

            // Create the object container and set the dependency resolver
            IContainer container = builder.Build();

			// Set the ASP.NET MVC resolver
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			// Set the Web Api resolver
			//GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}