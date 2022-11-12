using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje.Controllers
{
    using Models;
    public class yazarController : Controller
    {
        uzayblgContext context = new uzayblgContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult yazarol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yazarol(kullanici kl, string rbkadin, string rberkek)
        {
            if (!string.IsNullOrEmpty(rberkek)) kl.kullanici_cinsiyet = true;
            if (!string.IsNullOrEmpty(rbkadin)) kl.kullanici_cinsiyet = false;
            kl.yazar = true;
            kl.onaylandi = false;
            kl.aktif = true;
            kl.kullanici_kayit = DateTime.Now;
            context.kullanicis.Add(kl);
            context.SaveChanges();

            rol yazar = context.rols.FirstOrDefault(x => x.rol_adi == "Yazar");
            kullanicirol kr = new kullanicirol();
            kr.rol_id = yazar.rol_id;
            kr.kullanici_id = kl.kullanici_id;
            context.kullanicirols.Add(kr);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    
    }
}
