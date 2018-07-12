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
            
               
               Property(n => n.Name)
               .HasColumnName("studentName")
               .HasMaxLength(255);

            
                
                Property(i => i.ID)
                .HasColumnName("idStudent");

            
                
                HasMany(s => s.GetCurs);

                
                HasRequired(s => s.GetGrupa)
                .WithMany(g => g.GetStudents)
                .HasForeignKey(s => s.IDGrupa);

        }
    }
}
