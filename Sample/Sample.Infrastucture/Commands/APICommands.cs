using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Commands
{
	public class AddNewCourseCommand
	{
		public string CreatedCourseId { get; set; }
		public string Name { get; set; }
		public string Duration { get; set; }
	}

	public class RegisterStudentCommand
	{
		public string CreatedStudentId { get; set; }
		public string Name { get; set; }
		public string RollNumber { get; set; }
		public string CourseId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string EmailId { get; set; }

	}
}
