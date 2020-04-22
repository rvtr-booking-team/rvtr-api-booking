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
    [Fact]
    public void Test_Status_Invalidation()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = "test"
      };

      var validationContext = new ValidationContext(model);

      var results = model.Validate(validationContext).ToList();

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results[0].ErrorMessage, "Status Name must be 'confirmed', 'pending' or 'canceled'");
    }

    [Fact]
    public void Test_Status_Required_Properties()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = null
      };

      var results = new List<ValidationResult>();
      var validationContext = new ValidationContext(model);
      Validator.TryValidateObject(model, validationContext, results, true);

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results[0].ErrorMessage, "StatusName is required");
    }

    [Fact]
    public void Test_Status_Validation()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = "confirmed"
      };

      var validationContext = new ValidationContext(model);

      var results = model.Validate(validationContext);

      Assert.Equal(results.Count(), 0);
    }
  }
}
