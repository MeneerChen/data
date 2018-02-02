using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace data.Models
{
    public class EnsureTableTask : IStartupTask
    {
        private readonly IProvideSqliteConnections _sqliteConnections;

        public EnsureTableTask(IProvideSqliteConnections sqliteConnections)
        {
            _sqliteConnections = sqliteConnections;
        }

        public async Task Run()
        {
            const string sql = "CREATE TABLE IF NOT EXISTS EVENTS(ID INTEGER PRIMARY KEY AUTOINCREMENT,LIJNNUMMER, EVENT, BEGINTIJD, EINDTIJD )";
            using (var connection = await _sqliteConnections.GetAsync())
            {
                await connection.ExecuteAsync(sql, commandType: CommandType.Text);
            }
        }
    }
}