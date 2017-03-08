using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.EntityMappers
{
	public class LoginMapper : EntityTypeConfiguration<Login>
	{
		public LoginMapper()
		{
			this.ToTable("Login");
			this.HasKey<string>(l => l.Id);
			this.Property(l => l.Username).IsRequired().HasMaxLength(8);
			this.Property(l => l.Password).IsRequired().HasMaxLength(8);
			this.Property(l => l.EmailId).IsRequired();
			this.Property(l => l.StudentId).IsRequired();
		}
	}
}
