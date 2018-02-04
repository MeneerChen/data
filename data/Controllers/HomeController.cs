using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data.Models;
using Microsoft.AspNetCore.Mvc;

namespace data.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutoGenerateTask _autoGenerateTask;
        private readonly IHandleDataGeneration _handleDataGeneration;
        private readonly IProvideRandomData _randomData;

        public HomeController(IHandleDataGeneration handleDataGeneration, IProvideRandomData randomData,
            IEnumerable<IStartupTask> startuptasks)
        {
            _handleDataGeneration = handleDataGeneration;
            _randomData = randomData;
            _autoGenerateTask = startuptasks.FirstOrDefault(x=>x.GetType() == typeof(AutoGenerateTask)) as AutoGenerateTask;
        }

        public async Task<IActionResult> Index()
        {
            var switchValue = _autoGenerateTask.GetSwitchValue();
            return View(switchValue);
        }

        public IActionResult GetSensorData()
        {
            return ViewComponent("SensorData");
        }

        [HttpGet]
        public Guid GetRivision()
        {
            return _autoGenerateTask.GetRivision();
        }

        [HttpPost]
        public void SetAutoGenerate([FromBody]SetAutoGenerateModel model)
        {
            _autoGenerateTask.SetRandom(model.FromRandom,model.ToRandom);
            _autoGenerateTask.Switch(model.SwitchValue);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }

    public class SetAutoGenerateModel
    {
        public bool SwitchValue { get; set; }
        public int FromRandom { get; set; }
        public int ToRandom { get; set; }

    }
}