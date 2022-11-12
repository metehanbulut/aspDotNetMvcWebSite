using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using proje.Models;

namespace proje.Controllers
{
    using Models;
    using proje.App_Classes;
    using System.Drawing;
    public class adminController : Controller
    {
        uzayblgContext context = new uzayblgContext();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult yazaronaylari()
        {
            var data = context.kullanicis.Where(x => x.yazar == true && x.onaylandi == false).ToList();
            return View(data);
        }
        //public ActionResult girisyap()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult girisyap(admin admn)
        //{
        //    string ka = validateuser(admn.admin_ka, admn.admin_sf);
        //    if (!string.IsNullOrEmpty(ka))//rol null ya da boş değilise demektir
        //    { //formsauthenticationticket oturumun ne zaman açılacağını ne zaman düşeceği gibi bilgileri tutar
        //        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, admn.admin_ka, DateTime.Now, DateTime.Now.AddMinutes(15), true, ka, FormsAuthentication.FormsCookiePath);//tutulucak cookieyi al
        //        HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);//kendi cookie namesini çek

        //        if (ticket.IsPersistent)//kalıcı ise
        //        {
        //            ck.Expires = ticket.Expiration;//ck nin bitiş süresi ticketin süresine eşit olsun
        //        }

        //        Response.Cookies.Add(ck);
        //        FormsAuthentication.RedirectFromLoginPage(admn.admin_ka, true);

        //    }
        //    return RedirectToAction("makaleekle");//tekrar giriş yapa gidicek
        //}
        //string validateuser(string ka, string pwd)
        //{
        //    //firsordefaultta yoksa null döndürür hata vermez
        //    admin admn = context.admins.FirstOrDefault(x => x.admin_ka == ka && x.admin_sf == pwd);
        //    if (admn != null)
        //    {
        //        return  admn.admin_ka; //roladini döndürür
        //    }
        //    else
        //    {
        //        return "";


        //    }
        //}
        public ActionResult onayver(int kul_id)
        {
            kullanici kl = context.kullanicis.FirstOrDefault(x => x.kullanici_id == kul_id);
            kl.onaylandi = true;

            context.SaveChanges();
            return RedirectToAction("yazaronaylari");
        }

        public ActionResult kategoriekle(string p)
        {
            var degerler = from d in context.kategoris select d;//degerleri rols tablosundan çekip dyle aldık
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.kategori_adi.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult yenikategori()
        {
            return View();
        }
        [HttpPost]//sayfaya post işlemi oldupunda butona basıldığında falan
        public ActionResult yenikategori(kategori kategori)
        {
            context.kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("kategoriekle");
        }
        public ActionResult sil(int id)
        {
            var kategori = context.kategoris.Find(id);
            context.kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("kategoriekle");
        }
        public ActionResult güncelle(int id)
        {
            var ktgr = context.kategoris.Find(id);
            return View("güncelle", ktgr);
        }
        public ActionResult gunyap(kategori kt)
        {
            var kategori = context.kategoris.Find(kt.kategori_id);
            kategori.kategori_adi = kt.kategori_adi;
            kategori.kategori_aciklama = kt.kategori_aciklama;
            context.SaveChanges();
            return RedirectToAction("kategoriekle");
        }
        public ActionResult makaleekle(string p)
        {
            var degerler = from d in context.makales select d;//degerleri rols tablosundan çekip dyle aldık
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.makale_baslik.Contains(p));
            }
            return View(degerler.ToList());
        }

