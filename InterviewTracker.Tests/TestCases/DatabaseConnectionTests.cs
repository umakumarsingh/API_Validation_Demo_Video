using InterviewTracker.BusinessLayer.Interfaces;
using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterviewTracker.Tests.TestCases
{
    public class DatabaseConnectionTests
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
        public DatabaseConnectionTests()
        {
            _interviewTS = new InterviewTrackerServices(service.Object);
            _interviewUserTS = new UserInterviewTrackerServices(serviceUser.Object);

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
        static DatabaseConnectionTests()
        {
            if (!File.Exists("../../../../output_database_revised.txt"))
                try
                {
                    File.Create("../../../../output_database_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_database_revised.txt");
                File.Create("../../../../output_database_revised.txt").Dispose();
            }
        }
    }
}
