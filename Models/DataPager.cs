using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Models
{
    public class DataPager<T>
    {
        public List<T> List { get; set; }
        public string Page_info { get; set; }
        public string Page_nav { get; set; }
        public T Input { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }

        public string ErrorMessage { get; set; }
    }
}
