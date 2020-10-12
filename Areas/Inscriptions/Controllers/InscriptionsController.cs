using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_University.Data;
using Alkemy_University.Library;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alkemy_University.Areas.Inscriptions.Controllers
{
    [Area("Inscriptions")]
    //[Authorize(Roles = "Student, Admin")]
    public class InscriptionsController : Controller
    {
        private LCourse _lCourse;
        private DataPager<DataCourse> _dataPager;
        private IdentityError _identityError;
        private SignInManager<IdentityUser> _signinManager;
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;
        private DataPager<DataCourse> model;

        public InscriptionsController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _context = context;
            _lCourse = new LCourse(_context);
        }

        public async Task<IActionResult> Index(int page, string search, int records)
        {
            if (_signinManager.IsSignedIn(User))
            {
                object[] objects = new object[3];
                var user = await _userManager.GetUserAsync(User);
                var userID = await _userManager.GetUserIdAsync(user);
                var data = _lCourse.Inscriptions(userID, search);
                if (data.Count > 0)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPager<DataCourse>().Pager(data, page, records, "Inscriptions", "Inscriptions", "Index", url);
                }
                else
                {
                    objects[0] = "No Data";
                    objects[1] = "No Data";
                    objects[2] = new List<DataCourse>();
                }
                model = new DataPager<DataCourse>
                {
                    Page_info = (string)objects[0],
                    Page_nav = (string)objects[1],
                    List = (List<DataCourse>)objects[2],
                    Input = new DataCourse()
                };
                return View(model);
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        public IActionResult Details(int id)
        {
            var model = _lCourse.GetCourseCareer(id);
            return View(model);
        }
    }
}
