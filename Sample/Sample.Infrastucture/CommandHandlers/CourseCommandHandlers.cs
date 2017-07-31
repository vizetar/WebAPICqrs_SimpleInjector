using Sample.Domain;
using Sample.Domain.Entities;
using Sample.Infrastucture.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Infrastucture.Events;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Sample.Infrastucture.CommandHandlers
{
	public class CourseCommandHandlers : ICommandHandler<AddNewCourseCommand> , ICommandHandler<ModifyCourseCommand> , ICommandHandler<String>
	{
		//private readonly SampleDBContext dbcontext;
		private readonly IPostCommitEvent postCommitEvent;
		private readonly IRepositoryAsync<Course> _repository;

		public CourseCommandHandlers(IPostCommitEvent postCommitEvent, IRepositoryAsync<Course> repository)
		{
			//this.dbcontext = dbcontext;
			this.postCommitEvent = postCommitEvent;
			this._repository = repository;
		}

		public async Task Handle(AddNewCourseCommand command)
		{
			var entity = new Course
			{
				Name = command.Name,
				Duration = command.Duration
			};
			entity.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
			_repository.Insert(entity);

			postCommitEvent.PostCommit += () => command.CreatedCourseId = entity.Id ;
			
		}

		public async Task Handle(ModifyCourseCommand command)
		{
			Course entity = await _repository.FindAsync(command.CourseId);
			entity.Name = command.Name;
			entity.Duration = command.Duration;
			entity.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
			_repository.Update(entity);

			//postCommitEvent.PostCommit += () => command.CreatedCourseId = newCourse.Id;

		}

		public async Task Handle(String command)
		{
			await _repository.DeleteAsync(command);

		}

	}
}
