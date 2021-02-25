using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services
{
    public class UserInterviewTrackerServices : IUserInterviewTrackerServices
    {
        /// <summary>
        /// creating a referance object of IUserInterviewTrackerRepository
        /// </summary>
        private readonly IUserInterviewTrackerRepository _userInterviewTR;

        /// <summary>
        /// injecting IUserInterviewTrackerRepository in consructor to access all methods
        /// </summary>
        public UserInterviewTrackerServices(IUserInterviewTrackerRepository userInterviewTrackerRepository)
        {
            _userInterviewTR = userInterviewTrackerRepository;
        }
        public async Task<bool> DeleteUserById(string UserId)
        {
            //Do Code Here
            var result = await _userInterviewTR.DeleteUserById(UserId);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            //Do Code Here
            var result = await _userInterviewTR.GetAllUser();
            return result;
            //throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            //Do Code Here
            var result = await _userInterviewTR.GetUserById(userId);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<ApplicationUser> Register(ApplicationUser user)
        {
            //Do Code Here
            var result = await _userInterviewTR.Register(user);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<ApplicationUser> UpdateUser(string UserId, ApplicationUser user)
        {
            //Do Code Here
            var result = await _userInterviewTR.UpdateUser(UserId, user);
            return result;
            //throw new NotImplementedException();
        }
    }
}
