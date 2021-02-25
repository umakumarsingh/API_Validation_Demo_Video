using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Interfaces
{
    public interface IInterviewTrackerServices
    {
        //List of method to perform all User related operation
        Task<Interview> AddInterview(Interview interview);
        Task<Interview> GetInterviewrById(string interviewId);
        Task<IEnumerable<Interview>> GetAllInterview();
        Task<bool> DeleteInterviewById(string interviewId);
        Task<Interview> UpdateInterview(string interviewId, Interview interview);
        long TotalCount();
        Task<IEnumerable<Interview>> InterviewByName(string name);

    }
}
