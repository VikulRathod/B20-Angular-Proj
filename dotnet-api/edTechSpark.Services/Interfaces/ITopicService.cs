using edTechSpark.Core.Entities;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface ITopicService: IService<CourseTopic>
    {
        IEnumerable<CourseTopic> GetAllTopics();
        IEnumerable<CourseTopic> GetTopicsByCourse(int CourseId);
    }
}
