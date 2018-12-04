using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.BLL
{
    public class GalleryService
    {
        public List<GalleryItem> GetGalleryItem()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.GalleryItems.ToList();
            }
        }

        public bool CreateGalleryItem(GalleryItem galleryItem, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.GalleryItems.Add(galleryItem);
                    db.SaveChanges();
                    message = "Фотография добавлена успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public bool EditGalleryItem(GalleryItem galleryItem, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.Entry(galleryItem).State = EntityState.Modified;                  
                    db.SaveChanges();
                    message = "Фотография изменена успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteGalleryItem(GalleryItem galleryItem, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.GalleryItems.Remove(galleryItem);
                    db.SaveChanges();
                    message = "Фотография удалена успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }
    }
    
}
