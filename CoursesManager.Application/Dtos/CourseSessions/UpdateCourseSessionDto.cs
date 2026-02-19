using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Application.Dtos.CourseSessions;

// DTO för att uppdatera ett kurstillfälle
public class UpdateCourseSessionDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CourseId { get; set; }
}
