﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enrollment.Models
{
    public class UserInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
        public bool IsAdmin { get; set; }
    }
}