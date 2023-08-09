using edTechSpark.APIs.Filters;
using edTechSpark.Core.Entities;
using edTechSpark.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class CourseTopicController : ControllerBase
    {
        ITopicService _courseTopic;
        public CourseTopicController(ITopicService courseTopic)
        {
            _courseTopic = courseTopic;
        }

        [HttpGet]
        public IEnumerable<CourseTopic> GetAll()
        {
            return _courseTopic.GetAllTopics();
        }

        [HttpGet("{id}")]
        public CourseTopic Get(int id)
        {
            return _courseTopic.Find(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
        {
            return _courseTopic.GetTopicsByCourse(id);
        }

        [HttpPost]
        public IActionResult Add(CourseTopic model)
        {
            try
            {
                _courseTopic.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseTopic model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _courseTopic.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _courseTopic.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
