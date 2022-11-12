using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class makaleMap : EntityTypeConfiguration<makale>
    {
        public makaleMap()
        {
            // Primary Key
            this.HasKey(t => t.makale_id);

            // Properties
            this.Property(t => t.makale_baslik)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.makale_icerik)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("makale");
            this.Property(t => t.makale_id).HasColumnName("makale_id");
            this.Property(t => t.makale_baslik).HasColumnName("makale_baslik");
            this.Property(t => t.makale_icerik).HasColumnName("makale_icerik");
            this.Property(t => t.makale_tarih).HasColumnName("makale_tarih");
            this.Property(t => t.makale_kategorid).HasColumnName("makale_kategorid");
            this.Property(t => t.makale_goruntulenme).HasColumnName("makale_goruntulenme");
            this.Property(t => t.makale_begeni).HasColumnName("makale_begeni");
            this.Property(t => t.makale_yazarid).HasColumnName("makale_yazarid");
            this.Property(t => t.resim_id).HasColumnName("resim_id");

            // Relationships
            this.HasRequired(t => t.kategori)
                .WithMany(t => t.makales)
                .HasForeignKey(d => d.makale_kategorid);
            this.HasRequired(t => t.kullanici)
                .WithMany(t => t.makales)
                .HasForeignKey(d => d.makale_yazarid);
            this.HasOptional(t => t.resim)
                .WithMany(t => t.makales)
                .HasForeignKey(d => d.resim_id);

        }
    }
}
