using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class InMemoryReservationRepository : IReservationRepository
    {
        private List<Reservation> reservations;

        public InMemoryReservationRepository()
        {
            reservations = new();
        }

        public void CreateReservation(Reservation newReservation)
        {
            reservations.Add(newReservation);
        }

        public List<Reservation> GetReservations()
        {
            return reservations;
        }

        public List<Reservation> Filter(int tableId)
        {
            return reservations.Where(p => p.TableId == tableId).ToList();
        }

        public void UpdateReservation(Reservation updatedReservation)
        {
            var index = reservations.FindIndex(r => r.Id == updatedReservation.Id);
            if (index != -1)
            {
                reservations[index] = updatedReservation;
            }
        }

        public void DeleteReservation(int id)
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                reservations.Remove(reservation);
            }
        }

    }
}
