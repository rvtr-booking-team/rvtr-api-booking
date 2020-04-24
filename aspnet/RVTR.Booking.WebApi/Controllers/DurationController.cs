using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("[controller]")]
  public class DurationController : ControllerBase
  {
    private readonly ILogger<DurationController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public DurationController(ILogger<DurationController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<Duration> Get()
    {
      return await Task.FromResult<Duration>(new Duration());
    }
    
    [HttpPost]
    public async Task<Duration> Post(Duration book) 
    {
      return await Task.FromResult<Duration>(book);
    }
  }
}
