using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FluentApiUniver.configurations
{
    public class StudenBuilder : EntityTypeConfiguration<Student>
    {
        public StudenBuilder()
        {
            HasKey(i => i.ID);


            Property(n => n.Name)
            .HasColumnName("studentName")
            .HasMaxLength(255);



            Property(i => i.ID)
            .HasColumnOrder(2)
            .HasColumnName("idStudent");



            HasMany(s => s.GetCurs)
            .WithMany(c => c.GetStudents)
            .Map(m =>
            {
                m.MapLeftKey("cursID");
                m.MapRightKey("studentID");
                m.ToTable("StudentCUrses");
            });


            HasRequired(s => s.GetGrupa)
            .WithMany(g => g.GetStudents)
            .HasForeignKey(s => s.IDGrupa);


        }
    }
}
