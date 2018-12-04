using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHookah.DAL
{
    [Table("RezervTable", Schema = "Table")]
    public class RezervTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; }
        public DateTime DateOfReservation { get; set; } = DateTime.Now;

    }
}
