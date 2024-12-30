using Infrastructure.Data;


namespace Infrastructure.Repository
{
    public class SqlDatabaseRepository
    {
        private readonly ApplicationDbContext _db;
        public SqlDatabaseRepository(ApplicationDbContext db)
        {
            _db = db;

        }

    }
}
