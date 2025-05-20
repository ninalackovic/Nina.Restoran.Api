using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Controllers.Models
{
    public class PeopleDto
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
