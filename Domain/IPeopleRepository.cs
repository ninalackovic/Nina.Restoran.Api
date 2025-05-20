namespace Nina.Restoran.Api.Domain
{
    public interface IPeopleRepository
    {
        List<People> GetPeople();

        void CreatePeople(People newPeople);

        List<People> Filter(string phoneNumber);

        void UpdatePeople(People updatedPerson);

        void DeletePeople(int id);
    }
}
