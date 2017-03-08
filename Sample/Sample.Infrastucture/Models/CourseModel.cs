using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Models
{
	public class CourseModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Duration { get; set; }

		public ICollection<StudentModel> StudentList { get; set; }

	}
}
