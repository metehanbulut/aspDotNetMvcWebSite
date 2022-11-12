using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class etiket
    {
        public etiket()
        {
            this.makales = new List<makale>();
        }

        public int etiket_id { get; set; }
        public string etiket_adi { get; set; }
        public virtual ICollection<makale> makales { get; set; }
    }
}
