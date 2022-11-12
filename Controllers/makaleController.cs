using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje.Controllers
{
    using Models;
    [Authorize] //her action için izin gerekir anlamına gelir
    public class makaleController : Controller
    {
        //
        // GET: /makale/
        uzayblgContext context = new uzayblgContext();
        [AllowAnonymous]//tüm kullanıcılar girebilir
        public ActionResult Index()
        {
            return View();
        }
    [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = context.makales.FirstOrDefault(x => x.makale_id == id);
            return View(data);
        }
        [Authorize(Roles="Admin")] //makale ekle kısmına sadece admin ve yazar girebilir anlamına gelir.
        public ActionResult makaleekle()
        {
            return View();
        }
        [AllowAnonymous]
        public string begen(int id)
        {
            makale mkl = context.makales.FirstOrDefault(x => x.makale_id == id);
            mkl.makale_begeni++;
            context.SaveChanges();
            return mkl.makale_begeni.ToString();
        }

    }
}
