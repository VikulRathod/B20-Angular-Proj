using edTechSpark.Core.Entities;
using edTechSpark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTechSpark.Repositories.Interfaces
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Subscription GetUserSubscription(int UserId, int CourseId);
        IEnumerable<Course> GetSubscribedCourses(int UserId);
    }
}
