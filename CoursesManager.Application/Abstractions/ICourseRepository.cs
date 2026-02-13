using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

//repository kontrakt
public interface ICourseRepository
{
    Task<CourseEntity> AddAsync(CourseEntity entity);
    Task<IEnumerable<CourseEntity>> GetAllAsync();
}
