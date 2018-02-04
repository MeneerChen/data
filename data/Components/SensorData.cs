using System.Threading.Tasks;
using data.Models;
using Microsoft.AspNetCore.Mvc;

namespace data.Components
{
    public class SensorData: ViewComponent
    {
        private readonly IProvideSensorData _sensorData;

        public SensorData(IProvideSensorData sensorData)
        {
            _sensorData = sensorData;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sensorDataEntities = await _sensorData.ProvideAsync();
            return View(sensorDataEntities);
        }
    }
}