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
        public async Task<IActionResult> Index()
        {
            var control = AutoGenerateTask.Control;
            return View(control);
        }

        public IActionResult GetSensorData()
        {
            return ViewComponent("SensorData");
        }

        [HttpGet]
        public Guid GetRivision()
        {
            return AutoGenerateTask.Revision;
        }

        [HttpPost]
        public void SetAutoGenerate([FromBody] SetAutoGenerateModel model)
        {
            AutoGenerateTask.Control.Enable = model.SwitchValue;
            AutoGenerateTask.Control.RandomWaitTime = new RandomWaitTime(model.FromRandom, model.ToRandom);
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