﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.LoanModels
{
    public class LoanResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Loan Result { get; set; }
    }
}
