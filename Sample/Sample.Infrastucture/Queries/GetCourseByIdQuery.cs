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
	public class GetByValueQuery : IQuery<CourseModel>
	{
		public string Value { get; set; }
	}
}
