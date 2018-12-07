using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.BLL;
using BestHookah.DAL;

namespace BestHookah.Controllers
{
    public class AdminController : Controller
    {
        private TableService _service = new TableService();
        private GalleryService _galleryService = new GalleryService();
        private OffersService _offersService = new OffersService();
        private NotificationService _notificationService = new NotificationService();
        // GET: Admin



        [HttpPost]
        public ActionResult _ReservationPartial(RezervTable table)
        {
            string message = "";
            _service.CreateTable(table, out message);
            _notificationService.Notify();
            return RedirectToAction("Index", "Home", new { message });
        }



        public ActionResult ReservationList()
        {

            return View(_service.GetRezervTables());
        }


        public ActionResult GalleryList()
        {
            var items = _galleryService.GetGalleryItem();
            return View(items);
        }

        public ActionResult CreateGalleryItem()
        {
            GalleryItem galleryItem = new GalleryItem();
            return View(galleryItem);
        }

        [HttpPost]
        public ActionResult CreateGalleryItem(GalleryItem galleryItem)
        {
            string message = "";
            _galleryService.CreateGalleryItem(galleryItem, out message);

            return RedirectToAction("GalleryList", "Admin");
        }


        public ActionResult EditGalleryItem(int id)
        {
            GalleryItem item = _galleryService.GetGalleryItem().FirstOrDefault(t => t.GalleryItemId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditGalleryItem(GalleryItem item)
        {
            string message = "";
            _galleryService.EditGalleryItem(item, out message);

            return RedirectToAction("GalleryList", "Admin");
        }

        public ActionResult DetailsGalleryItem(int id)
        {
            GalleryItem item = _galleryService.GetGalleryItem().FirstOrDefault(t => t.GalleryItemId == id);
            return View(item);
        }

        public ActionResult DeleteGalleryItem(int id)
        {
            GalleryItem item = _galleryService.GetGalleryItem().FirstOrDefault(t => t.GalleryItemId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteGalleryItem(GalleryItem item)
        {
            string message = "";
            _galleryService.DeleteGalleryItem(item, out message);
            return RedirectToAction("GalleryList", "Admin");
        }

        public ActionResult OffersList()
        {
            var items = _offersService.GetOffersList();
            return View(items);
        }

        public ActionResult CreateOffer()
        {
            Offer offer = new Offer();
            return View(offer);
        }

        [HttpPost]
        public ActionResult CreateOffer(Offer offer)
        {
            string message = "";
            _offersService.CreateOffer(offer, out message);

            return RedirectToAction("OffersList", "Admin");
        }


        public ActionResult EditOffer(int id)
        {
            Offer item = _offersService.GetOffersList().FirstOrDefault(t => t.OfferId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditOffer(Offer offer)
        {
            string message = "";
            _offersService.EditOffer(offer, out message);

            return RedirectToAction("OffersList", "Admin");
        }

        public ActionResult DetailsOffer(int id)
        {
            Offer item = _offersService.GetOffersList().FirstOrDefault(t => t.OfferId == id);
            return View(item);
        }

        public ActionResult DeleteOffer(int id)
        {
            Offer item = _offersService.GetOffersList().FirstOrDefault(t => t.OfferId == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteOffer(Offer offer)
        {
            string message = "";
            _offersService.DeleteOffer(offer, out message);
            return RedirectToAction("OffersList", "Admin");
        }




        public ActionResult Filter(DateTime? From, DateTime? To)
        {

            if (From == null || To == null)
            {
                return View("ReservationList", _service.GetRezervTables());
            }

            var test = _service.FilterByDate(From, To);
            return View("ReservationList", _service.FilterByDate(From, To));
        }

        public ActionResult GetTodayReservationsFromExcel()
        {
            string s = Server.MapPath("/Files/Reservations.xlsx");
            return File(_service.GetReservationsExcel(s), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }


        public ActionResult Settings()
        {

            return View(_notificationService.GetNotifications());
        }

        public ActionResult EditReservation(int id)
        {
            RezervTable t = _service.GetRezervTables().FirstOrDefault(p => p.TableId == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditReservation(RezervTable table)
        {
            string message = "";
            _service.EditTable(table, out message);
            return RedirectToAction("ReservationList");
        }

        public ActionResult DeleteReservation(int id)
        {
            RezervTable t = _service.GetRezervTables().FirstOrDefault(p => p.TableId == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeleteReservation(RezervTable table)
        {
            string message = "";
            _service.DeleteTable(table, out message);
            return RedirectToAction("ReservationList");
        }

        public ActionResult DetailsReservation(int id)
        {
            RezervTable t = _service.GetRezervTables().FirstOrDefault(p => p.TableId == id);
            return View(t);
        }

    }
}