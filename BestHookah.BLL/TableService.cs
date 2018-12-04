using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestHookah.DAL;

namespace BestHookah.BLL
{
    public class TableService
    {
        

        public bool CreateTable(RezervTable table, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.RezervTables.Add(table);
                    db.SaveChanges();
                    message = "Резервация прошла успешно";
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
