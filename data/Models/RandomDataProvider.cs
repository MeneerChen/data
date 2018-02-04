using System.Threading.Tasks;

namespace data.Models
{
    public class RandomDataProvider : IProvideRandomData
    {
        private readonly IProvideLastSensorDataValue _lastSensorDataValue;

        public RandomDataProvider(IProvideLastSensorDataValue lastSensorDataValue)
        {
            _lastSensorDataValue = lastSensorDataValue;
        }

        public async Task<SensorDataValue> ProvideAsync()
        {
            var randomData = SensorDataValue.RandomValue();
            var lastSensorDataValue = await _lastSensorDataValue.ProvideAsync();
            while (randomData.Equals(lastSensorDataValue)) randomData = SensorDataValue.RandomValue();
            return randomData;
        }
    }
}