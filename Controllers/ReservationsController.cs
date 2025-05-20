using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nina.Restoran.Api.Controllers.Models;
using Nina.Restoran.Api.Domain;
using Nina.Restoran.Api.Infrastructure;

namespace Nina.Restoran.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationRepository _reservationRepository;

        private ReservationFactory _reservationFactory;

        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _reservationFactory = new ReservationFactory(_reservationRepository);
        }

        [HttpGet("all")]
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationRepository.GetReservations();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ReservationDto newReservation)
        {
            Reservation reservation = _reservationFactory.Create(
                newReservation.Id, 
                newReservation.NumberOfPeople, 
                newReservation.TimeOfReservation, 
                newReservation.TableId,
                newReservation.PersonId);
            _reservationRepository.CreateReservation(reservation);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ReservationDto updatedReservation)
        {
            var existingReservation = _reservationRepository.GetReservations().FirstOrDefault(r => r.Id == id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.NumberOfPeople = updatedReservation.NumberOfPeople;
            existingReservation.TimeOfReservation = updatedReservation.TimeOfReservation;
            existingReservation.TableId = updatedReservation.TableId;
            existingReservation.PersonId = updatedReservation.PersonId;

            _reservationRepository.UpdateReservation(existingReservation);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingReservation = _reservationRepository.GetReservations().FirstOrDefault(r => r.Id == id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            _reservationRepository.DeleteReservation(id);
            return Ok();
        }

    }
}
