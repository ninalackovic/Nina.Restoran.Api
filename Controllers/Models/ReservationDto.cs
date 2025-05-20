using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Controllers.Models
{
    public class ReservationDto
    {
        public int Id { get; private set; }
        public byte NumberOfPeople { get; set; }
        public DateTime TimeOfReservation { get; set; }
        public int TableId { get; set; }
        public int PersonId { get; set; }
    }
}
