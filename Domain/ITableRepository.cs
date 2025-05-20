namespace Nina.Restoran.Api.Domain
{
    public interface ITableRepository
    {
        List<Table> GetTables();

        void CreateTable(Table newTable);
        void UpdateTable(Table updatedTable);
        void DeleteTable(int id);

    }
}
