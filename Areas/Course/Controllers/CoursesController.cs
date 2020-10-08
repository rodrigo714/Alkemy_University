using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Data;
using Alkemy_University.Library;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alkemy_University.Areas.Course.Controllers
{
    [Area("Course")]
    [Authorize]
    public class CoursesController : Controller
    {
        private LCareer _lcareer;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPager<TCourse> models;
        private static IdentityError IdentityError;
        private ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lcareer = new LCareer(context);
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
            return "FUCK YOU";
        }
    }
}
