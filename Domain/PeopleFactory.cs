using System.Linq;

namespace Nina.Restoran.Api.Domain
{
    public class PeopleFactory
    {
        private IPeopleRepository _repository;
        public PeopleFactory(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public People Create(int id, string firstName, string lastName, string phoneNumber)
        {
            List<People> peoplesPhoneNumbers = _repository.Filter(phoneNumber);
            bool phoneNumberExist = peoplesPhoneNumbers.Any(r => r.PhoneNumber == phoneNumber);

            if(phoneNumberExist)
            {
                throw new InvalidOperationException("Već postoji taj broj mobitela");
            }

            return new People(id, firstName, lastName, phoneNumber);
        }
    }
}
