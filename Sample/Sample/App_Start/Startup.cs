using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Sample.Infrastucture.Bus;
using Sample.Infrastucture.Events;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using System.Web.Http;
using System.Web.Mvc;
using Sample.Infrastucture;
using SimpleInjector.Extensions;
using Sample.Infrastucture.CommandHandlers;
using Sample.Domain;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Web.Routing;
using Sample.Infrastucture.QueryHandlers;

[assembly:OwinStartup(typeof(Sample.App_Start.Startup))]

namespace Sample.App_Start
{
	public partial class Startup
	{
		public static void Configuration(IAppBuilder app)
		{
			InitializeSimpleInjector();
			AreaRegistration.RegisterAllAreas();
			var httpConfiguration = CreateHttpConfiguration();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

		}

		public static HttpConfiguration CreateHttpConfiguration()
		{
			var config = new HttpConfiguration();
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.MapHttpAttributeRoutes();
			config.EnsureInitialized();
			return config;
		}

		public static void InitializeSimpleInjector()
		{
			var container = new Container();

			InitializeContainer(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
		}

		private static void InitializeContainer(Container container)
		{
			container.Register<IQueryBus, QueryBus>();

			container.RegisterCollection(typeof(IQueryHandler<,>), typeof(IQueryHandler<,>).Assembly);

			container.Register<ICommandBus, CommandBus>();

			container.RegisterCollection(typeof(ICommandHandler<>),  typeof(ICommandHandler<>).Assembly);
			container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CommitDecorator<>));
			container.RegisterDecorator(typeof(ICommandHandler<>), typeof(PostCommitEventDecorator<>));


			container.RegisterWebApiRequest<PostCommitEvent>();
			container.Register<IPostCommitEvent>(container.GetInstance<PostCommitEvent>);

			container.Register<SampleDBContext>(Lifestyle.Singleton);
			//container.Register<IRepository, DbContextRepository>();

			//container.Register<IUnitOfWork, DbContextUnitOfWork>();
		}
	}
}
