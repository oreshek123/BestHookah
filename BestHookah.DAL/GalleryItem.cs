using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHookah.DAL
{
    [Table("GalleryItem", Schema = "Table")]
    public class GalleryItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GalleryItemId { get; set; }
        public string GalleryItemName { get; set; }
        public string PicturePath { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
    }
}
