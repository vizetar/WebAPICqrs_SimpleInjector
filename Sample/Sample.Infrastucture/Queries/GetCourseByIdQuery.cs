using Sample.Domain.Entities;
using Sample.Infrastucture.Bus;
using Sample.Infrastucture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastucture.Queries
{
	public class GetCourseByIdQuery : IQuery<CourseModel>
	{
		public string Id { get; set; }
	}
}
