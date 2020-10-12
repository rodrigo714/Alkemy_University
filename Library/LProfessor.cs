using Alkemy_University.Data;
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


    }
}
