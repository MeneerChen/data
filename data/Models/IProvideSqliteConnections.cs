using System.Data;
using System.Threading.Tasks;

namespace data.Models
{
    public interface IProvideSqliteConnections
    {
        Task<IDbConnection> GetAsync();
    }
}
