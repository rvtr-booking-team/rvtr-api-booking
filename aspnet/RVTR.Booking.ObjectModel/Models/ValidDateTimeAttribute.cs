using System;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Booking.ObjectModel.Models {
  [AttributeUsage(AttributeTargets.All)]
  public class ValidDateTimeAttribute : ValidationAttribute {
    public ValidDateTimeAttribute () {
      ErrorMessage = "{0} is required.";
    }

    public override bool IsValid (object value) {
      if (!(value is DateTime))
        throw new ArgumentException ("Value must be a DateTime object.");

      if ((DateTime) value == DateTime.MinValue)
        return false;

      return true;
    }
  }
}
