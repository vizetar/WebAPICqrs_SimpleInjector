using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.EntityMappers
{
	public class CourseMapper : EntityTypeConfiguration<Course>
	{
		public CourseMapper()
		{
			this.ToTable("Course");
			this.HasKey<string>(c => c.Id);
			this.Property(c => c.Name).IsRequired();
			this.Property(c => c.Duration).IsRequired();

			
		}
	}
}
