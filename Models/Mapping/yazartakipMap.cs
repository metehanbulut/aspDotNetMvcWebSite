using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class yazartakipMap : EntityTypeConfiguration<yazartakip>
    {
        public yazartakipMap()
        {
            // Primary Key
            this.HasKey(t => new { t.yazar_id, t.kullanici_id });

            // Properties
            this.Property(t => t.yazar_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.kullanici_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("yazartakip");
            this.Property(t => t.yazar_id).HasColumnName("yazar_id");
            this.Property(t => t.kullanici_id).HasColumnName("kullanici_id");

            // Relationships
            this.HasRequired(t => t.kullanici)
                .WithMany(t => t.yazartakips)
                .HasForeignKey(d => d.yazar_id);
            this.HasRequired(t => t.kullanici1)
                .WithMany(t => t.yazartakips1)
                .HasForeignKey(d => d.kullanici_id);
            this.HasRequired(t => t.kullanicix)
                .WithMany(t => t.yazartakips)
                .HasForeignKey(d => d.kullanici_id);

        }
    }
}
