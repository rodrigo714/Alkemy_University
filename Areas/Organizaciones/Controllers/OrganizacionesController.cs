using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Expedientes_Goya.Areas.Principal.Controllers
{
    [Area("Organizaciones")]
    public class OrganizacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
