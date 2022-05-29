using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using USIP.Model;

namespace USIP.Data.Map
{
    public class SubjectMap : EntityTypeConfiguration<Subject>
	{
		public SubjectMap(string schema)
		{
			ToTable("Asignatura", schema);
			HasKey(p => p.Id);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(p => p.Id).HasColumnName("Llave").IsRequired();
			Property(p => p.Name).HasColumnName("Nombre").IsRequired();

		}
	}
}
