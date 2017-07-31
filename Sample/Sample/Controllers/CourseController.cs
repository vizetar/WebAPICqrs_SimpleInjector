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
		public IHttpActionResult GetById([FromUri]GetByValueQuery query)
		{
			var result =  querybus.Query<GetByValueQuery, CourseModel>(query);
			return Ok(result);
		}

		[HttpPut]
		[Route("")]
		public async Task<IHttpActionResult> Put([FromBody]AddNewCourseCommand coursecommand)
		{
			await commandbus.Run(coursecommand);
			return Ok(coursecommand.CreatedCourseId);
		}

		[HttpPost]
		[Route("")]
		public async Task<IHttpActionResult> Post([FromBody]ModifyCourseCommand coursecommand)
		{
			await commandbus.Run(coursecommand);
			return Ok();
		}

		[HttpDelete]
		[Route("{Id}")]
		public async Task<IHttpActionResult> Delete([FromUri]String Id)
		{
			//String value = Id;
			await commandbus.Run(Id);
			return Ok();
		}




	}
}