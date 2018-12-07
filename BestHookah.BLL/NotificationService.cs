using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestHookah.DAL;

namespace BestHookah.BLL
{
    public class NotificationService
    {
        public void Notify()
        {
            using (ModelEntity db = new ModelEntity())
            {
                foreach (Notification item in db.Notifications)
                {
                    item.Print();
                }
            }
        }

        public List<Notification> GetNotifications()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.Notifications.ToList();
            }
        }
    }
}
