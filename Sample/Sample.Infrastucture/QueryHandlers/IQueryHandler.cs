﻿using Sample.Infrastucture.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.QueryHandlers
{
	public interface IQueryHandler<in TQuery, out TResult>
		where TQuery : IQuery<TResult>
	{
		 TResult Handle(TQuery query);
	}
}
