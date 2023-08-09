using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace edTechSpark.Services.Implementations
{
    public class MentorService : Service<Mentor>, IMentorService
    {
        private readonly IRepository<Mentor> _mentorRepo;
        private readonly IConfiguration _config;
        public MentorService(IRepository<Mentor> mentorRepo, IConfiguration config) : base(mentorRepo)
        {
            _mentorRepo = mentorRepo;
            _config = config;
        }
        public IEnumerable<Mentor> GetAllMentors()
        {
            var data = _mentorRepo.GetAll().Select(c => new Mentor
            {
                Id = c.Id,
                Name = c.Name,
                Email= c.Email,
                Title= c.Title,
                Skills= c.Skills,
                Biography= c.Biography,
                ImageUrl = _config["ImageBaseUrl"] + c.ImageUrl,
            });
            return data;
        }
    }
}
