using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using USIP.Model;

namespace USIP.Data.Map
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
	{
		public TeacherMap(string schema)
		{
			ToTable("Profesor", schema);
			HasKey(p => p.Id);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(p => p.Id).HasColumnName("Llave").IsRequired();
			Property(p => p.Name).HasColumnName("Nombre").IsRequired();
			Property(p => p.LastName).HasColumnName("Apellidos").IsRequired();
			Property(p => p.YearExperience).HasColumnName("Experiencia").IsRequired();
		}

	}
}
