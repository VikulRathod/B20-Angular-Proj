using edTechSpark.Core.Entities;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface ILessonService: IService<CourseLesson>
    {
        IEnumerable<CourseLesson> GetLessonsByTopic(int TopicId);
    }
}
