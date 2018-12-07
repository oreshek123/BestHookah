using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestHookah.DAL;
using OfficeOpenXml;

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


        public bool EditTable(RezervTable table, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.Entry(table).State = EntityState.Modified;
                    db.SaveChanges();
                    message = "Резервация изменена успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteTable(RezervTable table, out string message)
        {
            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    RezervTable t = db.RezervTables.FirstOrDefault(p => p.TableId == table.TableId);
                    db.RezervTables.Remove(t);
                    db.SaveChanges();
                    message = "Резервация удалена успешно";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }


        public List<RezervTable> GetRezervTables()
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.RezervTables.ToList();
            }
        }
        public List<RezervTable> FilterByDate(DateTime? from, DateTime? to)
        {
            using (ModelEntity db = new ModelEntity())
            {
                return db.RezervTables.Where(w => w.DateOfReservation >= from && w.DateOfReservation <= to).ToList();
            }
        }

        public byte[] GetReservationsExcel(string path)
        {
            List<RezervTable> rezervTables = new List<RezervTable>();
            using (ModelEntity db = new ModelEntity())
            {
                rezervTables = db.RezervTables.ToList().Where(w => w.DateOfReservation.Date == DateTime.Now.Date).ToList();
               
            }

            ExcelPackage package = new ExcelPackage(new FileInfo(path));
            ExcelWorksheet firstPage = package.Workbook.Worksheets.FirstOrDefault();

            int startRow = 2;
            foreach (RezervTable rezervTable in rezervTables)
            {
                firstPage.Cells[startRow, 1].Value = rezervTable.ClientName;
                firstPage.Cells[startRow, 2].Value = rezervTable.Email;
                firstPage.Cells[startRow, 3].Value = rezervTable.Phone;
                firstPage.Cells[startRow, 4].Value = rezervTable.Message;
                firstPage.Cells[startRow, 5].Value = rezervTable.DateOfReservation;


                startRow++;
            }

            return package.GetAsByteArray();
        }
    }
}
