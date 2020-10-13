using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Expedientes_Goya.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Expedientes_Goya.Library;
using Expedientes_Goya.Areas.Course.Models;
using Expedientes_Goya.Data;

namespace Expedientes_Goya.Controllers
{
    public class HomeController : Controller
    {
        private LCourse _lcourse;
        private IdentityError _identityError;
        private DataCourse _dataCourse;
        public static DataPager<TCourse> model;
        public SignInManager<IdentityExtends> _signInManager;
        public UserManager<IdentityExtends> _userManager;
        //private IServiceProvider _serviceprovider;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider, ApplicationDbContext context,
            SignInManager<IdentityExtends> signInManager, UserManager<IdentityExtends> userManager)
        {
            _logger = logger;
            _lcourse = new LCourse(context);
            _signInManager = signInManager;
            _userManager = userManager;
            //_serviceprovider = serviceProvider;
        }

        public IActionResult Index(int page, string search)
        {
            Object[] objects = new Object[3];
            var data = _lcourse.GetListCourses(search);
            if(data.Count > 0)
            {
                var url = Request.Scheme + "://" + Request.Host.Value;
                objects = new LPager<TCourse>().Pager(data, page, 5, "", "Home", "Index", url);
            }
            else
            {
                objects[0] = "No data";
                objects[1] = "No data";
                objects[2] = new List<TCourse>();
            }

            model = new DataPager<TCourse>
            {
                List = (List<TCourse>)objects[2],
                Page_info = (string)objects[0],
                Page_nav = (string)objects[1],
                Input = new TCourse()
            };
            if(_identityError != null)
            {
                model.Page_info = _identityError.Description;
                _identityError = null;
            }

            //await CreateRolesAsync(_serviceprovider);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _lcourse.GetCourseCareer(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityExtends>>();
            String[] rolesName = { "Admin", "Student" };
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
            var user = await userManager.FindByIdAsync("56958b68-baff-4375-9279-cf839033a3a6");
            await userManager.AddToRoleAsync(user, "Admin");
        }

        public async Task<IActionResult> Inscription(int CourseID, int view)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                var userID = await _userManager.GetUserIdAsync(user);
                var data = _lcourse.Inscription(CourseID, userID);
                if (data.Code == "Done")
                {
                    return Redirect("/Inscriptions/Index?area=Inscriptions");
                }
                else
                {
                    _identityError = data;
                    if (view == 1)
                    {
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        _dataCourse = _lcourse.GetCourseCareer(CourseID);
                        _dataCourse.ErrorMessage = data.Description;
                        return RedirectToPage("/Home/Details", _dataCourse);
                    }
                }
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
    }
}
