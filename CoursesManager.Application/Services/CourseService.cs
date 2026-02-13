using CoursesManager.Application.Dtos.Courses;
using CoursesManager.Domain.Entities;
using CoursesManager.Application.Abstractions;

namespace CoursesManager.Application.Services;

// Hanterar affärslogik för kurser
public class CourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseEntity> CreateCourseAsync(CreateCourseDto dto)
    {
        var course = new CourseEntity
        {
            CourseCode = dto.CourseCode,
            Title = dto.Title,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        return await _courseRepository.AddAsync(course);
    }

    public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
    {
        return await _courseRepository.GetAllAsync();
    }
}



//hanterar logik som är kopplad till kurser