namespace Nina.Restoran.Api.Domain
{
    public class Table
    {
        public Table(int id)
        {
            Id = id;
            NumberOfChairs = 4;
            Position = TablePosition.Interior;
        }

        public Table(int id, int numberOfChairs, TablePosition position) : this(id)
        {
            NumberOfChairs = numberOfChairs;
            Position = position;
        }

        public int Id { get; private set; }

        public int NumberOfChairs { get; set; }
        
        public TablePosition Position { get; set; }
    }
}
