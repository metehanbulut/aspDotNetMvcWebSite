using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class kullanicirolMap : EntityTypeConfiguration<kullanicirol>
    {
        public kullanicirolMap()
        {
            // Primary Key
            this.HasKey(t => new { t.rol_id, t.kullanici_id });

            // Properties
            this.Property(t => t.kullanicirol_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.rol_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.kullanici_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("kullanicirol");
            this.Property(t => t.kullanicirol_id).HasColumnName("kullanicirol_id");
            this.Property(t => t.rol_id).HasColumnName("rol_id");
            this.Property(t => t.kullanici_id).HasColumnName("kullanici_id");

            // Relationships
            this.HasRequired(t => t.kullanici)
                .WithMany(t => t.kullanicirols)
                .HasForeignKey(d => d.kullanici_id);
            this.HasRequired(t => t.rol)
                .WithMany(t => t.kullanicirols)
                .HasForeignKey(d => d.rol_id);

        }
    }
}
