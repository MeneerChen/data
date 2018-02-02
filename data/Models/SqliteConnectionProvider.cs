using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace data.Models
{
    public class SqliteConnectionProvider : IProvideSqliteConnections
    {
        private readonly ISqliteSettings _settings;

        public SqliteConnectionProvider(ISqliteSettings settings)
        {
            _settings = settings;
        }

        public async Task<IDbConnection> GetAsync()
        {
            var connection = new SqliteConnection(_settings.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}