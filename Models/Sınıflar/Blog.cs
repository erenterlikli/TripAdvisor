using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeyahatSitesi.Models.Sınıflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogFoto { get; set; }
        public ICollection<Yorum> Yorums { get; set; } //bire çok ilişki, bu bloga birden fazla yorum gelebilir ve bunlar koleksiyon olarak tutuluyor.
    }
}