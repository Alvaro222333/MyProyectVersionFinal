
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using USIP.Model;
namespace USIP.Data.Map
{
    internal class CourseSubjectMap : EntityTypeConfiguration<CourseSubject>
	{
		public CourseSubjectMap(string schema)
		{
			ToTable("MateriaEnCurso", schema);
			HasKey(p => p.Id);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(p => p.Id).HasColumnName("Llave").IsRequired();
			Property(p => p.IdSubject).HasColumnName("IdMateria").IsRequired();
			Property(p => p.IdCourse).HasColumnName("IdCurso").IsRequired();

			//HasRequired(p => p.Subject).WithMany().HasForeignKey(p => p.IdSubject);
			//HasRequired(p => p.Course).WithMany().HasForeignKey(p => p.IdCourse);
		}
	}
}
