using System.Linq;

namespace Nina.Restoran.Api.Domain
{
    public class ReservationFactory
    {
        private IReservationRepository _repository;
        public ReservationFactory(IReservationRepository repository)
        {
            _repository = repository;
        }
        public Reservation Create(int id, byte numberOfPeople, DateTime timeOfReservation, int tableId, int personId)
        {
            List<Reservation> reservationsForTable = _repository.Filter(tableId);
            bool reservationExist = reservationsForTable.Any(r => r.TimeOfReservation == timeOfReservation);

            if(reservationExist)
            {
                throw new InvalidOperationException("Postoji rezervacija za taj stol");
            }

            return new Reservation(id, numberOfPeople, timeOfReservation, tableId, personId);
        }
    }
}
