using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.ObjectModel.Models;
using RVTR.Booking.DataContext.Repositories;

namespace RVTR.Booking.WebApi.Controllers
{
  /// <summary>
  /// api controller that guides reservation http requests
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class ReservationController : ControllerBase
  {
    private readonly ILogger<ReservationController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Dependency Injection
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public ReservationController(ILogger<ReservationController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get method for all all reservations
    /// </summary>
    /// <returns>List of Reservations</returns>
    [HttpGet]
    public async Task<IEnumerable<Reservation>> Get()
    {
      var reservation = _unitOfWork.ReservationRepository.Select();
      return await Task.FromResult<IEnumerable<Reservation>>(reservation);
    }

    /// <summary>
    /// Get method for specific reservation
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Reservation</returns>
    [HttpGet("{id}")]
    public async Task<Reservation> GetOne(int id)
    {
      var reservation = _unitOfWork.ReservationRepository.Select(id);
      return await Task.FromResult<Reservation>(reservation);
    }

    /// <summary>
    /// Post method for reservations
    /// </summary>
    /// <param name="reservation"></param>
    /// <returns>Request success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Reservation reservation) {
      var success = await Task.FromResult<bool>(_unitOfWork.ReservationRepository.Insert(reservation));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Put method for reservations
    /// </summary>
    /// <param name="reservation"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Reservation reservation)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.ReservationRepository.Update(reservation));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete method for reservations
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
      var success = await Task.FromResult<bool>(_unitOfWork.ReservationRepository.Delete(id));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }
  }
}
