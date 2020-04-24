using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Reservation : IValidatableObject
  {
    [Required(ErrorMessage = "ReservationId is required")]
    [Key]
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
    [ForeignKey("Duration")]
    public int DurationId { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if( AccountId <= 0 || RentalId <= 0)
      {
        yield return new ValidationResult("IDs must be given");
      }

    }
  }
}

