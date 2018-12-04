﻿using System;
using System.Collections.Generic;
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
        // GET: Admin

        

        [HttpPost]
        public ActionResult _ReservationPartial(RezervTable table)
        {
            string message = "";
            _service.CreateTable(table, out message);
            return RedirectToAction("Index", "Home", new { message });
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
    }
}