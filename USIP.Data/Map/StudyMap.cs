using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using USIP.Model;

namespace USIP.Data.Map
{
	public class StudyMap : EntityTypeConfiguration<Study>
	{
		public StudyMap(string schema)
		{
			ToTable("Estudia", schema);
			HasKey(p => p.Id);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(p => p.Id).HasColumnName("Llave").IsRequired();
			Property(p => p.IdStudent).HasColumnName("IdEstudiante").IsRequired();
			Property(p => p.IdCourse).HasColumnName("IdCurso").IsRequired();

			//HasRequired(p => p.Student).WithMany().HasForeignKey(p => p.IdStudent);
			//HasRequired(p => p.Career).WithMany().HasForeignKey(p => p.IdCareer);
		}
	}
}
