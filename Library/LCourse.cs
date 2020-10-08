using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Data;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IdentityError> CourseRegisterAsync(DataPager<TCourse> model)
        {

        }
    }
}
