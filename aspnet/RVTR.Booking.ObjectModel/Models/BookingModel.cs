using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Booking.ObjectModel.Interfaces;

namespace RVTR.Booking.ObjectModel.Models
{
  public class BookingModel : IModelValidator
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
    [Required(ErrorMessage = "BookingModelId is required.")]
    [Key]
    public int BookingModelId { get; set; }
  }
}
