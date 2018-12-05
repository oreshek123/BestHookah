using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHookah.DAL
{
    public class ModelEntity: DbContext
    {
        public ModelEntity() : base("name=DefaultConnection")
        {
        }
        public DbSet<RezervTable> RezervTables { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
