using System.Threading.Tasks;

namespace data.Models
{
    public interface IProvideLastSensorDataValue
    {
        Task<SensorDataValue> ProvideAsync();
    }
}