using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Bus
{
	public interface ICommandBus
	{
		Task Run<TCommand>(TCommand command);
	}
}
