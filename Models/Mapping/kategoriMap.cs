using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class kategoriMap : EntityTypeConfiguration<kategori>
    {
        public kategoriMap()
        {
            // Primary Key
            this.HasKey(t => t.kategori_id);

            // Properties
            this.Property(t => t.kategori_adi)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.kategori_aciklama)
                .IsFixedLength()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("kategori");
            this.Property(t => t.kategori_id).HasColumnName("kategori_id");
            this.Property(t => t.kategori_adi).HasColumnName("kategori_adi");
            this.Property(t => t.kategori_aciklama).HasColumnName("kategori_aciklama");
        }
    }
}
