using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//repo för kurspecifik logik
public class CourseRepository
    : BaseRepository<CourseEntity>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}