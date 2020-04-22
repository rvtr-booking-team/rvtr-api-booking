using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Guest : IValidatableObject
  {
    [Required]
    public int GuestId { get; set; }
    [Required]
    public string GuestType { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestFirstName { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestLastName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(GuestType != "minor" || GuestType != "adult")
      {
        yield return new ValidationResult("Guest Type must be 'minor' or 'adult'");
      }
    }

  }
}
