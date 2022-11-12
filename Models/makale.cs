using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class makale
    {
        public makale()
        {
            this.resims = new List<resim>();
            this.yorums = new List<yorum>();
            this.etikets = new List<etiket>();
        }

        public int makale_id { get; set; }
        public string makale_baslik { get; set; }
        public string makale_icerik { get; set; }
        public System.DateTime makale_tarih { get; set; }
        public int makale_kategorid { get; set; }
        public int makale_goruntulenme { get; set; }
        public int makale_begeni { get; set; }
        public int makale_yazarid { get; set; }
        public Nullable<int> resim_id { get; set; }
        public virtual kategori kategori { get; set; }
        public virtual kullanici kullanici { get; set; }
        public virtual resim resim { get; set; }
        public virtual ICollection<resim> resims { get; set; }
        public virtual ICollection<yorum> yorums { get; set; }
        public virtual ICollection<etiket> etikets { get; set; }
    }
}
