using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_University.Data;
using Alkemy_University.Library;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alkemy_University.Areas.Inscriptions.Controllers
{
    [Area("Inscriptions")]
    public class InscriptionsController : Controller
    {
        private LCourse _lCourse;
        private DataPager<DataCourse> _dataPager;
        private IdentityError _identityError;
        private SignInManager<IdentityUser> _signinManager;
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;

        public InscriptionsController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _context = context;
            _lCourse = new LCourse(_context);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
