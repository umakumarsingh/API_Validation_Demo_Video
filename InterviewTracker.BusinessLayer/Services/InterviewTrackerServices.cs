using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services
{
    public class InterviewTrackerServices : IInterviewTrackerServices
    {
        /// <summary>
        /// creating a referance object of IInterviewTrackerRepository
        /// </summary>
        private readonly IInterviewTrackerRepository _interviewTR;

        /// <summary>
        /// injecting IInterviewTrackerRepository in consructor to access all methods
        /// </summary>
        public InterviewTrackerServices(IInterviewTrackerRepository interviewTrackerRepository)
        {
            _interviewTR = interviewTrackerRepository;
        }
        public async Task<Interview> AddInterview(Interview interview)
        {
            //Do Code Here
            var result = await _interviewTR.AddInterview(interview);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteInterviewById(string interviewId)
        {
            //Do code here
            var result = await _interviewTR.DeleteInterviewById(interviewId);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interview>> GetAllInterview()
        {
            //Do code here
            var result = await _interviewTR.GetAllInterview();
            return result;
            //throw new NotImplementedException();
        }

        public async Task<Interview> GetInterviewrById(string interviewId)
        {
            //Do Code Here
            var result = await _interviewTR.GetInterviewrById(interviewId);
            return result;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interview>> InterviewByName(string name)
        {
            //Do Code Here
            var result = await _interviewTR.InterviewByName(name);
            return result;
            //throw new NotImplementedException();
        }

        public long TotalCount()
        {
            //Do Code Here
            return _interviewTR.TotalCount();
            //throw new NotImplementedException();
        }

        public async Task<Interview> UpdateInterview(string interviewId, Interview interview)
        {
            //Do Code Here
            var result = await _interviewTR.UpdateInterview(interviewId, interview);
            return result;
            //throw new NotImplementedException();
        }
    }
}
