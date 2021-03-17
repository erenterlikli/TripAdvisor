using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeyahatSitesi.Models.Sınıflar
{
    public class Yorum
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string YorumMesaji { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; } //blog tablosundan(classından) alınan blog adında bir değişken, yani onun id değeri yorum için gerekli.

        //virtual: her yorumda kendisi de bir blog sayfası ekliyor. Bunun önüne geçmek için kullandık.

    }
}