        public ActionResult etiketekle(string p)
        {

            var degerler = from d in context.etikets select d;//degerleri rols tablosundan çekip dyle aldık
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.etiket_adi.Contains(p));
            }
            return View(degerler.ToList());
        }
        public ActionResult rolekle(string p)
        {
            var degerler = from d in context.rols select d;//degerleri rols tablosundan çekip dyle aldık
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.rol_adi.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = context.rols.ToList();
            //return View(degerler);


        }
        public ActionResult adminekle(string p)
        {
            var degerler = from d in context.admins select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.admin_ka.Contains(p));
            }
            return View(degerler.ToList());
        }
        public ActionResult kullaniciekle(string p)
        {
            var degerler = from d in context.kullanicis select d;//degerleri rols tablosundan çekip dyle aldık
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.kullanici_adi.Contains(p));
            }
            return View(degerler.ToList());
            /*var degerler = context.kullanicis.ToList();
            return View(degerler);*/
        }
        [HttpGet]
        public ActionResult yenietiket()
        {

            return View();
        }
        [HttpPost]
        public ActionResult yenietiket(etiket etiket)
        {
            context.etikets.Add(etiket);
            context.SaveChanges();
            return RedirectToAction("etiketekle");
        }
        [HttpGet]
        public ActionResult yenikullanici()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikullanici(kullanici kull, string rbkadin, string rberkek)
        {
            if (!string.IsNullOrEmpty(rberkek))
            {
                kull.kullanici_cinsiyet = true;
            }
            if (!string.IsNullOrEmpty(rbkadin))
            {
                kull.kullanici_cinsiyet = false;
            }
            kull.yazar = false;
            kull.onaylandi = true;
            kull.aktif = true;
            kull.kullanici_dogum = kull.kullanici_dogum;
            kull.kullaniciadi = kull.kullaniciadi;
            kull.sifre = kull.sifre;
            kull.kullanici_kayit = DateTime.Now;
            context.kullanicis.Add(kull);
            context.SaveChanges();
            return RedirectToAction("kullaniciekle");
            /*
            context.kullanicis.Add(kull);
            context.SaveChanges();
            return RedirectToAction("kullaniciekle");*/
        }
        [HttpGet]
        public ActionResult yenimakale()
        {
            ViewBag.kategoriler = context.kategoris.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult yenimakale(makale mkl , HttpPostedFileBase rsm)

        {
            
            Image img = Image.FromStream(rsm.InputStream);
            Bitmap kucuk = new Bitmap(img, settings.resimkucukboyut);
            Bitmap buyuk = new Bitmap(img, settings.resimbuyukboyut);
            Bitmap orta = new Bitmap(img, settings.resimortaboyut);
            kucuk.Save(Server.MapPath("/Content/Makaleresim/kucuk/"+rsm.FileName));
            buyuk.Save(Server.MapPath("/Content/Makaleresim/buyuk/" + rsm.FileName));
            orta.Save(Server.MapPath("/Content/Makaleresim/orta/" + rsm.FileName));

            resim resm = new resim();
            resm.buyukboyut = "/Content/Makaleresim/buyuk/" + rsm.FileName;
            resm.ortaboyut = "/Content/Makaleresim/orta/" + rsm.FileName;
           resm.kucukboyut= "/Content/Makaleresim/kucuk/" + rsm.FileName;
           context.resims.Add(resm);
           context.SaveChanges();
           return View();
        
        
        }

private void alert(char p)
{
 	throw new NotImplementedException();
}

        [HttpGet]
        public ActionResult yenirol()
        {

            return View();
        }
        [HttpPost]
        public ActionResult yenirol(rol rolss)
        {
            context.rols.Add(rolss);
            context.SaveChanges();
            return RedirectToAction("rolekle");
        }
        [HttpGet]
        public ActionResult yeniadmin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult yeniadmin(admin admin)
        {
            context.admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("adminekle");
        }

        public ActionResult etiketsil(int id)
        {
            var etiket = context.etikets.Find(id);
            context.etikets.Remove(etiket);
            context.SaveChanges();
            return RedirectToAction("etiketekle");
        }
        public ActionResult kullanicisil(int id)
        {
            var kullanici = context.kullanicis.Find(id);
            context.kullanicis.Remove(kullanici);
            context.SaveChanges();
            return RedirectToAction("kullaniciekle");
        }
        public ActionResult makalesil(int id)
        {
            var makale = context.makales.Find(id);
            context.makales.Remove(makale);
            context.SaveChanges();
            return RedirectToAction("makaleekle");
        }
        public ActionResult rolsil(int id)
        {
            var rol = context.rols.Find(id);
            context.rols.Remove(rol);
            context.SaveChanges();
            return RedirectToAction("rolekle");
        }
        public ActionResult adminsil(int id)
        {
            var admin = context.admins.Find(id);
            context.admins.Remove(admin);
            context.SaveChanges();
            return RedirectToAction("adminekle");
        }

        public ActionResult rolguncele(int id)
        {
            var ktgr = context.rols.Find(id);
            return View("rolguncele", ktgr);
            
        }
        public ActionResult adminguncelle(int id)
        {
            var admn = context.admins.Find(id);
            return View("adminguncelle",admn);
        }
        public ActionResult admingun(admin p1)
    {
        var admn = context.admins.Find(p1.admin_id);
        admn.admin_ka = p1.admin_ka;
            admn.admin_sf = p1.admin_sf;
        context.SaveChanges();
        return RedirectToAction("adminekle");
    }

   
        public ActionResult rolgun(rol p1)
        {
            var roll = context.rols.Find(p1.rol_id);
            roll.rol_adi = p1.rol_adi;
            context.SaveChanges();
            return RedirectToAction("rolekle");
        }
        public ActionResult kullaniciguncelle(int id)
        {
            var kulnc = context.kullanicis.Find(id);
            return View("kullaniciguncelle", kulnc);

        }
        public ActionResult kulgun(kullanici p1,string rbkadin, string rberkek)
        {
            /*
             *  kull.yazar = false;
            kull.onaylandi = true;
            kull.aktif = true;
            kull.kullanici_dogum = kull.kullanici_dogum;
            kull.kullanici_kayit = DateTime.Now;
            context.kullanicis.Add(kull);
            context.SaveChanges();
            return RedirectToAction("kullaniciekle");*/
            var kullanic = context.kullanicis.Find(p1.kullanici_id);
            kullanic.kullanici_adi = p1.kullanici_adi;
            kullanic.sifre = p1.sifre;
            kullanic.kullaniciadi = p1.kullaniciadi;
            kullanic.kullanici_mail = p1.kullanici_mail;
            if (!string.IsNullOrEmpty(rberkek))
            {
                kullanic.kullanici_cinsiyet = true;
            }
            if (!string.IsNullOrEmpty(rbkadin))
            {
                kullanic.kullanici_cinsiyet = false;
            }
            kullanic.kullanici_dogum = p1.kullanici_dogum;
            context.SaveChanges();
            return RedirectToAction("kullaniciekle");
        }
       
       
    }
}
