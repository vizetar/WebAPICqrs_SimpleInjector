using Sample.Infrastucture.QueryHandlers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sample.Infrastucture.Bus
{
	public class QueryBus : IQueryBus
	{
		private readonly Container container;

		public QueryBus(Container container)
		{
			this.container = container;
		}

		public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
		{
			var handler = container.GetAllInstances<IQueryHandler<TQuery, TResponse>>();
			return handler.FirstOrDefault().Handle(query);
		}
	}
}
