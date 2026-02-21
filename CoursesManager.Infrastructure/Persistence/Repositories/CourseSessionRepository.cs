using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//implementering av repo för CourseSession
public class CourseSessionRepository
    : BaseRepository<CourseSessionEntity>, ICourseSessionRepository
{
    public CourseSessionRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    //hämtar kurstillfälle via id
    public async Task<CourseSessionEntity?> GetByIdAsync(int id)
{
    return await _context.Set<CourseSessionEntity>()
        .FirstOrDefaultAsync(s => s.Id == id);
}

    //upppdaterar kurstillfälle
    public async Task<CourseSessionEntity?> UpdateAsync(int id, CourseSessionEntity entity)
{
    var existingSession = await _context.Set<CourseSessionEntity>()
        .FirstOrDefaultAsync(s => s.Id == id);

    if (existingSession == null)
        return null;

    existingSession.StartDate = entity.StartDate;
    existingSession.EndDate = entity.EndDate;
    existingSession.CourseId = entity.CourseId;

    await _context.SaveChangesAsync();

    return existingSession;
}

    //tar bort kurstillfälle
    public async Task<bool> DeleteAsync(int id)
{
    var entity = await _context.Set<CourseSessionEntity>()
        .FirstOrDefaultAsync(s => s.Id == id);

    if (entity == null)
        return false;

    _context.Remove(entity);
    await _context.SaveChangesAsync();

    return true;
}

}
