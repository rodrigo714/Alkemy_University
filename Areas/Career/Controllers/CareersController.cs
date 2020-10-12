using System.Collections.Generic;
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
    [Authorize(Roles = "Admin")]
    public class CareersController : Controller
    {
        private TCareer _career;
        private LCareer _lcareer;
        private SignInManager<IdentityExtends> _signInManager;
        private static DataPager<TCareer> models;

        public CareersController(ApplicationDbContext context, SignInManager<IdentityExtends> signInManager)
        {
            _signInManager = signInManager;
            _lcareer = new LCareer(context);
        }

        public IActionResult Index(int id, string Search, int Records)
        {
            if (_signInManager.IsSignedIn(User))
            {
                object[] objects = new object[3];
                var data = _lcareer.getTCareer(Search);
                if(data.Count > 0)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPager<TCareer>().Pager(_lcareer.getTCareer(Search), id, Records, "Career", "Careers", "Index", url);
                }
                else
                {
                    objects[0] = "No Data";
                    objects[1] = "No Data";
                    objects[2] = new List<TCareer>();
                }

                models = new DataPager<TCareer>
                {
                    List = (List<TCareer>)objects[2],
                    Page_info = (string)objects[0],
                    Page_nav = (string)objects[1],
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

        [HttpPost]
        public string DeleteCareer(int CareerID)
        {
            var identityError = _lcareer.CareerDelete(CareerID);
            return JsonConvert.SerializeObject(identityError);
        }
    }
}
