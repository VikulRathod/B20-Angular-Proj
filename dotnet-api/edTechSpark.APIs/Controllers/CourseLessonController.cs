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
    public class CourseLessonController : ControllerBase
    {
        ILessonService _lessonService;
        public CourseLessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IEnumerable<CourseLesson> GetAll()
        {
            return _lessonService.GetAll();
        }

        [HttpGet("{id}")]
        public CourseLesson Get(int id)
        {
            return _lessonService.Find(id);
        }

        [HttpGet("{id}")]
        public IEnumerable<CourseLesson> GetLessonsByTopic(int id)
        {
            return _lessonService.GetLessonsByTopic(id);
        }

        [HttpPost]
        public IActionResult Add(CourseLesson model)
        {
            try
            {
                _lessonService.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseLesson model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _lessonService.Update(model);
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
                _lessonService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
