using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpenDataMontreal.Controllers
{
    public class CrimeController : Controller
    {
        // GET: /<controller>/
        [Route("/[controller]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
