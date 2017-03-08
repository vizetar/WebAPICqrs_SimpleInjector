using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace Sample.App_Start
{
	public class SimpleInjectorDependencyResolver : System.Web.Mvc.IDependencyResolver,
													System.Web.Http.Dependencies.IDependencyResolver,
													System.Web.Http.Dependencies.IDependencyScope
	{
		public Container Container { get; private set; }
		public SimpleInjectorDependencyResolver(Container container)
		{
			if (container == null)
				throw new ArgumentNullException("container");
			this.Container = container;
		}

		public IDependencyScope BeginScope()
		{
			return this;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object GetService(Type serviceType)
		{
			if (!serviceType.IsAbstract && typeof(IController).IsAssignableFrom(serviceType))
				return this.Container.GetAllInstances(serviceType);
			return ((IServiceProvider)this.Container).GetService(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return this.Container.GetAllInstances(serviceType);
		}

		object IDependencyScope.GetService(Type serviceType)
		{
			return ((IServiceProvider)this.Container).GetService(serviceType);
		}

		IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
		{
			IServiceProvider provider = Container;
			Type collectiontype = typeof(IEnumerable<>).MakeGenericType(serviceType);
			var services = (IEnumerable<object>)provider.GetService(collectiontype);
			return services ?? Enumerable.Empty<object>();
		}
	}
}