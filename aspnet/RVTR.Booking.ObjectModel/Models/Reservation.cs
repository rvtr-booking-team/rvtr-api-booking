using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
    public class Reservation : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
        public int ReservationId { get; set; }
        public int AccountId { get; set; }
        public int RentalId { get; set; }
        public Duration Duration { get; set; }
        public Status Status { get; set; }
        public List<Guest> Guests { get; set; }
        public string Notes { get; set; }
    }
}