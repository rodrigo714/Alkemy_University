using Alkemy_University.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Library
{
    public class LCareer
    {
        private ApplicationDbContext context;

        public LCareer(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
