using edTechSpark.Core.Entities;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface ISubscriptionService : IService<Subscription>
    {
        Subscription GetUserSubscription(int UserId, int CourseId);
        IEnumerable<Course> GetSubscribedCourses(int UserId);
    }
}
