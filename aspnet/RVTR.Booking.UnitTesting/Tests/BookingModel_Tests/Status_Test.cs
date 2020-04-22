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
    public void Test_StatusValidation()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = "Test Project"
      };

      var validationContext = new ValidationContext(model);

      var results = model.Validate(validationContext);

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results.First().ErrorMessage, "Status Name must be 'confirmed', 'pending' or 'canceled'");
    }
    
    [Fact]
    public void Test_StatusRequired()
    {
      Status model = new Status
      {
        StatusId = 2,
        StatusName = null
      };
      var results = new List<ValidationResult>();
      var validationContext = new ValidationContext(model, null, null);
      Validator.TryValidateObject(model, validationContext, results, true);

      Assert.Equal(results.Count(), 1);
      Assert.Equal(results.First().ErrorMessage, "Status is required");
    }
  }
}
