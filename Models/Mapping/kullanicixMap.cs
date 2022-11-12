using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class kullanicixMap : EntityTypeConfiguration<kullanicix>
    {
        public kullanicixMap()
        {
            // Primary Key
            this.HasKey(t => t.kullanici_id);

            // Properties
            this.Property(t => t.kullanici_adi)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.kullanici_sifre)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.kullanici_nick)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.kullanici_mail)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("kullanicix");
            this.Property(t => t.kullanici_id).HasColumnName("kullanici_id");
            this.Property(t => t.kullanici_adi).HasColumnName("kullanici_adi");
            this.Property(t => t.kullanici_sifre).HasColumnName("kullanici_sifre");
            this.Property(t => t.kullanici_nick).HasColumnName("kullanici_nick");
            this.Property(t => t.kullanici_mail).HasColumnName("kullanici_mail");
            this.Property(t => t.kullanici_cinsiyet).HasColumnName("kullanici_cinsiyet");
            this.Property(t => t.kullanici_dogum).HasColumnName("kullanici_dogum");
            this.Property(t => t.kullanici_kayit).HasColumnName("kullanici_kayit");
        }
    }
}
