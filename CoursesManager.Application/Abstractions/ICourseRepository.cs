using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

//repository kontrakt
public interface ICourseRepository
{
    Task<CourseEntity> AddAsync(CourseEntity entity);
    Task<IEnumerable<CourseEntity>> GetAllAsync();

    // hämtar en kurs baserat på id:et
    Task<CourseEntity?> GetByIdAsync(int id);

    //Tar bort 
    Task<bool> DeleteAsync(int id);

    //uppdaterar
    Task<CourseEntity?> UpdateAsync(int id, CourseEntity entity);


}
