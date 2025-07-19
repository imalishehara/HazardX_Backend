using Disaster_demo.Models.Entities;

namespace Disaster_demo.Services
{
    public interface IVolunteerServices
    {
        Task<LoginResponseDTO?> GetVolunteerDetailsAsync(string userId);
        Task<List<Volunteer>> GetVolunteersByDsDivisionAsync(string divisional_secretariat);
        Task<int> SignupAsync(VolunteerSignupDTO dto);
        Task<List<Volunteer>> GetVolunteersByDistrictAsync(string district);
        Task<bool> UpdateAvailabilityAsync(int userId, AvailabilityStatus newStatus);


    }
}