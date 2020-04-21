using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models
{
    public class Status : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}