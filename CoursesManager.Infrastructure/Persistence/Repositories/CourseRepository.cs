using CoursesManager.Domain.Entities;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//repo för kurspecifik logik
public class CourseRepository : BaseRepository<CourseEntity>
{
    public CourseRepository(ApplicationDbContext context)
        : base(context)
    {
    }

}
