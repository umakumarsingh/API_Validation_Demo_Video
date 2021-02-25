using InterviewTracker.BusinessLayer.Services;
using InterviewTracker.BusinessLayer.Services.Repository;
using InterviewTracker.DataLayer;
using InterviewTracker.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InterviewTracker.Tests.TestCases
{

    public class BusinessLogicTests
    {
        //write code here
        //mocking Object
        private Mock<IMongoCollection<ApplicationUser>> _mockApplicationCollection;
        private Mock<IMongoCollection<Interview>> _mockinterviewCollection;
        private Mock<IMongoDBContext> _mockContext;
        private ApplicationUser _user;
        private Interview _interview;

        private readonly IList<ApplicationUser> _listUser;
        private readonly IList<Interview> _interviewlist;
        private Mock<IOptions<Mongosettings>> _mockOptions;
        public BusinessLogicTests()
        {
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
            _mockApplicationCollection = new Mock<IMongoCollection<ApplicationUser>>();
            _mockApplicationCollection.Object.InsertOne(_user);

            _mockinterviewCollection = new Mock<IMongoCollection<Interview>>();
            _mockinterviewCollection.Object.InsertOne(_interview);

            _mockContext = new Mock<IMongoDBContext>();
            //MongoSettings initialization
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _listUser = new List<ApplicationUser>();
            _listUser.Add(_user);
            _interviewlist = new List<Interview>();
            _interviewlist.Add(_interview);
        }
        //connecting to mongo local host databse
        Mongosettings settings = new Mongosettings()
        {
            Connection = "mongodb://localhost:27017",
            DatabaseName = "InterviewTracker"
        };
        static BusinessLogicTests()
        {
            if (!File.Exists("../../../../output_business_revised.txt"))
                try
                {
                    File.Create("../../../../output_business_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_business_revised.txt");
                File.Create("../../../../output_business_revised.txt").Dispose();
            }
        }
        //[Fact]
        //public async void TestFor_UserRegisterAsync()
        //{
        //    //mocking
        //    var res = false;
        //    _mockApplicationCollection.Setup(op => op.InsertOneAsync(_user, null,
        //    default(CancellationToken))).Returns(Task.CompletedTask);
        //    _mockContext.Setup(c => c.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name)).Returns(_mockApplicationCollection.Object);

        //    _mockOptions.Setup(s => s.Value).Returns(settings);
        //    var context = new MongoDBContext(_mockOptions.Object);
        //    var userRepo = new UserInterviewTrackerRepository(context);

        //    //Action
        //    var user = await userRepo.Register(_user);

        //    //Assert
        //    Assert.NotNull(user);
        //    Assert.Equal(_user.FirstName, user.FirstName);

        //    //writing tset boolean output in text file, that is present in project directory
        //    if (user != null)
        //    {
        //        res = true;
        //    }
        //    File.AppendAllText("../../../../output_business_revised.txt", "TestFor_UserRegisterAsync=" + res + "\n");

        //}
    }
}
