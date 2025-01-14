﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.InterestAlertsModel
{
    public class InterestedResponse
    {
        public int NumFound { get; set; }
        public int Start { get; set; }
        public bool NumFoundExact { get; set; }
        public List<InterestedDoc> Docs { get; set; }
    }
}
