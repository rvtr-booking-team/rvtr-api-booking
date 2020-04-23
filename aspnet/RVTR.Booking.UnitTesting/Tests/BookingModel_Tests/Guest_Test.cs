using System;
using System.Collections.Generic;
using RVTR.Booking.DataContext.Repositories;
using Xunit;
using RVTR.Booking.ObjectModel.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Booking.UnitTesting.Tests
{
  public class guest_Test
  {
    [Fact]
    public void Test_Guest_Invalidation()
    {
      Guest model = new Guest
      {
        GuestId = 1,
        GuestType = "child",
        GuestFirstName = "John",
        GuestLastName = "Doe",
      };

      var validationContext = new ValidationContext(model);
      var results = model.Validate(validationContext);

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results.First().ErrorMessage, "Guest Type must be 'minor' or 'adult'");
    }

    [Fact]
    public void Test_Guest_Validation()
    {
      Guest model = new Guest
      {
        GuestId = 1,
        GuestType = "adult",
        GuestFirstName = "John",
        GuestLastName = "Doe",
      };

      var validationContext = new ValidationContext(model);
      var results = model.Validate(validationContext);

      Assert.Equal(results.Count(), 0);
    }

    [Fact]
    public void Test_Guest_Required_Properties()
    {
      Guest model = new Guest
      {
        GuestId = 0,
        GuestType = "",
        GuestFirstName = "",
        GuestLastName = "",
      };
      var results = new List<ValidationResult>();
      var validationContext = new ValidationContext(model);
      Validator.TryValidateObject(model, validationContext, results, true);

      Assert.Equal(results.Count(), 3);
      Assert.Equal(results[0].ErrorMessage, "GuestType is required");
      Assert.Equal(results[1].ErrorMessage, "GuestFirstName is required");
      Assert.Equal(results[2].ErrorMessage, "GuestLastName is required");
    }

    [Fact]
    public void Test_Guest_Regular_Expressions()
    {
      Guest model = new Guest
      {
        GuestId = 1,
        GuestType = "adult",
        GuestFirstName = "@",
        GuestLastName = "@",
      };
      var results = new List<ValidationResult>();
      var validationContext = new ValidationContext(model);
      Validator.TryValidateObject(model, validationContext, results, true);

      Assert.Equal(results.Count(), 2);
      Assert.Equal(results[0].ErrorMessage, "Use letters only please");
      Assert.Equal(results[1].ErrorMessage, "Use letters only please");
    }
  }
}
