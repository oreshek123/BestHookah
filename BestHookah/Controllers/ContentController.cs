using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestHookah.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Menu()
        {
            return View();
        }
    }
}