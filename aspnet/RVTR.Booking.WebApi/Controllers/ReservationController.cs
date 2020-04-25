using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.ObjectModel.Models;
using RVTR.Booking.DataContext.Repositories;

namespace RVTR.Booking.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class ReservationController : ControllerBase
  {
    private readonly ILogger<ReservationController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public ReservationController(ILogger<ReservationController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<Reservation>> Get()
    {
      var reservation = _unitOfWork.ReservationRepository.Select();
      return await Task.FromResult<IEnumerable<Reservation>>(reservation);
    }

    [HttpGet("{id}")]
    public async Task<Reservation> GetOne(int id)
    {
      var reservation = _unitOfWork.ReservationRepository.Select(id);
      return await Task.FromResult<Reservation>(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Reservation reservation) {
      var success = await Task.FromResult<bool>(_unitOfWork.ReservationRepository.Insert(reservation));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id){
      var success = await Task.FromResult<bool>(_unitOfWork.ReservationRepository.Delete(id));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Reservation reservation)
    {
      await Task.FromResult(_unitOfWork.ReservationRepository.Update(reservation));
      return Ok();
    }
  }
}
