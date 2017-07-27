using Sample.Domain;
using Sample.Domain.Entities;
using Sample.Infrastucture.Commands;
using Sample.Infrastucture.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.CommandHandlers
{
	
		public class AddNewCourseCommandHandler : ICommandHandler<AddNewCourseCommand>
		{
			private readonly SampleDBContext dbcontext;
			private readonly IPostCommitEvent postCommitEvent;

			public AddNewCourseCommandHandler(SampleDBContext dbcontext, IPostCommitEvent postCommitEvent)
			{
				this.dbcontext = dbcontext;
				this.postCommitEvent = postCommitEvent;
			}

			public async Task Handle(AddNewCourseCommand command)
			{
				var newCourse = new Course
				{
					Name = command.Name,
					Duration = command.Duration
				};

				dbcontext.Set<Course>().Add(newCourse);
				postCommitEvent.PostCommit += () => command.CreatedCourseId = newCourse.Id;




			}
		}

		public class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand>
		{

		}
	
}
