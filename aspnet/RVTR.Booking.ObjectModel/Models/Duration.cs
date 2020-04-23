using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  // <summary>
  /// Represents the duration of the reservation
  /// CheckIn and CheckOut
  /// </summary>/
  public class Duration : IValidatableObject
  {
    [Key]
    public int DurationId { get; set; }
    [ValidDateTime]
    public DateTime CheckIn { get; set; }
    [ValidDateTime]
    public DateTime CheckOut { get; set; }
    [ValidDateTime]
    public DateTime CreationDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    #region NAVIGATIONAL PROPERTIES
    public Reservation Reservation { get; set; }
    #endregion // NAVIGATIONAL PROPERTIES

    /// <summary>
    /// Validate() to validate CheckIn and CheckOut
    /// so that CheckIn isn't after CheckOut, CheckIn isn't
    /// before today's date and that CheckOut isn't after ModifiedDate
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns>ValidationResults</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(CheckIn.Date > CheckOut.Date)
      {
        yield return new ValidationResult("Check In date can't be greater than Check Out date", new[] {"CheckIn date"});
      }

      if(CheckIn.Date < CreationDate.Date)
      {
        yield return new ValidationResult("Check In date can't be less than today's date", new[] {"CheckOut date"});
      }

      if(CheckOut.Date < ModifiedDate.Date)
      {
        yield return new ValidationResult("Check Out date can't be less than Modified date", new[] {"CheckOut Date"});
      }
    }
  }
}
