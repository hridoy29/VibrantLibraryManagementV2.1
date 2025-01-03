﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.InterestAlertsModel;
using VibrantLibraryManagementV2.Core.Models.LoanModels;
using VibrantLibraryManagementV2.Core.Models.ReservationModels;
using VibrantLibraryManagementV2.Core.Models.SearchModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services
{
    public interface IInterestService
    {
        public Task<InterestResponse> GetInterests();
        public Task<SearchResponse> FetchAreaOfInterestAsync(string token);
        public Task<InterestedApiResponse> FetchInterestedResourcesAsync(string token);
        public Task<LoanResponse> GetLoans(string token);
        public Task<ReservationResponse> GetReservations(string token);
    }
}
