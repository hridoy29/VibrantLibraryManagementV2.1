﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.SearchModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services
{
    public interface IInterestAlerts
    {
        Task<SearchResponse> FetchInterestAlerts(string token);
    }
}