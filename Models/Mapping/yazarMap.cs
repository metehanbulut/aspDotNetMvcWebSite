using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class yazarMap : EntityTypeConfiguration<yazar>
    {
        public yazarMap()
        {
            // Primary Key
            this.HasKey(t => t.yazar_id);

            // Properties
            this.Property(t => t.yazar_adi)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.yazar_soyadi)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.yazar_mail)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.yazar_aciklama)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("yazar");
            this.Property(t => t.yazar_id).HasColumnName("yazar_id");
            this.Property(t => t.yazar_adi).HasColumnName("yazar_adi");
            this.Property(t => t.yazar_soyadi).HasColumnName("yazar_soyadi");
            this.Property(t => t.yazar_mail).HasColumnName("yazar_mail");
            this.Property(t => t.yazar_aciklama).HasColumnName("yazar_aciklama");
            this.Property(t => t.yazar_cinsiyet).HasColumnName("yazar_cinsiyet");
            this.Property(t => t.resim_id).HasColumnName("resim_id");

            // Relationships
            this.HasOptional(t => t.resim)
                .WithMany(t => t.yazars)
                .HasForeignKey(d => d.resim_id);

        }
    }
}
