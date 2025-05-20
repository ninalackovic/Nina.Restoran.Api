using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class DatabasePeopleRepository : IPeopleRepository
    {
        private RestaurantDbContext _dbContext;
        public DatabasePeopleRepository(RestaurantDbContext restaurantDbContext)
        {
            _dbContext = restaurantDbContext;
        }

        public void CreatePeople(People newPeople)
        {
            _dbContext.People.Add(newPeople);
            _dbContext.SaveChanges();
        }

        public List<People> GetPeople()
        {
            return _dbContext.People.ToList();
        }

        public List<People> Filter(string phoneNumber)
        {
            return _dbContext.People.Where(r => r.PhoneNumber == phoneNumber).ToList();
        }

        public void UpdatePeople(People updatedPerson)
        {
            _dbContext.People.Update(updatedPerson);
            _dbContext.SaveChanges();
        }

        public void DeletePeople(int id)
        {
            var person = _dbContext.People.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _dbContext.People.Remove(person);
                _dbContext.SaveChanges();
            }
        }

    }
}
