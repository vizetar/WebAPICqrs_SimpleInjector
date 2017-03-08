using Sample.Infrastucture;
using Sample.Infrastucture.Bus;
using Sample.Infrastucture.Commands;
using Sample.Infrastucture.Models;
using Sample.Infrastucture.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample.Controllers
{
	[RoutePrefix("api/course")]
	public class CourseController : ApiController
	{
		private readonly ICommandBus commandbus;
		private readonly IQueryBus querybus;
		public CourseController(ICommandBus commandbus, IQueryBus querybus)
		{
			this.commandbus = commandbus;
			this.querybus = querybus;
		}

		[HttpGet]
		[Route("{Id}")]
		public IHttpActionResult GetById([FromUri]GetCourseByIdQuery query)
		{
			var result =  querybus.Query<GetCourseByIdQuery, CourseModel>(query);
			return Ok(result);
		}

		[HttpPost]
		[Route("")]
		public async Task<IHttpActionResult> Add([FromBody]AddNewCourseCommand coursecommand)
		{
			await commandbus.Run(coursecommand);
			var result = new CourseModel
			{
				Id = coursecommand.CreatedCourseId,
				Name = coursecommand.Name,
				Duration = coursecommand.Duration
			};

			return Ok(result);
		}


	}
}