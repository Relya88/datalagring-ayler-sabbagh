using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

// Implementering av TeacherRepo med delvis chatgptkod då min blev fel hela tiden
public class TeacherRepository
    : BaseRepository<TeacherEntity>, ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<TeacherEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TeacherEntity>()
                             .FirstOrDefaultAsync(t => t.Id == id);
    }

    //tar bort deltagare
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<TeacherEntity>()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (entity == null)
            return false;

        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    // Uppdaterar en lärare 
    public async Task<TeacherEntity?> UpdateAsync(int id, TeacherEntity entity)
    {
        var existingTeacher = await _context.Set<TeacherEntity>()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (existingTeacher == null)
            return null;

        existingTeacher.FirstName = entity.FirstName;
        existingTeacher.LastName = entity.LastName;
        existingTeacher.Email = entity.Email;

        await _context.SaveChangesAsync();

        return existingTeacher;
    }

}
