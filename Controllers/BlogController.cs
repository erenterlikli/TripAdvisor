using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Sınıflar;

namespace SeyahatSitesi.Controllers
{
    public class BlogController : Controller
    {
        Context ct = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            by.Deger1 = ct.Blogs.ToList();
            by.Deger3 = ct.Blogs.OrderByDescending(x => x.ID).Take(3).ToList(); //Son eklenen 3 blogu listele
           // var bloglar = ct.Blogs.ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = ct.Blogs.Where(x => x.ID == id).ToList(); //Hangi bloğa tıkladıysan onun detay sayfasını getiriyor.
            by.Deger2 = ct.Yorums.Where(x => x.ID == id).ToList(); //Hangi bloğa tıkladıysan onun yorumlarını da detay sayfasına ekliyor.
           
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id) //YorumYap partialview her ne kadar sayfanın üstünde de olsa bu sayfa yüklenince burası çalışır.
        {
            ViewBag.deger = id; //hangi bloğa tıklıyorsak o bloğun id'sini çekip formun id görüntülenen sayfasında göstersin diye bunu yazdık.
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorum y) //Yorum girilip butona basılınca burası çalışır.
        {
            ct.Yorums.Add(y);
            ct.SaveChanges();
            return PartialView("Index");
        }

       
    }
    }
