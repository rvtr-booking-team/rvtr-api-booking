using System;
using System.Collections.Generic;
using Xunit;
using RVTR.Booking.ObjectModel.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace RVTR.Booking.UnitTesting.Tests
{
  public class Reservation_Test
  {
    [Fact]
    public void Test_ReservationValidation()
    {
      Reservation model = new Reservation()
      {
        ReservationId = 0,
        AccountId = 0,
        RentalId = 0,
        Duration = null,
        Status = null,
        Guests =null,
        Notes = "Test notes"
      };
      List<String> memberNames = new List<String> {"Duration","Status", "Guests"};

      /**
       *Test the required annotations
       */
      foreach(var member in memberNames){
        Console.WriteLine(member);
        Assert.True(ValidateModel(model).Any(
          e => e.MemberNames.Contains(member) &&
              e.ErrorMessage.Contains($"{member} is required"))
        );
      }

      /**
       *Test the business logics
       */
      var ValidationContext = new ValidationContext(model);
      var result = model.Validate(ValidationContext);
      Assert.Equal(result.Count(), 1);
      Assert.Equal(result.First().ErrorMessage, "IDs must be given");
    }

    private IList<ValidationResult> ValidateModel(object model)
    {
      var validationResults = new List<ValidationResult>();
      var ctx = new ValidationContext(model, null, null);
      Validator.TryValidateObject(model, ctx, validationResults, true);
      return validationResults;
    }
  }
}
