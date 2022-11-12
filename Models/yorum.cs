using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class yorum
    {
        public int yorum_id { get; set; }
        public string yorum_icerik { get; set; }
        public int makale_id { get; set; }
        public System.DateTime yorum_tarih { get; set; }
        public string yorum_adsoyad { get; set; }
        public virtual makale makale { get; set; }
    }
}
