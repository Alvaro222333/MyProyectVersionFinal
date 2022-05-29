using System.Data.Entity;
using USIP.Data.Map;

namespace USIP.Data.Context
{
	public class BaseContext : DbContext
	{
		private readonly string schema;

		public BaseContext()
			: base("name=SqlContext")
		{
			schema = "dbo";
			Database.SetInitializer(new CreateDatabaseIfNotExists<BaseContext>());
			SetConnectionString();
		}

		private void SetConnectionString()
		{
			Database.Connection.ConnectionString
				= @"Data Source=DESKTOP-KJSI0T8;Initial Catalog=Escuela;Integrated Security=True";
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			builder.Configurations.Add(new StudentMap(schema));
			builder.Configurations.Add(new TeacherMap(schema));
			builder.Configurations.Add(new CourseMap(schema));
			builder.Configurations.Add(new SubjectMap(schema));
			builder.Configurations.Add(new CourseSubjectMap(schema));
			builder.Configurations.Add(new StudyMap(schema));
		}
	}
}
