using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Interfaces
{
    public interface IUserInterviewTrackerServices
    {
        //List of method to perform all User related operation
        Task<ApplicationUser> Register(ApplicationUser user);
        Task<ApplicationUser> GetUserById(string userId);
        Task<IEnumerable<ApplicationUser>> GetAllUser();
        Task<bool> DeleteUserById(string UserId);
        Task<ApplicationUser> UpdateUser(string UserId, ApplicationUser user);
    }
}
