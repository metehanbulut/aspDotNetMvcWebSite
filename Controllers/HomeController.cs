using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace proje.Controllers
{
    using Models; //models klasörünü dahil ettik
    using App_Classes;
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        uzayblgContext context = new uzayblgContext();//global context tanımladık 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult makalelistele()
        {
            var data = context.makales.ToList();
            return View("makalelistelewidget", data);
        }

        public PartialViewResult populermakalelerwidget()
        {   var model=context.makales.OrderByDescending(x=>x.makale_tarih).Take(3).ToList();//son eklenen 3 makaleyi al ve listele
        return PartialView(model);
        }
    }
}
