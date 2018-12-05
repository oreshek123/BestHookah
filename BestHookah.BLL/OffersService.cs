using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestHookah.DAL;

namespace BestHookah.BLL
{
    public class OffersService
    {
        public List<Offer> GetOffersList()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.Offers.ToList();
            }
        }

        public bool CreateOffer(Offer offer, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.Offers.Add(offer);
                    db.SaveChanges();
                    message = "Предложение добавлено успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public bool EditOffer(Offer offer, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.Entry(offer).State = EntityState.Modified;
                    db.SaveChanges();
                    message = "Предложение изменено успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteOffer(Offer offer, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    var f = db.Offers.FirstOrDefault(t => t.OfferId == offer.OfferId);

                    db.Offers.Remove(f);
                    db.SaveChanges();
                    message = "Предложение удалено успешно";
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
