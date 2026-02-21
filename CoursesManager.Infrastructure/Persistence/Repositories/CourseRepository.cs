using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//repo för kurspecifik logik
public class CourseRepository
    : BaseRepository<CourseEntity>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context)
        : base(context)
    {
    }
    public async Task<CourseEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<CourseEntity>()
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    //borttagning av kurs (tog hjälp av chatgpt för att möjliggöra det)
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<CourseEntity>()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (entity == null)
            return false;

        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    //uppdatering av kurs
    public async Task<CourseEntity?> UpdateAsync(int id, CourseEntity entity)
    {
        var existingCourse = await _context.Set<CourseEntity>()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existingCourse == null)
            return null;

        existingCourse.CourseCode = entity.CourseCode;
        existingCourse.Title = entity.Title;
        existingCourse.Description = entity.Description;
        existingCourse.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingCourse;
    }


}