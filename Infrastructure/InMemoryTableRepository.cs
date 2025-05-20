using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class InMemoryTableRepository : ITableRepository
    {
        private List<Table> tables;

        public InMemoryTableRepository()
        {
            tables = new();

            tables.Add(new Table(1, 5, TablePosition.Interior));
            tables.Add(new Table(2, 4, TablePosition.Interior));
            tables.Add(new Table(3, 2, TablePosition.Interior));
            tables.Add(new Table(4, 10, TablePosition.Exterior));
        }

        public void CreateTable(Table newTable)
        {
            tables.Add(newTable);
        }

        public List<Table> GetTables()
        {
            return tables;
        }

        public void UpdateTable(Table updatedTable)
        {
            var index = tables.FindIndex(t => t.Id == updatedTable.Id);
            if (index != -1)
            {
                tables[index] = updatedTable;
            }
        }

        public void DeleteTable(int id)
        {
            var table = tables.FirstOrDefault(t => t.Id == id);
            if (table != null)
            {
                tables.Remove(table);
            }
        }

    }
}
