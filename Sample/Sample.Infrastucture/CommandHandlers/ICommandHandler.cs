using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.CommandHandlers
{
	public interface ICommandHandler<in TCommand>
	{
		 Task Handle(TCommand command);
	}
}
