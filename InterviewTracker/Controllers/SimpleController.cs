using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.ViewModels;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IInterviewTrackerServices and IUserInterviewTrackerServices
        /// and injecting Referance into constructor
        /// </summary>
        private readonly IInterviewTrackerServices _interviewTS;
        private readonly IUserInterviewTrackerServices _userTS;
        public SimpleController(IInterviewTrackerServices interviewTrackerServices,
            IUserInterviewTrackerServices userInterviewTrackerServices)
        {
            _interviewTS = interviewTrackerServices;
            _userTS = userInterviewTrackerServices;
        }
        //Get All Appliaction User on Load of API or calling this method
        // GET: api/User/GetBlogPost
        [HttpGet]
        public async Task<IEnumerable<Interview>> Get()
        {
            return await _interviewTS.GetAllInterview();
        }
        /// <summary>
        /// Get a Interview by InterviewId but no any proper validation implemeted
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpGet("{InterviewId}")]
        public async Task<IActionResult> Getinterview(string InterviewId)
        {
            
            var getinterview = await _interviewTS.GetInterviewrById(InterviewId);
            return CreatedAtAction("AllInterviewAsync", new { InterviewId = getinterview.InterviewId }, getinterview);
        }
        /// <summary>
        /// Post method of Add New Interview, to create a new interview but no use any ModelState validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddInterviewViewModel model)
        {
            Interview newInterview = new Interview
            {
                Interviewer = model.Interviewer,
                InterviewName = model.InterviewName,
                InterviewUser = model.InterviewUser,
                UserSkills = model.UserSkills,
                InterviewDate = model.InterviewDate,
                InterviewTime = model.InterviewTime,
                InterViewsStatus = model.InterViewsStatus,
                TInterViews = model.TInterViews,
                Remark = model.Remark
            };
            await _interviewTS.AddInterview(newInterview);
            return Ok("Interview Addeed...");
        }
        /// <summary>
        /// Delete a Interview from MongoDb Collection with no any model state validation and no any message to show.
        /// if user not pass any wrong data
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns></returns>
        [HttpDelete("{InterviewId}")]
        public async Task<IActionResult> Delete(string InterviewId)
        {
            await _interviewTS.DeleteInterviewById(InterviewId);
            return Ok("Interview Deleted");
        }
        /// <summary>
        /// Update Interview but no any validation is addeded
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <param name="interview"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpPut]
        [Route("Updateinterview/{InterviewId}")]
        public async Task<IActionResult> Updateinterview(string InterviewId, [FromBody] Interview interview)
        {
            
            var getinterview = _interviewTS.GetInterviewrById(InterviewId);
            await _interviewTS.UpdateInterview(InterviewId, interview);
            return Ok("Interview Updated");
        }
    }
}
