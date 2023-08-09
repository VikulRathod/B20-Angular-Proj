using edTechSpark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTechSpark.Repositories.Interfaces
{
   public interface ITopicRepository
    {
        IEnumerable<CourseTopic> GetAllTopics();
        IEnumerable<CourseTopic> GetTopicWithLessons(int id);
        IEnumerable<CourseTopic> GetTopicsByCourse(int id);
    }
}
