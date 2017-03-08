using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.EntityMappers
{
	public class StudentMapper : EntityTypeConfiguration<Student>
	{
		public StudentMapper()
		{
			this.ToTable("Student");
			this.HasKey<string>(s => s.Id);
			this.Property(s => s.Name).IsRequired().HasMaxLength(100);
			this.Property(s => s.RollNumber).IsRequired().HasMaxLength(150);
			this.Property(s => s.CourseId).IsOptional();
			this.HasOptional(x => x.Student_Course)
						.WithMany(x => x.StudentList)
						.HasForeignKey(x => x.CourseId);


		}
	}
}
