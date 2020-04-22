using System;
using System.Collections.Generic;
using RVTR.Booking.DataContext.Repositories;
using Xunit;
using RVTR.Booking.ObjectModel.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Booking.UnitTesting.Tests
{
  public class Status_Test
  {
    // [Fact]
    // public void Test_StatusValidation()
    // {
    //   Status status = new Status
    //   {
    //     StatusId = 1,
    //     StatusName = null
    //   };
    //   Assert.True(ValidateModel(status).Any(
    //       s => s.MemberNames.Contains("StatusName") &&
    //            s.ErrorMessage.Contains("Status is required")));
    // }

    // private IList<ValidationResult> ValidateModel(object model)
    // {
    //   var validationResults = new List<ValidationResult>();
    //   var ctx = new ValidationContext(model, null, null);
    //   Validator.TryValidateObject(model, ctx, validationResults, true);
    //   return validationResults;
    // }

    [Fact]
    public void Test_StatusValidation()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = "Test Project",
      };

      var validationContext = new ValidationContext(model);

      var results = model.Validate(validationContext);

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results.First().ErrorMessage, "test status test");
    }
  }
}
