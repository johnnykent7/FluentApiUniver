using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FluentApiUniver.configurations
{
   public class grupaBuilder : EntityTypeConfiguration<Grupa>
    {
        public grupaBuilder()
        {
            HasKey(k=>k.ID);

            Property(i => i.ID)
                .HasColumnName("grupaID");

            Property(n => n.Nume)
                .HasMaxLength(255)
                .HasColumnName("grupaNume");
        }
    }
}
