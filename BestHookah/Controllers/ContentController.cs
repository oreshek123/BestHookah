using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.BLL;

namespace BestHookah.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            GalleryService service = new GalleryService();
            return View(service.GetGalleryItem());
        }

        public ActionResult Offers()
        {
            OffersService service = new OffersService();
            return View(service.GetOffersList());
        }

        public ActionResult Reservation()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult HookahBarDrinks()
        {
            return View();
        }
    }
}