using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class kullanicirol
    {
        public int kullanicirol_id { get; set; }
        public int rol_id { get; set; }
        public int kullanici_id { get; set; }
        public virtual kullanici kullanici { get; set; }
        public virtual rol rol { get; set; }
    }
}
