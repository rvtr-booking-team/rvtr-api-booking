using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RVTR.Booking.DataContext.Database;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.WebApi
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddCors(cors =>
      {
        cors.DefaultPolicyName = "default";

        cors.AddDefaultPolicy(policy =>
        {
          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
      });

      services.AddDbContext<BookingDbContext>(opt => opt.UseInMemoryDatabase("bookingdb"));

      // services.AddScoped<IUnitOfWork, UnitOfWork>();
      // services.AddScoped<Repository<Reservation>>();
      // services.AddScoped<Repository<Duration>>();
      // Register the Swagger services
      services.AddSwaggerDocument();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseCors();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      // Register the Swagger generator and the Swagger UI middlewares
      app.UseOpenApi();
      app.UseSwaggerUi3();

      using(var servicesScope = app.ApplicationServices.CreateScope())
      {
        var context = servicesScope.ServiceProvider.GetService<BookingDbContext>();
        AddTestData(context);
      }

    }

    private static void AddTestData(BookingDbContext context)
{
    var testStatus = new Status()
    {
        StatusId = 1,
        StatusName = "pending",
    };

    context.Status.Add(testStatus);

    var testduration = new Duration()
    {
     DurationId = 1,
     CheckIn =  new System.DateTime(),
     CheckOut = new System.DateTime(),
     CreationDate = new System.DateTime(),
     ModifiedDate = new System.DateTime(),
     Reservation = null,
     ReservationId = 1
    };

    context.Duration.Add(testduration);

    context.SaveChanges();
    }
  }
}
