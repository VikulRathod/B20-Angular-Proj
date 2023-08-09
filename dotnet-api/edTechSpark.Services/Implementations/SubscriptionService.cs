using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace edTechSpark.Services.Implementations
{
    public class SubscriptionService : Service<Subscription>, ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepo;
        private readonly IConfiguration _config;
        public SubscriptionService(ISubscriptionRepository subscriptionRepo, IRepository<Subscription> subsRepo, IConfiguration config) : base(subsRepo)
        {
            _subscriptionRepo = subscriptionRepo;
            _config = config;
        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            Subscription subscription = _subscriptionRepo.GetUserSubscription(UserId, CourseId);
            return subscription;
        }
        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            var data = _subscriptionRepo.GetSubscribedCourses(UserId).Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                DemoUrl = c.DemoUrl,
                ImageUrl = _config["ImageBaseUrl"] + c.ImageUrl,
                MentorId = c.MentorId,
                Sequence = c.Sequence,
                DifficultyType = c.DifficultyType,
                Summary = c.Summary,
                UnitPrice = c.UnitPrice,
                Description = c.Description,
                Url = c.Url
            });
            return data;
        }
    }
}
