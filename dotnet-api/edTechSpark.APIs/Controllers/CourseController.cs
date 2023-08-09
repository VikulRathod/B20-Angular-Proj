using edTechSpark.APIs.Filters;
using edTechSpark.APIs.Helpers;
using edTechSpark.Core.Entities;
using edTechSpark.Models;
using edTechSpark.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class CourseController : ControllerBase
    {
        ICourseService _courseService;
        ISubscriptionService _subscriptionService;
        IFileHelper _fileHelper;
        public CourseController(ICourseService courseService, ISubscriptionService subscriptionService, IFileHelper fileHelper)
        {
            _courseService = courseService;
            _subscriptionService = subscriptionService;
            _fileHelper = fileHelper;
        }

        [HttpGet]
        public IEnumerable<Course> GetAll()
        {
            return _courseService.GetAllCourses();
        }

        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return _courseService.Find(id);
        }

        [HttpPost]
        public IActionResult Add(Course model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                _courseService.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course model)
        {
            try
            {
                model.UpdatedDate = DateTime.Now;
                if (id != model.Id)
                    return BadRequest();

                _courseService.Update(model);
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
                Course course = _courseService.Find(id);
                if (course != null)
                {
                    _fileHelper.DeleteFile(course.ImageUrl);
                    _courseService.Remove(course);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{UserId}/{CourseId}")]
        public Subscription GetCourseSubscription(int UserId, int CourseId)
        {
            return _subscriptionService.GetUserSubscription(UserId, CourseId);
        }

        [HttpGet("{UserId}")]
        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            return _subscriptionService.GetSubscribedCourses(UserId);
        }
    }
}
