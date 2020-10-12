﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Models
{
    public class IdentityExtends : IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DNI { get; set; }
        public bool Status { get; set; }
    }
}