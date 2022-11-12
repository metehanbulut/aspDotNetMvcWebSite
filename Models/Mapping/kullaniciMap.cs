using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class kullaniciMap : EntityTypeConfiguration<kullanici>
    {
        public kullaniciMap()
        {
            // Primary Key
            this.HasKey(t => t.kullanici_id);

            // Properties
            this.Property(t => t.kullanici_adi)
                .HasMaxLength(50);

            this.Property(t => t.sifre)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.kullaniciadi)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.kullanici_mail)
                .IsFixedLength()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("kullanici");
            this.Property(t => t.kullanici_id).HasColumnName("kullanici_id");
            this.Property(t => t.kullanici_adi).HasColumnName("kullanici_adi");
            this.Property(t => t.sifre).HasColumnName("sifre");
            this.Property(t => t.kullaniciadi).HasColumnName("kullaniciadi");
            this.Property(t => t.kullanici_mail).HasColumnName("kullanici_mail");
            this.Property(t => t.kullanici_cinsiyet).HasColumnName("kullanici_cinsiyet");
            this.Property(t => t.kullanici_dogum).HasColumnName("kullanici_dogum");
            this.Property(t => t.kullanici_kayit).HasColumnName("kullanici_kayit");
            this.Property(t => t.kullanici_resimid).HasColumnName("kullanici_resimid");
            this.Property(t => t.yazar).HasColumnName("yazar");
            this.Property(t => t.onaylandi).HasColumnName("onaylandi");
            this.Property(t => t.aktif).HasColumnName("aktif");
            this.Property(t => t.aciklama).HasColumnName("aciklama");
        }
    }
}
