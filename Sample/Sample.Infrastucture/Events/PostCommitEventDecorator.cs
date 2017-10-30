using Sample.Infrastucture.CommandHandlers;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Events
{
	public class PostCommitEventDecorator<TCommand> : ICommandHandler<TCommand>
	{
		private readonly ICommandHandler<TCommand> decorated;
		private readonly PostCommitEvent postCommitEvent;

		public PostCommitEventDecorator(ICommandHandler<TCommand> decorated, PostCommitEvent postCommitEvent)
		{
			this.decorated = decorated;
			this.postCommitEvent = postCommitEvent;
		}

		public async Task Handle(TCommand command)
		{
			try
			{
				await decorated.Handle(command);
				postCommitEvent.Raise();
			}
			finally
			{
				postCommitEvent.Reset();
			}
		}
	}
}
