using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Data;
using Alkemy_University.Library;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Alkemy_University.Areas.Course.Controllers
{
    [Area("Course")]
    [Authorize]
    public class CoursesController : Controller
    {
        private LCourse _lcourse;
        private LCareer _lcareer;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPager<TCourse> models;
        private static IdentityError IdentityError;
        private ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment)
        {
            _signInManager = signInManager;
            _lcareer = new LCareer(context);
            _lcourse = new LCourse(context, environment);
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPager<TCourse>
                {
                    Careers = _lcareer.GetListCareer(),
                    Input = new TCourse()
                };
                return View(models);
            }
            else
            {
                return RedirectToAction("/Home/Index");
            }
        }

        [HttpPost]
        public string GetCourses(DataPager<TCourse> model)
        {
            if (model.Input.Name != null && model.Input.Description != null && model.Input.CareerID > 0)
            {
                if (model.Input.Hours.Equals(0))
                {
                    return "Insert course hours";
                }
                else
                {
                    var data = _lcourse.CourseRegisterAsync(model);
                    return JsonConvert.SerializeObject(data.Result);
                }
            }
            return "FUCK YOU";
        }
    }
}
