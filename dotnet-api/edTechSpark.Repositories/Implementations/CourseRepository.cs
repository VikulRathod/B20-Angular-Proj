using edTechSpark.Core;
using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edTechSpark.Repositories.Implementations
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public Course GetCourseByUrl(string Url)
        {
            return dbContext.Courses.Where(c => c.Url == Url).FirstOrDefault();
        }
    }
}
