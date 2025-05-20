using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nina.Restoran.Api.Controllers.Models;
using Nina.Restoran.Api.Domain;
using Nina.Restoran.Api.Infrastructure;

namespace Nina.Restoran.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleRepository _peopleRepository; //field
        private PeopleFactory _peopleFactory;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
            _peopleFactory = new PeopleFactory(_peopleRepository);
        }

        [HttpGet("all")]
        public IEnumerable<People> GetPeople()
        {
            return _peopleRepository.GetPeople();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] PeopleDto newPeople)
        {
           People people = _peopleFactory.Create(
                newPeople.Id,
                newPeople.FirstName,
                newPeople.LastName,
                newPeople.PhoneNumber);
            _peopleRepository.CreatePeople(people);
            return Ok();
        }

        //dal je tel number isti

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] PeopleDto updatedPeople)
        {
            var existingPerson = _peopleRepository.GetPeople().FirstOrDefault(p => p.Id == id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.FirstName = updatedPeople.FirstName;
            existingPerson.LastName = updatedPeople.LastName;
            existingPerson.PhoneNumber = updatedPeople.PhoneNumber;

            _peopleRepository.UpdatePeople(existingPerson);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingPerson = _peopleRepository.GetPeople().FirstOrDefault(p => p.Id == id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            _peopleRepository.DeletePeople(id);
            return Ok();
        }

    }
}
