using Sample.Infrastucture.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.Controllers
{
	[RoutePrefix("api/student")]
	public class StudentController : ApiController
    {
		private readonly ICommandBus commandbus;
		private readonly IQueryBus querybus;
		public StudentController(ICommandBus commandbus, IQueryBus querybus)
		{
			this.commandbus = commandbus;
			this.querybus = querybus;
		}
	}
}
