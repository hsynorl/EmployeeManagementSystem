﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Common.ViewModel
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public DateTime TokenExpire { get; set; }
    }
}
