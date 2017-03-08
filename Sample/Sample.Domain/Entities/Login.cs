using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Entities
{
	public class Login 
	{
		public Login()
		{
			Student = new Student();
			Id = Guid.NewGuid().ToString();
		}

		public virtual string Id { get; set; }

		[ForeignKey("Student")]
		public virtual string StudentId { get; set; }

		public virtual string Username { get; set; }

		public virtual string Password { get; set; }

		public virtual string EmailId { get; set; }

		public virtual Student Student { get; set; }
	}
}
