using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class yorumMap : EntityTypeConfiguration<yorum>
    {
        public yorumMap()
        {
            // Primary Key
            this.HasKey(t => t.yorum_id);

            // Properties
            this.Property(t => t.yorum_icerik)
                .IsRequired();

            this.Property(t => t.yorum_adsoyad)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("yorum");
            this.Property(t => t.yorum_id).HasColumnName("yorum_id");
            this.Property(t => t.yorum_icerik).HasColumnName("yorum_icerik");
            this.Property(t => t.makale_id).HasColumnName("makale_id");
            this.Property(t => t.yorum_tarih).HasColumnName("yorum_tarih");
            this.Property(t => t.yorum_adsoyad).HasColumnName("yorum_adsoyad");

            // Relationships
            this.HasRequired(t => t.makale)
                .WithMany(t => t.yorums)
                .HasForeignKey(d => d.makale_id);

        }
    }
}
