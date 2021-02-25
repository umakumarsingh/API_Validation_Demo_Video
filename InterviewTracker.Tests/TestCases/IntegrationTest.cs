using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InterviewTracker.Tests.TestCases
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<InterviewTracker.Startup>>
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
        private readonly WebApplicationFactory<InterviewTracker.Startup> _factory;
        //inside this constructor injecting WebApplicationFactory for bootstraping for functional ene to end tesst
        public IntegrationTest(WebApplicationFactory<InterviewTracker.Startup> factory)
        {
            _interviewTS = new InterviewTrackerServices(service.Object);
            _interviewUserTS = new UserInterviewTrackerServices(serviceUser.Object);
            _factory = factory;
            _user = new ApplicationUser()
            {
                //UserId = "5f0ec59dce04c32fb4d3160a",
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
                //InterviewId = "5f10259f587fb74450a61c77",
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
        static IntegrationTest()
        {
            if (!File.Exists("../../../../output_integration_revised.txt"))
                try
                {
                    File.Create("../../../../output_integration_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_integration_revised.txt");
                File.Create("../../../../output_integration_revised.txt").Dispose();
            }
        }
        // passing endpoint maember data to all api function or api url
        //this method test all endpoint api call by passing Endpoints objects and return SuccessStatusCode.
        //model state test is valid or not
        [Theory]
        [InlineData("/api/User")]
        public async Task Get_UserEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var res = false;
            // Act
            var response = await client.GetAsync(url);
            if (response != null)
            {
                res = true;
            }
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_integration_revised.txt",
                "Get_UserEndpointsReturnSuccessAndCorrectContentType="
                + res.ToString() + "\n");
        }
        /// <summary>
        ///passing endpoint maember data to all api function or api url
        ///this method test all endpoint api call by passing Endpoints objects and return SuccessStatusCode.
        ///model state test is valid or not
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("/api/Interview/TotalInterview")]
        public async Task Get_InterviewEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var res = false;
            // Act
            var response = await client.GetAsync(url);
            if (response != null)
            {
                res = true;
            }
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/plain; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_integration_revised.txt",
                "Get_InterviewEndpointsReturnSuccessAndCorrectContentType="
                + res.ToString() + "\n");
        }
        /// <summary>
        ///passing endpoint maember data to all api function or api url
        ///this method test all endpoint api call by passing Endpoints objects and return SuccessStatusCode.
        ///model state test is valid or not
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("/api/Dashboard")]
        public async Task Get_DashboardEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var res = false;
            // Act
            var response = await client.GetAsync(url);
            if (response != null)
            {
                res = true;
            }
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_integration_revised.txt",
                "Get_DashboardEndpointsReturnSuccessAndCorrectContentType="
                + res.ToString() + "\n");
        }
    }
}
