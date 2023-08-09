using edTechSpark.Core.Entities;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface IMentorService : IService<Mentor>
    {
        IEnumerable<Mentor> GetAllMentors();
    }
}
