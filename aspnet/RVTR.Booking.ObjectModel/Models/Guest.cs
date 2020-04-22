using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
  // <summary>
  ///
  /// </summary>/
  public class Guest : IValidatableObject
  {
    [Required(ErrorMessage = "GuestId is required")]
    [Key]
    public int GuestId { get; set; }
    [Required(ErrorMessage = "GuestType is required")]
    public string GuestType { get; set; }
    [Required(ErrorMessage = "GuestFirstName is required")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestFirstName { get; set; }
    [Required(ErrorMessage = "GuestLastName is required")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    public string GuestLastName { get; set; }
    #region NAVIGATIONAL PROPERTIES
    public Reservation Reservation { get; set; }
    #endregion // NAVIGATIONAL PROPERTIES

    /// <summary>
    ///
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns>ValidationResult</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(GuestType != "minor" && GuestType != "adult")
      {
        yield return new ValidationResult("Guest Type must be 'minor' or 'adult'");
      }
    }

  }
}
