using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Sınıflar;

namespace SeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        Context ct = new Context();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult BlogAdmin()
        {
            var degerler = ct.Blogs.ToList();
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            ct.Blogs.Add(b);
            ct.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Sil(int id)
        {
            var silinecek = ct.Blogs.Find(id);
            ct.Blogs.Remove(silinecek);
            ct.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var bl = ct.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = ct.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogFoto = b.BlogFoto;
            blg.Tarih = b.Tarih;
            ct.SaveChanges();
            return RedirectToAction("BlogAdmin");
        }

        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorum = ct.Yorums.ToList();
            return View(yorum);
        }

        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yrm = ct.Yorums.Find(id);
            ct.Yorums.Remove(yrm);
            ct.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yor = ct.Yorums.Find(id);
            return View("YorumGetir", yor);
        }

        [Authorize]
        public ActionResult YorumGuncelle(Yorum y)
        {
            var yr = ct.Yorums.Find(y.ID);
            yr.KullaniciAdi = y.KullaniciAdi;
            yr.Mail = y.Mail;
            yr.YorumMesaji = y.YorumMesaji;
            ct.SaveChanges();
            return RedirectToAction("YorumListesi");

        }

       [Authorize]
       public ActionResult HakkimizdaPaneli()
        {
            var hakk = ct.Hakkimizdas.ToList();
            return View(hakk);
        }

       [Authorize]
       public ActionResult HakkimizdaDetay(int id)
        {
            var hakkk = ct.Hakkimizdas.Find(id);
            return View("HakkimizdaDetay", hakkk);
        }

        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hg = ct.Hakkimizdas.Find(h.ID);
            hg.Aciklama = h.Aciklama;
            hg.FotoUrl = h.FotoUrl;
            ct.SaveChanges();
            return RedirectToAction("HakkimizdaPaneli");
        }

        [Authorize]
        public ActionResult IletisimPaneli()
        {
            var ilet = ct.Iletisims.ToList();
            return View(ilet);
        }

        [Authorize]
        public ActionResult IletisimDetay(int id)
        {
            var iletdet = ct.Iletisims.Find(id);
            return View("IletisimDetay", iletdet);
        }
    }
}