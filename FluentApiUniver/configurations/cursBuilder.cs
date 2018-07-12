using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FluentApiUniver.configurations
{
    public class cursBuilder : EntityTypeConfiguration<Curs>
    {
        public cursBuilder()
        {

            Property(c => c.ID)
            .HasColumnName("cursID");


            Property(c => c.Name)
            .HasColumnName("cursName");

            HasMany(p => p.GetGrupas)
               .WithMany(g => g.GetCurses)
               .Map(m =>
               {
                   m.MapLeftKey("grupaID");
                   m.MapRightKey("cursID");
                   m.ToTable("CursGrupa");
               });
        }
    }
}
