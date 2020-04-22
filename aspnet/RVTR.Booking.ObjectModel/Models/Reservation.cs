using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Reservation : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required(ErrorMessage = "ReservationId is required")]
    public int ReservationId { get; set; }
    [Required(ErrorMessage = "AccountId is required")]
    public int AccountId { get; set; }
    [Required(ErrorMessage = "RentalId is required")]
    public int RentalId { get; set; }
    [Required(ErrorMessage = "Duration is required")]
    public Duration Duration { get; set; }
    [Required(ErrorMessage = "Status is required")]
    public Status Status { get; set; }
    [Required(ErrorMessage = "Guests is required")]
    public List<Guest> Guests { get; set; }
    public string Notes { get; set; }

    

  }
}
