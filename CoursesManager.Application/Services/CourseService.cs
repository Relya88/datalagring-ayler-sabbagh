using CoursesManager.Application.Dtos.Courses;

namespace CoursesManager.Application.Services;

//hanterar logik som är kopplad till kurser
public class CourseService
{
    public Task<bool> CreateCourseAsync(CreateCourseDto dto)
    {
        return Task.FromResult(true);
    }
}

