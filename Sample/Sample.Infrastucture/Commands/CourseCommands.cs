using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Commands
{
	public class CourseCommand
	{
		public string Name { get; set; }
		public string Duration { get; set; }
	}
	public class AddNewCourseCommand : CourseCommand
	{
		public string CreatedCourseId { get; set; }
	}

	public class ModifyCourseCommand : CourseCommand
	{
		public string CourseId { get; set; }
	}
}
