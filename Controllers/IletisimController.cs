using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Sınıflar;

namespace SeyahatSitesi.Controllers
{
    public class IletisimController : Controller
    {
        Context ct = new Context();

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BizeUlas(Iletisim i) //Yorum girilip butona basılınca burası çalışır.
        {
            ct.Iletisims.Add(i);
            ct.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult BizeUlas()
        {
            return View();
        }

       
    }
}