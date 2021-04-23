using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_7459.DAL.DBO
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        
        [Required]
        [MinLength(6)]
        [DisplayName("Passport Number")]

        public string PassportNumber { get; set; }

        [Required]
        [DisplayName("Telephone Number")]
        [Phone]
        public string TelNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}
