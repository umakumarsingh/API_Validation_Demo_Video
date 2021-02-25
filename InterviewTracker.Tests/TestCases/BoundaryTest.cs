using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using System.Runtime.CompilerServices;
using System.Net;
using InterviewTracker.Controllers;

namespace InterviewTracker.Tests.TestCases
{
    public class BoundaryTest
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
        //private readonly HttpClient _clint;
        public BoundaryTest()
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

            //var server = new TestServer(new WebHostBuilder().UseEnvironment("").UseStartup<Startup>());
            //_clint = server.CreateClient();
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        
        /// <summary>
        /// Testfor_ValidateInterviewId used for test the valid InterviewId
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateInterviewId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.AddInterview(_interview)).ReturnsAsync(_interview);
            var result = await _interviewTS.AddInterview(_interview);

            if (result.InterviewId.Length.ToString() == _interview.InterviewId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateInterviewId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_ValidEmail used for test the valid Email
        /// </summary>
        [Fact]
        public async void Testfor_ValidEmail()
        {
            //Arrange
            bool res = false;
            //Act
            bool isEmail = Regex.IsMatch(_user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isEmail);
            res = isEmail;
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidEmail=" + res + "\n");
        }
        /// <summary>
        /// Testfor_ValidateMobileNumber used for test the valid Mobile number length
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            //Act
            serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
            var result = await _interviewUserTS.Register(_user);
            var actualLength = _user.MobileNumber.ToString().Length;
            if (result.MobileNumber.ToString().Length == actualLength)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateMobileNumber=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_ValidateUserId used for test the valid userId or Not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateUserId()
        {
            //Arrange
            bool res = false;
            //Act
            try
            {
                serviceUser.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _interviewUserTS.Register(_user);

                if (result.UserId.Length.ToString() == _user.UserId.Length.ToString())
                {
                    res = true;
                }
                //Asert
                //final result displaying in text file
                await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateUserId=" + res + "\n");
                return res;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            
        }
    }
}
