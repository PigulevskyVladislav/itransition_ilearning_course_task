using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ServerFifthTask.Controllers
{   
    public class GameController : Controller
    {
        [Route("home/")]
        public IActionResult Home()
        {
            //return File("~/js/home.html", "text/html");
            return View();
        }

        [Route("lobby/")]
        public IActionResult Lobby()
        {
            return Content("START!");
        }

        [Route("start/")]
        public IActionResult Start()
        {
            return Content("START!");
        }
    }
}
