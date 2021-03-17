using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Sınıflar; //kütüphaneyi ekledik.

namespace SeyahatSitesi.Controllers
{
    public class AnaSayfaController : Controller
    {
        Context ct = new Context(); //ct veritabanı nesnesini de kullanacağız.

        public ActionResult Index()
        {
            var degerler = ct.Blogs.Take(5).ToList();
            return View(degerler);
        }

        public PartialViewResult Partial1() //Birinci ve ikinci blogları çekiyor.
        {
            var degerler2 = ct.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler2);
        }

        public PartialViewResult Partial2() //Top 10 listesi için.
        {
            var degerler3 = ct.Blogs.Take(10).ToList();
            return PartialView(degerler3);
        }
       
        public PartialViewResult Partial3() //En beğenilen yerler için
        {
            var degerler4 = ct.Blogs.Take(6).ToList();
            return PartialView(degerler4);
        }

       
    }
}