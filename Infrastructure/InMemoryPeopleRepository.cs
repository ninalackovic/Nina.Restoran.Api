using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class InMemoryPeopleRepository : IPeopleRepository
    {
        private List<People> people;
        public InMemoryPeopleRepository()
        {
            people = new();
        }

        public void CreatePeople(People newPeople)
        {
            people.Add(newPeople);
        }

        public List<People> GetPeople()
        {
            return people;
        }

        public List<People> Filter(string phoneNumber)
        {
            return people.Where(p => p.PhoneNumber == phoneNumber).ToList();
        }

        public void UpdatePeople(People updatedPerson)
        {
            var index = people.FindIndex(p => p.Id == updatedPerson.Id); //checks if a person w that id exists
            if (index != -1) //if the index isnt nonexistent, person = updatedPerson
            {
                people[index] = updatedPerson;
            }
        }

        public void DeletePeople(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id); //checks if person exists
            if (person != null) //if person isnt nonexistent, removes the person
            {
                people.Remove(person);
            }
        }

    }
}
