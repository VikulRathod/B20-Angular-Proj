using edTechSpark.Core;
using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edTechSpark.Repositories.Implementations
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public SubscriptionRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            return dbContext.Subscriptions.Where(c => c.UserId == UserId && c.CourseId == CourseId).FirstOrDefault();
        }

        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            IEnumerable<Course> model = (from subs in dbContext.Subscriptions
                                                    join course in dbContext.Courses
                                                    on subs.CourseId equals course.Id
                                                    where subs.UserId == UserId
                                                    select course).ToList();
            return model;
        }
    }
}
