using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RVTR.Booking.DataContext.Database;
using RVTR.Booking.DataContext.Repositories;

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
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      
      services.AddDbContext<BookingDbContext>(opt =>
        opt.UseInMemoryDatabase("bookingdb"));

      // Register the Swagger services
      services.AddSwaggerDocument();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
    }
  }
}
