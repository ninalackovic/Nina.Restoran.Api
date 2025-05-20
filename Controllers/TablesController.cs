using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nina.Restoran.Api.Controllers.Models;
using Nina.Restoran.Api.Domain;
using Nina.Restoran.Api.Infrastructure;

namespace Nina.Restoran.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private ITableRepository _tableRepository;

        public TablesController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        [HttpGet("all")]
        public IEnumerable<Table> GetTables()
        {
            return _tableRepository.GetTables();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]TableDto newTable)
        {
            Table table = new Table(newTable.Id, newTable.NumberOfChairs, newTable.Position);
            _tableRepository.CreateTable(table);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] TableDto updatedTable)
        {
            var existingTable = _tableRepository.GetTables().FirstOrDefault(t => t.Id == id);
            if (existingTable == null)
            {
                return NotFound();
            }

            existingTable.NumberOfChairs = updatedTable.NumberOfChairs;
            existingTable.Position = updatedTable.Position;

            _tableRepository.UpdateTable(existingTable);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTable = _tableRepository.GetTables().FirstOrDefault(t => t.Id == id);
            if (existingTable == null)
            {
                return NotFound();
            }

            _tableRepository.DeleteTable(id);
            return Ok();
        }

    }
}
