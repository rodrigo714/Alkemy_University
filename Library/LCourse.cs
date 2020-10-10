using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Areas.Inscriptions.Models;
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

        public DataCourse GetCourseCareer(int id)
        {
            DataCourse dataCourse = null;
            var query = _context._TCareer.Join(_context._TCourse,
                c => c.CareerID,
                d => d.CourseID,
                (c,d)=> new
                {
                    c.CareerID,
                    d.Name,
                    d.CourseID,
                    d.Description,
                    d.Hours,
                    d.Status,
                }).Where(e => e.CourseID.Equals(id)).ToList();

            if (!query.Count().Equals(0))
            {
                var data = query.Last();
                dataCourse = new DataCourse
                {
                    CourseID = data.CourseID,
                    Name = data.Name,
                    Description = data.Description,
                    Hours = data.Hours,
                    Status = data.Status,
                    CareerID = data.CareerID
                };
            }
            return dataCourse;
        }

        public IdentityError Inscription(int CourseID, string UserID)
        {
            IdentityError identityError;
            try
            {
                var courseInscription = _context._TInscription.Where(c => c.CourseID.Equals(CourseID) 
                    && c.StudentID.Equals(UserID)).ToList();
                if (courseInscription.Count.Equals(0))
                {
                    var course = GetCourseCareer(CourseID);
                    var inscription = new Inscription
                    {
                        StudentID = UserID,
                        Date = DateTime.Now,
                        CourseID = CourseID,
                    };
                    _context.Add(inscription);
                    _context.SaveChanges();
                    identityError = new IdentityError { Code = "Done" };
                }
                else 
                {
                    identityError = new IdentityError { Description = "Student already suscribed" };
                }
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
    }
}
