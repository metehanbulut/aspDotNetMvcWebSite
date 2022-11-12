using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class kullanici
    {
        public kullanici()
        {
            this.kullanicirols = new List<kullanicirol>();
            this.makales = new List<makale>();
            this.yazartakips = new List<yazartakip>();
            this.yazartakips1 = new List<yazartakip>();
        }

        public int kullanici_id { get; set; }
        public string kullanici_adi { get; set; }
        public string sifre { get; set; }
        public string kullaniciadi { get; set; }
        public string kullanici_mail { get; set; }
        public Nullable<bool> kullanici_cinsiyet { get; set; }
        public Nullable<System.DateTime> kullanici_dogum { get; set; }
        public Nullable<System.DateTime> kullanici_kayit { get; set; }
        public Nullable<int> kullanici_resimid { get; set; }
        public Nullable<bool> yazar { get; set; }
        public Nullable<bool> onaylandi { get; set; }
        public Nullable<bool> aktif { get; set; }
        public string aciklama { get; set; }
        public virtual ICollection<kullanicirol> kullanicirols { get; set; }
        public virtual ICollection<makale> makales { get; set; }
        public virtual ICollection<yazartakip> yazartakips { get; set; }
        public virtual ICollection<yazartakip> yazartakips1 { get; set; }
    }
}
