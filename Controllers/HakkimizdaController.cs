using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Sınıflar;

namespace SeyahatSitesi.Controllers
{
    public class HakkimizdaController : Controller
    {
        Context ct = new Context();
        
        public ActionResult Index()
        {
            var hakkimiz = ct.Hakkimizdas.ToList();
            return View(hakkimiz);
        }
    }
}