using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using data.Models;

namespace data.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvideSensorData _sensorData;

        public HomeController(IProvideSensorData sensorData)
        {
            _sensorData = sensorData;
        }

        public async Task<IActionResult> Index()
        {
            var sensorDataEntities = await _sensorData.ProvideAsync(); 
            return View(sensorDataEntities);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
