using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class DatabaseTableRepository : ITableRepository
    {
        private RestaurantDbContext _dbContext;

        public DatabaseTableRepository(RestaurantDbContext restaurantDbContext)
        {
            _dbContext = restaurantDbContext;    
        }

        public void CreateTable(Table newTable)
        {
            _dbContext.Tables.Add(newTable);
            _dbContext.SaveChanges();
        }

        public List<Table> GetTables()
        {
            return _dbContext.Tables.ToList();
        }

        public void UpdateTable(Table updatedTable)
        {
            _dbContext.Tables.Update(updatedTable);
            _dbContext.SaveChanges();
        }

        public void DeleteTable(int id)
        {
            var table = _dbContext.Tables.FirstOrDefault(t => t.Id == id);
            if (table != null)
            {
                _dbContext.Tables.Remove(table);
                _dbContext.SaveChanges();
            }
        }

    }
}
