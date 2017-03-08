using Sample.Domain;
using Sample.Domain.Entities;
using Sample.Infrastucture.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sample.Infrastucture.Models;
using AutoMapper;

namespace Sample.Infrastucture.QueryHandlers
{
	public class GetCourseByIdHandler : IQueryHandler<GetCourseByIdQuery, CourseModel>
	{
		private readonly SampleDBContext dbcontext;

		public GetCourseByIdHandler(SampleDBContext dbcontext)
		{
			this.dbcontext = dbcontext;
		}

		public CourseModel Handle(GetCourseByIdQuery query)
		{
			Course course = dbcontext.Courses.Find(query.Id);
			Mapper.Initialize(cfg => cfg.CreateMap<Course, CourseModel>());
			return Mapper.Map<CourseModel>(course);
		}
	}

}
