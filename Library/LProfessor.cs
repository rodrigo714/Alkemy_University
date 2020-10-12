using Alkemy_University.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Library
{
    public class LProfessor
    {
        private ApplicationDbContext _context;

        public LProfessor(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetListProfessor()
        {
            var _selectList = new List<SelectListItem>();
            var professors = (from u in _context._TaspNetUsers
                              join ur in _context._TaspNetUserRoles
                              on u.Id equals ur.UserId
                              join r in _context._TaspNetRoles
                              on ur.RoleId equals r.Id
                              where r.Name == "Professor"
                              select new
                              {   u.Id,
                                  u.FirstName,
                                  u.LastName,
                                  u.Dni,
                                  u.UserName,
                                  u.Email,
                                  u.PhoneNumber,
                                  u.Status,
                                  r.Name
                              }).ToList();

            foreach(var item in professors)
            {
                _selectList.Add(new SelectListItem
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.Id.ToString()
                });
            }

            return _selectList;
        }
    }
}
