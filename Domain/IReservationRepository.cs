namespace Nina.Restoran.Api.Domain
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();

        void CreateReservation(Reservation newReservation);

        List<Reservation> Filter(int tableId);
        void UpdateReservation(Reservation updatedReservation);
        void DeleteReservation(int id);

    }
}
