using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Duration : IValidatableObject
  {
    [Required]
    public int DurationId { get; set; }
    [Required]
    public DateTime CheckIn { get; set; }
    [Required]
    public DateTime CheckOut { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(CheckIn.Date > CheckOut.Date)
      {
        yield return new ValidationResult("Check In date can't be greater than Check Out date");
      }

      if(CheckIn.Date < CreationDate.Date)
      {
        yield return new ValidationResult("Check In date can't be less than today's date");
      }

      if(CheckOut.Date < ModifiedDate.Date)
      {
        yield return new ValidationResult("Check Out date can't be less than Modified date");
      }
    }
  }
}
