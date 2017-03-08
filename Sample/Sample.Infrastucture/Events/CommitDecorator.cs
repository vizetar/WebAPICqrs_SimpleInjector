using Sample.Domain;
using Sample.Infrastucture.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Events
{
	public class CommitDecorator<TCommand> : ICommandHandler<TCommand>
	{
		private readonly ICommandHandler<TCommand> decorated;
		private readonly SampleDBContext dbcontext;

		public CommitDecorator(ICommandHandler<TCommand> decorated,SampleDBContext dbcontext)
		{
			this.decorated = decorated;
			this.dbcontext = dbcontext;
		}

		public async Task Handle(TCommand command)
		{
			await decorated.Handle(command);
			await dbcontext.SaveChangesAsync();
			//unitOfWork.Commit();
		}
	}
}
