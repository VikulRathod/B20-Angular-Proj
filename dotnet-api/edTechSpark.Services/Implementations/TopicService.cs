using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;
using System.Collections.Generic;

namespace edTechSpark.Services.Implementations
{
    public class TopicService : Service<CourseTopic>, ITopicService
    {
        private readonly ITopicRepository _topicRepo;
        public TopicService(ITopicRepository topicRepo, IRepository<CourseTopic> courseTopic) : base(courseTopic)
        {
            _topicRepo = topicRepo;
        }
        public IEnumerable<CourseTopic> GetAllTopics()
        {
            return _topicRepo.GetAllTopics();
        }
        public IEnumerable<CourseTopic> GetTopicsByCourse(int CourseId)
        {
            return _topicRepo.GetTopicsByCourse(CourseId);
        }
    }
}
