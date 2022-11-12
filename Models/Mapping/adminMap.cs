using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class adminMap : EntityTypeConfiguration<admin>
    {
        public adminMap()
        {
            // Primary Key
            this.HasKey(t => t.admin_id);

            // Properties
            this.Property(t => t.admin_ka)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.admin_sf)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("admin");
            this.Property(t => t.admin_id).HasColumnName("admin_id");
            this.Property(t => t.admin_ka).HasColumnName("admin_ka");
            this.Property(t => t.admin_sf).HasColumnName("admin_sf");
        }
    }
}
