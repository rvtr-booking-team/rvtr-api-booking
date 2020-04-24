using System;
using RVTR.Booking.DataContext.Repositories;
using Microsoft.EntityFrameworkCore;
using RVTR.Booking.DataContext.Database;
using Xunit;
using System.Linq;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.UnitTesting.Tests
{
  public class UnitOfWork_Test
  {
    [Fact]
    public void Test_CommitMethod()
    {
      var sut = new UnitOfWork();

      Action actual = () => sut.Commit();

      Assert.IsType<Action>(actual);
    }

    [Fact]
    public void Delete_Status_From_Database()
    {
      var options = new DbContextOptionsBuilder<BookingDbContext>()
          .UseInMemoryDatabase(databaseName: "Delete_Status_From_Database")
          .Options;

      var context = new BookingDbContext(options);
      var unWork = new UnitOfWork(context);
      var StatusRepo = unWork.StatusRepository;
      context.Status.Add(new Status(){StatusId = 2, StatusName = "pending"});
      StatusRepo.Delete(context.Status.Local.First().StatusId);
      unWork.Commit();

      using(var context2 = new BookingDbContext(options))
      {
        Assert.Equal(0, context2.Status.Count());
      }

    }

    [Fact]
    public void Add_status_to_database()
    {
        var TestEntity = new Status(){StatusId = 1, StatusName = "pending"};
        var options = new DbContextOptionsBuilder<BookingDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_status_to_database")
            .Options;

        // Run the test against one instance of the context
        var context = new BookingDbContext(options);
        var unWork = new UnitOfWork(context);
        var StatusRepo = unWork.StatusRepository;
        StatusRepo.Insert(TestEntity);
        unWork.Commit();

        // Use a separate instance of the context to verify correct data was saved to database
        using(var context2 = new BookingDbContext(options))
        {
          Assert.Equal(1, context2.Status.Count());
          Assert.Equal(TestEntity, context.Status.Single());
        }
      }
    }
 }

