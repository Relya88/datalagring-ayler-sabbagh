using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Application.Dtos.Courses;

// DTO för att uppdatera en kurs
public class UpdateCourseDto
{
    public string CourseCode { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}

