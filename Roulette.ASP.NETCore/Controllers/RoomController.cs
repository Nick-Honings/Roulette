using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Roulette.ASP.NETCore.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("testresult/{number}")]
        public IActionResult Testresult(int number)
        {
            return new JsonResult("This is your number: " + number);
        }
    }
}