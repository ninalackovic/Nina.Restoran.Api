namespace Nina.Restoran.Api.Domain
{
    public class Reservation
    {
        public Reservation(int id, byte numberOfPeople, DateTime timeOfReservation, int tableId, int personId)
        {
            Id = id;
            NumberOfPeople = numberOfPeople;
            TimeOfReservation = timeOfReservation;
            TableId = tableId;
            PersonId = personId;
        }

        public int Id { get; private set; }
        public byte NumberOfPeople { get; set; }
        public DateTime TimeOfReservation { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }

        public int PersonId { get; set; }
        public People People { get; set; }
    }
}
