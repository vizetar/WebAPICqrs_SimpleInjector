using Sample.Infrastucture.CommandHandlers;
using SimpleInjector;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sample.Infrastucture.Bus
{
	public class CommandBus : ICommandBus
	{
		private readonly Container container;

		public CommandBus(Container container)
		{
			this.container = container;
		}

		public async Task Run<TCommand>(TCommand command)
		{
			var handlerinstance = container.GetAllInstances<ICommandHandler<TCommand>>();
			var handler = handlerinstance.FirstOrDefault();
			await handler.Handle(command);
		}
	}
}
