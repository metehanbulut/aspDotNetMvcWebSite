using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace proje.Controllers
{
    public class kullaniciController : Controller
    {
        //
        // GET: /kullanici/
        uzayblgContext context = new uzayblgContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult girisyap()
        {
            return View();
        }
        public ActionResult girisyapadmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult girisyapadmin(admin admn)
        {
            string ka = validateuseradmin(admn.admin_ka, admn.admin_sf);
            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, admn.admin_ka, DateTime.Now, DateTime.Now.AddMinutes(15), true, ka, FormsAuthentication.FormsCookiePath);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(ck);
                FormsAuthentication.RedirectFromLoginPage(admn.admin_ka, true);
            }
            return RedirectToAction("makaleekle", "admin");
        }
            string validateuseradmin(string ka , string sf)
            {
                admin admn = context.admins.FirstOrDefault(x => x.admin_ka == ka && x.admin_sf == sf);
                if (admn != null)
                {
                    return admn.admin_ka;
                }
                else
                    return "";

            }
        
        [HttpPost]
        public ActionResult girisyap( kullanici kl)
        {
            string ka = validateuser(kl.kullaniciadi, kl.sifre);
            if (!string.IsNullOrEmpty(ka))//rol null ya da boş değilise demektir
            { //formsauthenticationticket oturumun ne zaman açılacağını ne zaman düşeceği gibi bilgileri tutar
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, kl.kullaniciadi, DateTime.Now, DateTime.Now.AddMinutes(15),true,ka,FormsAuthentication.FormsCookiePath);//tutulucak cookieyi al
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);//kendi cookie namesini çek

                if (ticket.IsPersistent)//kalıcı ise
                {
                    ck.Expires = ticket.Expiration;//ck nin bitiş süresi ticketin süresine eşit olsun
                }

                Response.Cookies.Add(ck);
                FormsAuthentication.RedirectFromLoginPage(kl.kullaniciadi,true);
              
            }
            return RedirectToAction("Index", "Home");

        }
        string validateuser(string ka, string pwd)
        {
            //firsordefaultta yoksa null döndürür hata vermez
            kullanici kl = context.kullanicis.FirstOrDefault(x => x.kullaniciadi == ka && x.sifre == pwd);
            if (kl != null)
            {
                return kl.kullaniciadi; //roladini döndürür
            }
            else
            {
                return "";


            }
        }
        public ActionResult cikisyap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult uyeol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uyeol(kullanici kl, string rbkadin, string rberkek)
        {
            if (!string.IsNullOrEmpty(rberkek))
            {
                kl.kullanici_cinsiyet = true;
            }
            if (!string.IsNullOrEmpty(rbkadin))
            {
                kl.kullanici_cinsiyet = false;
            }
            kl.yazar = false;
            kl.onaylandi = true;
            kl.aktif = true;
            kl.kullanici_dogum = kl.kullanici_dogum;
            kl.kullanici_kayit = DateTime.Now;
            context.kullanicis.Add(kl);
            context.SaveChanges();
            return RedirectToAction("girisyap");
        }

    }
       
}
