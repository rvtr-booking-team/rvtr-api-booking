using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Guest : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int GuestId { get; set; }
    [Required]
    public string GuestType
    {
      get
      {
        return GuestType;
      }
      set
      {
        if (value.ToLower() == "minor")
        {
          GuestType = value.ToLower();
        }
        else if (value.ToLower() == "adult")
        {
          GuestType = value.ToLower();
        }
      }
    }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestFirstName { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestLastName { get; set; }
  }
}
