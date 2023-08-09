using edTechSpark.Core;
using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edTechSpark.Repositories.Implementations
{
    public class TopicRepository : Repository<CourseTopic>, ITopicRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public TopicRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<CourseTopic> GetAllTopics()
        {
            var Topics = (from topic in dbContext.CourseTopics
                          join course in dbContext.Courses
                          on topic.CourseId equals course.Id
                          select new CourseTopic
                          {
                              Id = topic.Id,
                              TopicName = topic.TopicName,
                             // CourseName = course.Name,
                              IsActive = topic.IsActive
                          }).ToList();
            return Topics;
        }

        public IEnumerable<CourseTopic> GetTopicWithLessons(int id)
        {
           var Topics = dbContext.CourseTopics.Where(c => c.CourseId == id).Include(c=>c.CourseLessons).ToList();
            return Topics;
        }

        public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
        {
            var Topics = (from topic in dbContext.CourseTopics
                          where topic.CourseId == id
                          select topic).ToList();
            return Topics;
        }
    }
}
