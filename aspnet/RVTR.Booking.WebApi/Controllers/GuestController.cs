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
  [Route("[controller]/[action]")]
  public class GuestController : ControllerBase
  {
    private readonly ILogger<GuestController> _logger;
    private readonly UnitOfWork _unitOfWork;

    public GuestController(ILogger<GuestController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<Guest>> Get()
    {
      return await Task.FromResult<IEnumerable<Guest>>(_unitOfWork.GuestRepository.Select());
    }

    [HttpGet]
    public async Task<Guest> GetOne(int id)
    {
      return await Task.FromResult<Guest>(_unitOfWork.GuestRepository.Select(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guest guest)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Insert(guest));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guest guest)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Update(guest));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Delete(id));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
