using Alkemy_University.Areas.Career.Models;
using Alkemy_University.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alkemy_University.Library
{
    public class LCareer
    {
        private ApplicationDbContext _context;

        public LCareer(ApplicationDbContext context)
        {
            _context = context;
        }

        public IdentityError CareerRegistration(TCareer career)
        {
            IdentityError identityError;
            try
            {
                if (career.CareerID.Equals(0))
                {
                     _context.Add(career);
                }
                else
                {
                    _context.Update(career);
                }
                _context.SaveChanges();
                identityError = new IdentityError { Code = "Done" };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }

        internal List<TCareer> getTCareer(string search)
        {
            List<TCareer> ListCareers;
            if(search == null)
            {
                ListCareers = _context._TCareer.ToList();
            }
            else
            {
                ListCareers = _context._TCareer.Where(c=>c.Name.Contains(search)).ToList();
            }
            return ListCareers;
        }

        internal IdentityError CareerDelete(int _CareerID)
        {
            IdentityError identityError;
            try
            {
                var career = new TCareer
                {
                    CareerID = _CareerID
                };
                _context._TCareer.Remove(career);
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

        public List<SelectListItem> GetListCareer()
        {
            var _selectList = new List<SelectListItem>();
            var careers = _context._TCareer.Where(c => c.Status.Equals(true)).ToList();
            foreach(var item in careers)
            {
                _selectList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CareerID.ToString()
                });
            }
            return _selectList;
        }
    }
}
