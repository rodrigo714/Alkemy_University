using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_University.Areas.Career.Models;
using Alkemy_University.Controllers;
using Alkemy_University.Data;
using Alkemy_University.Library;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Alkemy_University.Areas.Career.Controllers
{
    [Area("Career")]
    [Authorize]
    public class CareersController : Controller
    {
        private TCareer _career;
        private LCareer _lcareer;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPager<TCareer> models;

        public CareersController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lcareer = new LCareer(context);
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPager<TCareer>
                {
                    Input = new TCareer()
                };
                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Index");
            }
        }

        public IActionResult GetCareer()
        {
            return View("Index");
        }

        [HttpPost]
        public string GetCareer(DataPager<TCareer> model)
        {
            if(model.Input.Name != null && model.Input.Description != null)
            {
                var data = _lcareer.CareerRegistration(model.Input);
                return JsonConvert.SerializeObject(data);
            }
            else
            {
                return "Fill all the required fields";
            }
        }
    }
}
