using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FluentApiUniver.configurations
{
  public  class ProfessorBuilder : EntityTypeConfiguration<Profesor>
    {


        public ProfessorBuilder()
        {
            HasKey(p => p.ID)
                .Property(p => p.Name)
                .HasColumnName("ProfesorName")
                .HasMaxLength(255);



            Property(p => p.ID)
            .HasColumnName("profesorID")
            .HasColumnOrder(2);



            HasMany(p => p.GetCurs)
            .WithRequired(c => c.GetProfesor)
            .HasForeignKey(c => c.IDProfesor);



            HasMany(p => p.GetGrupas);
        }
    }
}

