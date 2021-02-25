using InterviewTracker.DataLayer;
using InterviewTracker.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLayer.Services.Repository
{
    public class UserInterviewTrackerRepository : IUserInterviewTrackerRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<ApplicationUser> _dbCollection;
        public UserInterviewTrackerRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
        }
        /// <summary>
        /// Delete a registred user from MongoDb Collection
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserById(string UserId)
        {
            try
            {
                var objectId = new ObjectId(UserId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("UserId", objectId);
                var result = await _dbCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get All user from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            try
            {
                var list = _mongoContext.GetCollection<ApplicationUser>("ApplicationUser")
                .Find(Builders<ApplicationUser>.Filter.Empty, null)
                .SortByDescending(e => e.FirstName);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get a registred user from MongoDb Collection
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserById(string userId)
        {
            try
            {
                var objectId = new ObjectId(userId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("userId", objectId);
                _dbCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Creating or registreing a new user in MongoDb Collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Register(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                _dbCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                await _dbCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }
        /// <summary>
        /// Update an Existing user by passing its userId
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UpdateUser(string UserId, ApplicationUser user)
        {
            if (user == null && user == null)
            {
                throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object or may be UserId is Null");
            }
            var update = await _dbCollection.FindOneAndUpdateAsync(Builders<ApplicationUser>.
            Filter.Eq("UserId", user.UserId), Builders<ApplicationUser>.
            Update.Set("FirstName", user.FirstName).Set("LastName", user.LastName)
            .Set("Email", user.Email).Set("ReportingTo", user.ReportingTo).
            Set("UserTypes", user.UserTypes).Set("Stat", user.Stat).Set("MobileNumber", user.MobileNumber));
            return update;
        }
    }
}
