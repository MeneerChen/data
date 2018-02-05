using System.Threading.Tasks;
using data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace data.Controllers
{
    public class DataController : Controller
    {
        private readonly IHandleDataGeneration _handleDataGeneration;

        public DataController(IHandleDataGeneration handleDataGeneration)
        {
            _handleDataGeneration = handleDataGeneration;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Outofbed()
        {
            var data = new SensorDataValue("Outofbed");
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }
        public async Task<IActionResult> Leftside()
        {
            var data = new SensorDataValue("Leftside");
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }
        public async Task<IActionResult> Rightside()
        {
            var data = new SensorDataValue("Rightside");
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }
        public async Task<IActionResult> Back()
        {
            var data = new SensorDataValue("Back");
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }
        public async Task<IActionResult> Belly()
        {
            var data = new SensorDataValue("Belly");
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }

    }
}
