using System;
using System.Threading.Tasks;

namespace data.Models
{
    public class DataGenerationHandler : IHandleDataGeneration
    {
        private readonly IGenerateSensorData _generateSensorData;
        private readonly IProvideLastSensorDataValue _lastSensorDataValue;

        public DataGenerationHandler(IGenerateSensorData generateSensorData, IProvideLastSensorDataValue lastSensorDataValue)
        {
            _generateSensorData = generateSensorData;
            _lastSensorDataValue = lastSensorDataValue;
        }

        public async Task GenerateAsync(SensorDataValue sensorDataValue)
        {
            var lastSensorDataValue = await _lastSensorDataValue.ProvideAsync();
            if (sensorDataValue.Equals(lastSensorDataValue)) return;
            var sensorData = new SensorData
            {
                SensorDataValue = sensorDataValue,
                SensorDataCreated = DateTime.UtcNow
            };

            await _generateSensorData.GenerateAsync(sensorData);
        }
    }
}