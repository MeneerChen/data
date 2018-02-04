using System.Threading.Tasks;

namespace data.Models
{
    public interface IProvideRandomData
    {
        Task<SensorDataValue> ProvideAsync();
    }
}