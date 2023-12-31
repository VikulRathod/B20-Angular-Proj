﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace edTechSpark.Core.Entities
{
    public partial class CourseTopic
    {
        public CourseTopic()
        {
            CourseLessons = new HashSet<CourseLesson>();
        }

        public int Id { get; set; }
        public string TopicName { get; set; }
        public bool IsActive { get; set; }
        public decimal Sequence { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
    }
}