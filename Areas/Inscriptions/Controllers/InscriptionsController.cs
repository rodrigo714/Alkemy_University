using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alkemy_University.Areas.Inscriptions.Controllers
{
    public class InscriptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
