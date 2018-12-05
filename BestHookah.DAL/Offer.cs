using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHookah.DAL
{
    [Table("Offer", Schema = "Table")]
    public class Offer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
