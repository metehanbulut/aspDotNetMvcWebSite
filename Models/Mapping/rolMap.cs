using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class rolMap : EntityTypeConfiguration<rol>
    {
        public rolMap()
        {
            // Primary Key
            this.HasKey(t => t.rol_id);

            // Properties
            this.Property(t => t.rol_adi)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("rol");
            this.Property(t => t.rol_id).HasColumnName("rol_id");
            this.Property(t => t.rol_adi).HasColumnName("rol_adi");
        }
    }
}
