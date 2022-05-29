
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using USIP.Model;

namespace USIP.Data.Map
{
    internal class CourseMap : EntityTypeConfiguration<Course>
	{
		public CourseMap(string schema)
		{
			ToTable("Curso", schema);
			HasKey(p => p.Id);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(p => p.Id).HasColumnName("Llave").IsRequired();
			Property(p => p.Name).HasColumnName("Nombre").IsRequired();
			Property(p => p.LimitStudent).HasColumnName("Limite").IsRequired();
		}

	}
}
