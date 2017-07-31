using Repository.Pattern.UnitOfWork;
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
		private readonly IUnitOfWorkAsync _unitOfWorkAsync;

		public CommitDecorator(ICommandHandler<TCommand> decorated, IUnitOfWorkAsync unitOfWorkAsync)
		{
			this.decorated = decorated;
			this._unitOfWorkAsync = unitOfWorkAsync;
		}

		public async Task Handle(TCommand command)
		{
			await decorated.Handle(command);

			//if (_unitOfWorkAsync.Commit())
				await _unitOfWorkAsync.SaveChangesAsync();
			//else
			//	 _unitOfWorkAsync.Rollback();

			//unitOfWork.Commit();
		}
	}
}
