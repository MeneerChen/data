using System.Threading.Tasks;

namespace data.Models
{
    public interface IGenerateSensorData
    {
        Task GenerateAsync(SensorData sensorData);
    }
}