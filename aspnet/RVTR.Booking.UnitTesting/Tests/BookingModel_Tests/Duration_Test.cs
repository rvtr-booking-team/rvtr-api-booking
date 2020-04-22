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
    public void Test_DurationValidation () {
      Duration model = new Duration {
        DurationId = 1,
        CheckIn = new DateTime(2020, 12, 21),
        CheckOut = new DateTime(2020, 12, 20),
        CreationDate = new DateTime(2020, 12, 18),
        ModifiedDate = new DateTime(2020, 12, 19)
      };

      var validationContext = new ValidationContext (model);

      var results = model.Validate (validationContext);

      Assert.Equal (results.Count (), 1);
      Assert.Equal (results.First ().ErrorMessage, "Check In date can't be greater than Check Out date");
    }
  }
}