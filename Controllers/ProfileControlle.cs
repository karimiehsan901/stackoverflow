using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stack.Controllers
{
    public class ProfileControlle : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
