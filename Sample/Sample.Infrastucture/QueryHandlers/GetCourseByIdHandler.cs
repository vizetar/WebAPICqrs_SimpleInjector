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
using Repository.Pattern.Repositories;

namespace Sample.Infrastucture.QueryHandlers
{
	public class GetCourseByIdHandler : IQueryHandler<GetByValueQuery, CourseModel>
	{
		private readonly IRepositoryAsync<Course> _repository;

		public GetCourseByIdHandler(IRepositoryAsync<Course> repository) 
		{
			this._repository = repository;
		}

		public CourseModel Handle(GetByValueQuery query)
		{
			Course course = _repository.Find(query.Value);
			Mapper.Initialize(cfg => cfg.CreateMap<Course, CourseModel>());
			return Mapper.Map<CourseModel>(course);
		}
	}

}
