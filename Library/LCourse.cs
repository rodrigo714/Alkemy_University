using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Data;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Library
{
    public class LCourse
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment environment;

        public LCourse(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IdentityError CourseRegister(DataPager<TCourse> model)
        {
            IdentityError identityError;
            try
            {
                if (model.Input.CourseID.Equals(0))
                {
                    var course = new TCourse
                    {
                        Name = model.Input.Name,
                        Description = model.Input.Description,
                        Hours = model.Input.Hours,
                        Status = model.Input.Status,
                        CareerID = model.Input.CareerID
                    };
                    context._TCourse.Add(course);
                    context.SaveChanges();
                }
                else
                {
                    var course = new TCourse
                    {
                        CourseID = model.Input.CourseID,
                        Name = model.Input.Name,
                        Description = model.Input.Description,
                        Hours = model.Input.Hours,
                        Status = model.Input.Status,
                        CareerID = model.Input.CareerID
                    };
                    context._TCourse.Update(course);
                    context.SaveChanges();
                }
                identityError = new IdentityError { Code = "Done" };
            }
            catch(Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }

        internal List<TCourse> GetListCourses(string search)
        {
            List<TCourse> listCourses;
            if (search == null)
            {
                listCourses = context._TCourse.ToList();
            }
            else
            {
                listCourses = context._TCourse.Where(c => c.Name.Contains(search)).ToList();
            }
            return listCourses;
        }
    }
}
