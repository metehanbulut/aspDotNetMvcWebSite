using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class yazartakip
    {
        public int yazar_id { get; set; }
        public int kullanici_id { get; set; }
        public virtual kullanici kullanici { get; set; }
        public virtual kullanici kullanici1 { get; set; }
        public virtual kullanicix kullanicix { get; set; }
    }
}
