using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;
using System.Collections.Generic;

namespace edTechSpark.Services.Implementations
{
    public class LessonService : Service<CourseLesson>, ILessonService
    {
        private readonly ILessonRepository _lessonRepo;
        public LessonService(ILessonRepository lessonRepo, IRepository<CourseLesson> courseLesson) : base(courseLesson)
        {
            _lessonRepo = lessonRepo;
        }
        public IEnumerable<CourseLesson> GetLessonsByTopic(int TopicId)
        {
            return _lessonRepo.GetLessonsByTopic(TopicId);
        }
    }
}
