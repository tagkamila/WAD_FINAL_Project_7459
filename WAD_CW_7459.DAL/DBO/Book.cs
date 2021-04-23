using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_7459.DAL.DBO
{
    public class Book
    {

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        public string Authors { get; set; }

        public int YearPublished { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Category { get; set; }

        public int? ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
