﻿using Expedientes_Goya.Areas.Course.Models;
using Expedientes_Goya.Data;
using Expedientes_Goya.Library;
using Expedientes_Goya.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Expedientes_Goya.Areas.Course.Controllers
{
    [Area("Course")]
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private LCourse _lcourse;
        private LCareer _lcareer;
        private SignInManager<IdentityExtends> _signInManager;
        private static DataPager<TCourse> models;
        private static IdentityError IdentityError;
        private ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context, SignInManager<IdentityExtends> signInManager)
        {
            _signInManager = signInManager;
            _lcareer = new LCareer(context);
            _lcourse = new LCourse(context);
        }

        public IActionResult Index(int id, string search, int records)
        {
            if (_signInManager.IsSignedIn(User))
            {
                object[] objects = new object[3];
                var data = _lcourse.GetListCourses(search);
                if(data.Count > 0)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPager<TCourse>().Pager(data, id, records, "Course", "Courses", "Index", url);
                }
                else
                {
                    objects[0] = "No Data";
                    objects[1] = "No Data";
                    objects[2] = new List<TCourse>();
                }

                models = new DataPager<TCourse>
                {
                    List = (List<TCourse>)objects[2],
                    Page_info = (string)objects[0],
                    Page_nav = (string)objects[1],
                    Careers = _lcareer.GetListCareer(),
                    //Professors = _lcourse.GetListProfessor(),
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
        public string CourseRegister(DataPager<TCourse> model)
        {
            if (model.Input.Name != null && model.Input.Description != null && model.Input.CareerID > 0)
            {
                if (model.Input.Hours.Equals(0))
                {
                    return "Insert course hours";
                }
                else
                {
                    var data = _lcourse.CourseRegister(model);
                    return JsonConvert.SerializeObject(data);
                }
            }
            else
            {
                return "Insert all the fields";
            }
        }

        [HttpPost]
        public string CourseDelete(int CourseID)
        {
            var identityError = _lcourse.CourseDelete(CourseID);
            return JsonConvert.SerializeObject(identityError);
        }
    }
}
