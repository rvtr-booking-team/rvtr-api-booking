using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  /// <summary>
  ///
  /// </summary>
  public class Status : IValidatableObject
  {
    [Key]
    public int StatusId { get; set; }
    [Required(ErrorMessage = "StatusName is required")]
    public string StatusName { get; set; }
    #region NAVIGATIONAL PROPERTIES
    public List<Reservation> Reservations { get; set; }
    #endregion // NAVIGATIONAL PROPERTIES

    /// <summary>
    ///
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns>ValidationResult</returns>
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
