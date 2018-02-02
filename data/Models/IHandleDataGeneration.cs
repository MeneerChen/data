using System.Threading.Tasks;

namespace data.Models
{
    public interface IHandleDataGeneration
    {
        Task GenerateAsync(SensorDataValue sensorDataValue);
    }
}