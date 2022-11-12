using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proje.Models
{
    public partial class rol
    {
        public rol()
        {
            this.kullanicirols = new List<kullanicirol>();
        }

        public int rol_id { get; set; }

        [Required]
        public string rol_adi { get; set; }
        public virtual ICollection<kullanicirol> kullanicirols { get; set; }
    }
}
