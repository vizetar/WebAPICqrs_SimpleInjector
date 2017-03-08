using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sample.Domain.Entities
{
	public class Course 
	{
		public Course()
		{
			StudentList = new HashSet<Student>();
			Id = Guid.NewGuid().ToString();
		}

		public string Id { get; set; }

		public string Name { get; set; }

		public string Duration { get; set; }

		public ICollection<Student> StudentList { get; set; }
	}
}
