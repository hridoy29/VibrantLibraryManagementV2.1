﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class LoginResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
    }
}
