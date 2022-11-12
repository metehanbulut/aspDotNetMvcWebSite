using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class yazar
    {
        public yazar()
        {
            this.makales = new List<makale>();
            this.kullanicis = new List<kullanici>();
        }

        public int yazar_id { get; set; }
        public string yazar_adi { get; set; }
        public string yazar_soyadi { get; set; }
        public string yazar_mail { get; set; }
        public string yazar_aciklama { get; set; }
        public bool yazar_cinsiyet { get; set; }
        public Nullable<int> resim_id { get; set; }
        public virtual ICollection<makale> makales { get; set; }
        public virtual resim resim { get; set; }
        public virtual ICollection<kullanici> kullanicis { get; set; }
    }
}
