using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class etiketMap : EntityTypeConfiguration<etiket>
    {
        public etiketMap()
        {
            // Primary Key
            this.HasKey(t => t.etiket_id);

            // Properties
            this.Property(t => t.etiket_adi)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("etiket");
            this.Property(t => t.etiket_id).HasColumnName("etiket_id");
            this.Property(t => t.etiket_adi).HasColumnName("etiket_adi");

            // Relationships
            this.HasMany(t => t.makales)
                .WithMany(t => t.etikets)
                .Map(m =>
                    {
                        m.ToTable("makaleetiket");
                        m.MapLeftKey("etiket_id");
                        m.MapRightKey("makale_id");
                    });


        }
    }
}
