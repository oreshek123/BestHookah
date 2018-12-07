using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHookah.BLL
{
    public static class FileInformer
    {
        private static DirectoryInfo _baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        public static FileInfo ReservationsInfo = new FileInfo(_baseDirectory.Parent?.Parent+ "/Files/Reservations.xlsx");

    }
}
