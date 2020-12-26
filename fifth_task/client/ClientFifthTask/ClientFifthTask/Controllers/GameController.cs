using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientFifthTask.Controllers
{   
    [Route("client")]
    public class GameController : Controller
    {
        [Route("get/page")]
        public IActionResult GetPage()
        {
            return PhysicalFile("~/HtmlPages/FirstPage.html", "text/html");
        }
    }
}
