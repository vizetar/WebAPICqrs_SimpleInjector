using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Models
{
	public class StudentModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string RollNumber { get; set; }

		public string CourseId { get; set; }

		public Course Student_Course { get; set; }
	}
}
