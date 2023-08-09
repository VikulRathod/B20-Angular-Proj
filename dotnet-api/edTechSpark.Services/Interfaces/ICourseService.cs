using edTechSpark.Core.Entities;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface ICourseService : IService<Course>
    {
        Course GetCourseWithLessons(string Url);
        IEnumerable<Course> GetAllCourses();
    }
}
