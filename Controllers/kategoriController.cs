using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje.Controllers
{
    using Models;
    public class kategoriController : Controller
    {
        uzayblgContext context = new uzayblgContext();
        //
        // GET: /kategori/

        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult kategoriwidget()
        {
            return PartialView(context.kategoris.ToList());
        }
        public ActionResult makalelistele(int id)
        {
            var data = context.makales.Where(x => x.makale_kategorid == id).ToList();
            return View("makalelistelewidget", data);
        }
    }
}
