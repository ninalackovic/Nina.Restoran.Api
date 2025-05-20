using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class DatabaseReservationRepository : IReservationRepository
    {
        private RestaurantDbContext _dbContext;

        public DatabaseReservationRepository(RestaurantDbContext restaurantDbContext)
        {
            _dbContext = restaurantDbContext;
        }

        public void CreateReservation(Reservation newReservation)
        {
            _dbContext.Reservations.Add(newReservation);
            _dbContext.SaveChanges();
        }

        public List<Reservation> GetReservations()
        {
            return _dbContext.Reservations.ToList();
        }

        public List<Reservation> Filter(int tableId)
        {
            return _dbContext.Reservations.Where(r => r.TableId == tableId).ToList(); //LINQ
        }
        public void UpdateReservation(Reservation updatedReservation)
        {
            _dbContext.Reservations.Update(updatedReservation);
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
            }
        }

    }
}
