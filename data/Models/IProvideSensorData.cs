using System.Collections.Generic;
using System.Threading.Tasks;

namespace data.Models
{
    public interface IProvideSensorData
    {
        Task<IEnumerable<SensorDataEntity>> ProvideAsync();
    }
}