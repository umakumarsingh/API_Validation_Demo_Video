using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.ViewModels;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IInterviewTrackerServices and IUserInterviewTrackerServices
        /// and injecting Referance into constructor
        /// </summary>
        private readonly IInterviewTrackerServices _interviewTS;
        public DashboardController(IInterviewTrackerServices interviewTrackerServices,
            IUserInterviewTrackerServices userInterviewTrackerServices)
        {
            _interviewTS = interviewTrackerServices;
        }
        //Get All Appliaction User on Load of API or calling this method
        // GET: api/User/GetBlogPost
        [HttpGet]
        public async Task<IEnumerable<Interview>> AllInterviewAsync()
        {
            return await _interviewTS.GetAllInterview();
        }
        /// <summary>
        /// Get a Interview by InterviewId
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpGet]
        [Route("Getinterview/{InterviewId}")]
        public async Task<IActionResult> Getinterview(string InterviewId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getinterview = await _interviewTS.GetInterviewrById(InterviewId);
            if (getinterview == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllInterviewAsync", new { InterviewId = getinterview.InterviewId }, getinterview);
        }
        /// <summary>
        /// Post method of AddNewInterview, to create a new interview with ModelState validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddInterview")]
        public async Task<IActionResult> AddNewInterview([FromBody] AddInterviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
        /// Delete a Interview from MongoDb Collection in this case we use proper validation
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteInterview/{InterviewId}")]
        public async Task<IActionResult> DeleteInterview(string InterviewId)
        {
            if (InterviewId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _interviewTS.DeleteInterviewById(InterviewId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Interview Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Update Interview
        /// </summary>
        /// <param name="InterviewId"></param>
        /// <param name="interview"></param>
        /// <returns>AllInterviewAsync method</returns>
        [HttpPut]
        [Route("Updateinterview/{InterviewId}")]
        public async Task<IActionResult> Updateinterview(string InterviewId, [FromBody] Interview interview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getinterview = _interviewTS.GetInterviewrById(InterviewId);
            if (getinterview == null)
            {
                return NotFound();
            }
            await _interviewTS.UpdateInterview(InterviewId, interview);
            return CreatedAtAction("AllInterviewAsync", new { InterviewId = interview.InterviewId }, interview);
        }
    }
}
