using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  public class Duration : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int DurationId { get; set; }
    [Required]
    public DateTime CheckIn
    {
      get
      {
        return CheckIn;
      }
      set
      {
        if (value.Date <= CheckOut.Date
        && value.Date >= CreationDate)
        {
          CheckIn = value;
        }
      }
    }
    [Required]
    public DateTime CheckOut
    {
      get
      {
        return CheckOut;
      }
      set
      {
        if (value.Date >= CheckIn.Date
        && value.Date >= ModifiedDate.Date)
        {
          CheckOut = value;
        }
      }
    }
    [Required]
    public DateTime CreationDate { get; set; }
    public DateTime ModifiedDate
    {
      get
      {
        return ModifiedDate;
      }
      set
      {
        if (value.Date <= CheckOut.Date)
        {
          ModifiedDate = value.Date;
        }
      }
    }
  }

}
