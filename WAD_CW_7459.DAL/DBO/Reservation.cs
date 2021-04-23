using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_7459.DAL.DBO
{
    public class Reservation
    {
        public int Id { get; set; }

       
        [Required]
        [DisplayName("Date Of Reservation")]
        public DateTime DateOfReservation { get; set; }

       
        [Required]
        [DisplayName("Reservation title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Your Id")]
        public int? UserId { get; set; }

        [Required]
        [DisplayName("Book Id")]
        public int? BookId { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
