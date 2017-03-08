using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
	public class Student
	{
		public Student()
		{
			Student_Course = new Course();
			Id = Guid.NewGuid().ToString();
		}

		public virtual string Id{ get; set; }

		public virtual string Name { get; set; }

		public virtual string RollNumber { get; set; }

		public virtual string CourseId { get; set; }

		public virtual Course Student_Course { get; set; }

		
	}
}
