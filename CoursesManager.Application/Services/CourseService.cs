using CoursesManager.Application.Dtos.Courses;
using CoursesManager.Domain.Entities;
using CoursesManager.Application.Abstractions;

namespace CoursesManager.Application.Services;

// Hanterar affärslogik för kurserna
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

    // Hämtar kurs baserat på id:et
    public async Task<CourseEntity?> GetCourseByIdAsync(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    //tar bort kurs. Tog lite hjälp chatgpt för att koppla borttagningsfunktionen via servicelagret
    public async Task<bool> DeleteCourseAsync(int id)

    {
        return await _courseRepository.DeleteAsync(id);
    }

    //updatering av kurs
    public async Task<CourseEntity?> UpdateCourseAsync(int id, UpdateCourseDto dto)
    {
        var updatedCourse = new CourseEntity
        {
            CourseCode = dto.CourseCode,
            Title = dto.Title,
            Description = dto.Description
        };

        return await _courseRepository.UpdateAsync(id, updatedCourse);
    }


}
