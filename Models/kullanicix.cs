using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class kullanicix
    {
        public kullanicix()
        {
            this.yazartakips = new List<yazartakip>();
        }

        public int kullanici_id { get; set; }
        public string kullanici_adi { get; set; }
        public string kullanici_sifre { get; set; }
        public string kullanici_nick { get; set; }
        public string kullanici_mail { get; set; }
        public Nullable<bool> kullanici_cinsiyet { get; set; }
        public System.DateTime kullanici_dogum { get; set; }
        public System.DateTime kullanici_kayit { get; set; }
        public virtual ICollection<yazartakip> yazartakips { get; set; }
    }
}
