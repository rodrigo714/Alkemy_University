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
        private ApplicationDbContext _context;

        public LCourse(ApplicationDbContext context)
        {
            _context = context;
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
                    _context._TCourse.Add(course);
                    _context.SaveChanges();
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
                    _context._TCourse.Update(course);
                    _context.SaveChanges();
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

        internal IdentityError CourseDelete(int _CourseID)
        {
            IdentityError identityError;
            try
            {
                var course = new TCourse
                {
                    CourseID = _CourseID
                };
                _context._TCourse.Remove(course);
                _context.SaveChanges();
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
                listCourses = _context._TCourse.ToList();
            }
            else
            {
                listCourses = _context._TCourse.Where(c => c.Name.Contains(search)).ToList();
            }
            return listCourses;
        }
    }
}
