﻿using Disaster_demo.Models.Entities;

namespace Disaster_demo.Services
{
    public interface IVolunteerServices
    {
        Task<IEnumerable<AidRequests>> GetEmergencyAidRequestsForVolunteerAsync(int volunteerId);
        Task<IEnumerable<AidRequests>> GetNonEmergencyAidRequestsForVolunteerAsync(int volunteerId);
        Task<LoginResponseDTO?> GetVolunteerDetailsAsync(string userId);
        Task<List<Volunteer>> GetVolunteersByDistrictAsync(string district);
        Task<List<Volunteer>> GetVolunteersByDsDivisionAsync(string divisionalSecretariat);
        Task<int> SignupAsync(VolunteerSignupDTO dto);
        Task<bool> UpdateAvailabilityAsync(int userId, AvailabilityStatus newStatus);
    }
}