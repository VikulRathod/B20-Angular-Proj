using edTechSpark.APIs.Filters;
using edTechSpark.Core.Entities;
using edTechSpark.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        ICourseService _courseService;
        private IMemoryCache _cache;
        public CatalogController(ICourseService courseService, IMemoryCache cache)
        {
            _courseService = courseService;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            //for cache
            string key = "catalog";
            var items = _cache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                var data = _courseService.GetAllCourses();

                return data;
            });

            return items;
        }

        [HttpGet("{Url}")]
        public Course GetCourseWithLessons(string Url)
        {
            Url = "/Courses/" + Url;
            return _courseService.GetCourseWithLessons(Url);
        }
    }
}
