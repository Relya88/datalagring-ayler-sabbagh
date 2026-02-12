using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Application.Dtos.Courses;

// DTO för att skapa en ny kurs med kurskod, titel och bekskrivning
public class CreateCourseDto
{
    public string CourseCode { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!; 
}

