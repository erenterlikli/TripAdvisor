using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SeyahatSitesi.Models.Sınıflar;

namespace SeyahatSitesi.Controllers
{
    public class GirisYapController : Controller
    {
        Context ct = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler = ct.Admins.FirstOrDefault(x => x.KullaniciAdi == ad.KullaniciAdi && x.Sifre == ad.Sifre);

            if(bilgiler!=null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false); //cookie ayarı.
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString(); //oturum ayarı.
                return RedirectToAction("Index", "Admin"); 
            }

            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //çıkış komutu.
            return RedirectToAction("Login", "GirisYap");
        }
    }
}