using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Status : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int StatusId { get; set; }
    [Required]
    public string StatusName
    {
      get
      {
        return StatusName;
      }
      set
      {
        if (value.ToLower() == "confirmed")
        {
          StatusName = value.ToLower();
        }
        else if (value.ToLower() == "pending")
        {
          StatusName = value.ToLower();
        }
        else if (value.ToLower() == "canceled")
        {
          StatusName = value.ToLower();
        }
      }
    }
  }
}
