using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Status : IValidatableObject
  {
    [Key]
    public int StatusId { get; set; }
    [Required(ErrorMessage = "StatusName is required")]
    public string StatusName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(StatusName.ToLower() != "confirmed"
        && StatusName.ToLower() != "pending"
        && StatusName.ToLower() != "canceled")
      {
        yield return new ValidationResult("Status Name must be 'confirmed', 'pending' or 'canceled'");
      }
    }
  }
}
