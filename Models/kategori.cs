using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class kategori
    {
        public kategori()
        {
            this.makales = new List<makale>();
        }

        public int kategori_id { get; set; }
        public string kategori_adi { get; set; }
        public string kategori_aciklama { get; set; }
        public virtual ICollection<makale> makales { get; set; }
    }
}
