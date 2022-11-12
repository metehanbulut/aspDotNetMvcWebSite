using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace proje.Models.Mapping
{
    public class resimMap : EntityTypeConfiguration<resim>
    {
        public resimMap()
        {
            // Primary Key
            this.HasKey(t => t.resim_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("resim");
            this.Property(t => t.resim_id).HasColumnName("resim_id");
            this.Property(t => t.kucukboyut).HasColumnName("kucukboyut");
            this.Property(t => t.ortaboyut).HasColumnName("ortaboyut");
            this.Property(t => t.buyukboyut).HasColumnName("buyukboyut");
            this.Property(t => t.video).HasColumnName("video");
            this.Property(t => t.makale_id).HasColumnName("makale_id");

            // Relationships
            this.HasOptional(t => t.makale)
                .WithMany(t => t.resims)
                .HasForeignKey(d => d.makale_id);

        }
    }
}
