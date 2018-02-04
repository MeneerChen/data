using System.Diagnostics;
using System.Threading.Tasks;
using data.Models;
using Microsoft.AspNetCore.Mvc;

namespace data.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHandleDataGeneration _handleDataGeneration;
        private readonly IProvideRandomData _randomData;

        public HomeController(IHandleDataGeneration handleDataGeneration, IProvideRandomData randomData)
        {
            _handleDataGeneration = handleDataGeneration;
            _randomData = randomData;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Random()
        {
            var data = await _randomData.ProvideAsync();
            await _handleDataGeneration.GenerateAsync(data);
            return ViewComponent("SensorData");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}