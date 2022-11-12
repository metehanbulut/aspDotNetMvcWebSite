using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using proje.Models.Mapping;

namespace proje.Models
{
    public partial class uzayblgContext : DbContext
    {
        static uzayblgContext()
        {
            Database.SetInitializer<uzayblgContext>(null);
        }

        public uzayblgContext()
            : base("Name=uzayblgContext")
        {
        }

        public DbSet<admin> admins { get; set; }
        public DbSet<etiket> etikets { get; set; }
        public DbSet<kategori> kategoris { get; set; }
        public DbSet<kullanici> kullanicis { get; set; }
        public DbSet<kullanicirol> kullanicirols { get; set; }
        public DbSet<kullanicix> kullanicixes { get; set; }
        public DbSet<makale> makales { get; set; }
        public DbSet<resim> resims { get; set; }
        public DbSet<rol> rols { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<yazartakip> yazartakips { get; set; }
        public DbSet<yorum> yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new adminMap());
            modelBuilder.Configurations.Add(new etiketMap());
            modelBuilder.Configurations.Add(new kategoriMap());
            modelBuilder.Configurations.Add(new kullaniciMap());
            modelBuilder.Configurations.Add(new kullanicirolMap());
            modelBuilder.Configurations.Add(new kullanicixMap());
            modelBuilder.Configurations.Add(new makaleMap());
            modelBuilder.Configurations.Add(new resimMap());
            modelBuilder.Configurations.Add(new rolMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new yazartakipMap());
            modelBuilder.Configurations.Add(new yorumMap());
        }
    }
}
