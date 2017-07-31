namespace Sample.Domain
{
	using Repository.Pattern.DataContext;
	using Repository.Pattern.Ef6;
	using Sample.Domain.Entities;
	using Sample.Domain.EntityMappers;
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class SampleDBContext : DataContext, IDisposable
	{
		// Your context has been configured to use a 'SampleDBContext' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'Sample.Domain.SampleDBContext' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'SampleDBContext' 
		// connection string in the application configuration file.
		public SampleDBContext()
			: base("name=SampleDBContext")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Course> Courses { get; set; }
		public virtual DbSet<Login> Login { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Moved all Student related configuration to StudentEntityConfiguration class
			modelBuilder.Configurations.Add(new StudentMapper());
			modelBuilder.Configurations.Add(new CourseMapper());
			modelBuilder.Configurations.Add(new LoginMapper());

		}
	}
}