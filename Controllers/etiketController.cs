using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje.Controllers
{
    using Models;
    public class etiketController : Controller
    { uzayblgContext context= new uzayblgContext();
        //
        // GET: /etiket/

        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult etiketwidget()
        {
            return PartialView(context.etikets.ToList());
        }
        public ActionResult MakaleListele(int id)
        {
            var data = context.makales.Where(x => x.etikets.Any(y => y.etiket_id == id)).ToList();
            return View("makalelistelewidget", data);
        }
    }
}
