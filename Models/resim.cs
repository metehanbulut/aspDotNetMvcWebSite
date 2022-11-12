using System;
using System.Collections.Generic;

namespace proje.Models
{
    public partial class resim
    {
        public resim()
        {
            this.makales = new List<makale>();
        }

        public int resim_id { get; set; }
        public string kucukboyut { get; set; }
        public string ortaboyut { get; set; }
        public string buyukboyut { get; set; }
        public string video { get; set; }
        public Nullable<int> makale_id { get; set; }
        public virtual ICollection<makale> makales { get; set; }
        public virtual makale makale { get; set; }
    }
}
