using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InterviewTracker.Tests.TestCases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly IInterviewTrackerServices _interviewTS;
        private readonly IUserInterviewTrackerServices _interviewUserTS;
        public readonly Mock<IInterviewTrackerRepository> service = new Mock<IInterviewTrackerRepository>();
        public readonly Mock<IUserInterviewTrackerRepository> serviceUser = new Mock<IUserInterviewTrackerRepository>();
        private ApplicationUser _user;
        private Interview _interview;
        /// <summary>
        /// Injecting service object into Test class constructor
        /// </summary>
        public FuctionalTests()
        {
            _interviewTS = new InterviewTrackerServices(service.Object);
            _interviewUserTS = new UserInterviewTrackerServices(serviceUser.Object);

            _user = new ApplicationUser()
            {
                UserId = "5f0ec59dce04c32fb4d3160a",
                FirstName = "Name1",
                LastName = "Last1",
                Email = "namelast@gmail.com",
                ReportingTo = "Reportingto",
                UserTypes = UserType.Developer,
                Stat = Status.Locked,
                MobileNumber = 9631438113
            };
            _interview = new Interview()
            {
                InterviewId = "5f10259f587fb74450a61c77",
                InterviewName = "Name1",
                Interviewer = "Interviewer-1",
                InterviewUser = "InterviewUser-1",
                UserSkills = ".net",
                InterviewDate = DateTime.Now,
                InterviewTime = DateTime.UtcNow,
                InterViewsStatus = InterviewStatus.Done,
                TInterViews = TechnicalInterviewStatus.Pass,
                Remark = "OK"
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Testfor_Validate_ValidUserRegister is used to test register user is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidUserRegister()
        {
            //Arrange
            bool res = false;
            //Act
            serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
            var result = await _interviewUserTS.Register(_user);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_ValidUserRegister=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_GetAllUser is used to test all user is in List return or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllUser()
        {
            //Arrange
            var res = false;
            //Action
            serviceUser.Setup(repos => repos.GetAllUser());
            var result = await _interviewUserTS.GetAllUser();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllUser=" + res + "\n");
            return res;
        }
        
        /// <summary>
        /// Testfor_GetUserById is used fro get a used by id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetUserById()
        {
            //Arrange
            var res = false;
            //Action
            serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
            var result = await _interviewUserTS.Register(_user);
            serviceUser.Setup(repos => repos.GetUserById(result.UserId)).ReturnsAsync(_user);
            var resultUser = await _interviewUserTS.GetUserById(result.UserId);
            //Assertion
            if (resultUser != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetUserById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_UpdateUser is used for passed user by Id is updated or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_UpdateUser()
        {
            //Arrange
            var res = false;
            var _userUpdate = new ApplicationUser()
            {
                UserId = "5f0ff60a7b7be11c4c3c19e1",
                FirstName = "Name Update",
                LastName = "Last1",
                Email = "namelastupdate@gmail.com",
                ReportingTo = "Reportingto",
                UserTypes = UserType.Developer,
                Stat = Status.Locked,
                MobileNumber = 9631434578
            };
            //Action
            serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
            var result = await _interviewUserTS.Register(_user);
            serviceUser.Setup(repos => repos.GetUserById(result.UserId)).ReturnsAsync(_user);
            var resultUser = await _interviewUserTS.GetUserById(result.UserId);
            serviceUser.Setup(repos => repos.UpdateUser(resultUser.UserId, _userUpdate)).ReturnsAsync(_userUpdate);
            var resultUpdate = await _interviewUserTS.UpdateUser(resultUser.UserId, _userUpdate);
            //Assertion
            if (resultUpdate == _userUpdate)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_UpdateUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_DeleteUser is used for passed used by id is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteUser()
        {
            //Arrange
            var res = false;
            //Action
            serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
            var result = await _interviewUserTS.Register(_user);
            serviceUser.Setup(repos => repos.DeleteUserById(result.UserId)).ReturnsAsync(true);
            var resultDelete = await _interviewUserTS.DeleteUserById(result.UserId);
            if (resultDelete == true)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_DeleteUser=" + res + "\n");
            return res;
        }

        /// <summary>
        /// Interview Part Test
        /// Testfor_Validate_Valid_AddInterview is used to test to add a valid Interview
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_AddInterview()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Valid_AddInterview=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_GetAllInterview is used for to test all interview is listed or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllInterview()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.GetAllInterview());
            var result = await _interviewTS.GetAllInterview();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetAllInterview=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_GetInterviewById is used for to test interview is get by id or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewById()
        {
            //Arrange
            var res = false;
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            //Action

            service.Setup(repos => repos.GetInterviewrById(result.InterviewId)).ReturnsAsync(_interview);
            var resultById = _interviewTS.GetInterviewrById(result.InterviewId);
            //Assertion
            if (resultById != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetInterviewById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_UpdateInterview is used to upadte Interview or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_UpdateInterview()
        {
            //Arrange
            var res = false;
            var _interviewUpdate = new Interview()
            {
                InterviewId = "5f1025b2587fb74450a61c78",
                InterviewName = "NameUpdate",
                Interviewer = "Interviewer",
                InterviewUser = "InterviewUser-1",
                UserSkills = ".net",
                InterviewDate = DateTime.Now,
                InterviewTime = DateTime.UtcNow,
                InterViewsStatus = InterviewStatus.Done,
                TInterViews = TechnicalInterviewStatus.Pass,
                Remark = "OK"
            };
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            //Action
            service.Setup(repos => repos.UpdateInterview(result.InterviewId, _interviewUpdate)).ReturnsAsync(_interview);
            var resultUpdate = await _interviewTS.UpdateInterview(result.InterviewId, _interviewUpdate);
            //Assertion
            if (resultUpdate == _interview)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_UpdateInterview=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_DeleteInterview is used for to test passed InterviewId is deleted or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteInterview()
        {
            //Arrange
            var res = false;
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            //Action
            service.Setup(repos => repos.DeleteInterviewById(result.InterviewId)).ReturnsAsync(true);
            var resultDelete = await _interviewTS.DeleteInterviewById(result.InterviewId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteInterview=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_CountInterview is used to test total count of Interview in Db
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_CountInterview()
        {
            //Arrange
            var res = false;
            int val = 0;
            //Action
            service.Setup(repos => repos.TotalCount());
            var result = _interviewTS.TotalCount();
            //Assertion
            if (result >= val)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_CountInterview=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_GetInterviewByName is used to test passed interview Name and its return interview by name or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewByName()
        {
            //Arrange
            var res = false;
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            //Action
            service.Setup(repos => repos.InterviewByName(result.InterviewName));
            var resultSearch = await _interviewTS.InterviewByName(result.InterviewName);
            //Assertion
            if (resultSearch != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetInterviewByName=" + res + "\n");
            return res;
        }
        /// <summary>
        /// TestFor_GetInterviewByName is used to test passed interviewer Name and its return interview by interviewer name or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetInterviewByInterviewerName()
        {
            //Arrange
            var res = false;
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);
            //Action
            service.Setup(repos => repos.InterviewByName(result.Interviewer));
            var resultSearch = await _interviewTS.InterviewByName(result.Interviewer);
            //Assertion
            if (resultSearch != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetInterviewByInterviewerName=" + res + "\n");
            return res;
        }
    }
}
