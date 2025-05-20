using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Controllers.Models
{
    public class TableDto
    {
        public int Id { get; set; }
        public int NumberOfChairs { get; set; }
        public TablePosition Position { get; set; }
    }
}
