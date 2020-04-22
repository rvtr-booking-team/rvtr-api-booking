using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
    public class Reservation : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

        [Required]
        public int ReservationId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int RentalId { get; set; }
        [Required]
        public Duration Duration { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public List<Guest> Guests { get; set; }
        public string Notes { get; set; }
    }
}
