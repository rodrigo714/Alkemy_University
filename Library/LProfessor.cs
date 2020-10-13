using Expedientes_Goya.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Library
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
