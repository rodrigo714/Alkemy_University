using Alkemy_University.Areas.Career.Models;
using Alkemy_University.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                _context.Add(career);
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
    }
}
