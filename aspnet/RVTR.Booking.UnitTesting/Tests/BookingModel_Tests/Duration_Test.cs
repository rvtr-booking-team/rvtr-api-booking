using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;
using Xunit;

namespace RVTR.Booking.UnitTesting.Tests.BookingModel_Tests {
  public class Duration_Test {
    [Fact]
    public void Test_Duration_Invalidation () {
      Duration model = new Duration {
        DurationId = 1,
        CheckIn = new DateTime(2020, 12, 21),
        CheckOut = new DateTime(2020, 12, 20),
        CreationDate = new DateTime(2020, 12, 22),
        ModifiedDate = new DateTime(2020, 12, 23)
      };

      var validationContext = new ValidationContext (model);
      var results = model.Validate (validationContext).ToList();
      Assert.Equal (results.Count (), 3);
      Assert.Equal (results.First ().ErrorMessage, "Check In date can't be greater than Check Out date");
      Assert.Equal (results[1].ErrorMessage, "Check In date can't be less than today's date");
      Assert.Equal (results[2].ErrorMessage, "Check Out date can't be less than Modified date");
    }

    [Fact]
    public void Test_Duration_Required_Properties () {
      Duration model = new Duration {
        DurationId =  1,
        CheckIn = default(DateTime),
        CheckOut = default(DateTime),
        CreationDate = new DateTime(2020, 12, 22),
        ModifiedDate = new DateTime(2020, 12, 23)
      };

      var results = new List<ValidationResult>();
      var ctx = new ValidationContext(model, null, null);
      Validator.TryValidateObject(model, ctx, results, true);
      Assert.Equal (results.Count (), 1);
      Assert.Equal (results[0].ErrorMessage, "DurationId is required.");
      // Assert.Equal (results[1].ErrorMessage, "CheckIn is required.");
      // Assert.Equal (results[2].ErrorMessage, "CheckOut is required.");
    }
    
    [Fact]
    public void Test_Duration_Validation () {
      Duration model = new Duration {
        DurationId = 1,
        CheckIn = new DateTime(2020, 12, 20),
        CheckOut = new DateTime(2020, 12, 22),
        CreationDate = new DateTime(2020, 12, 18),
        ModifiedDate = new DateTime(2020, 12, 19)
      };
      var validationContext = new ValidationContext (model);
      var results = model.Validate (validationContext);
      Assert.Equal (results.Count (), 0);
    }
  }
}