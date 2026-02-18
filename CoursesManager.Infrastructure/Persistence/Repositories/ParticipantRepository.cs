using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//implementering av ParticipantRepot som databaskommunicerar via dbcontext

public class ParticipantRepository
    : BaseRepository<ParticipantEntity>, IParticipantRepository
{
    public ParticipantRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<ParticipantEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<ParticipantEntity>()
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<ParticipantEntity>()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (entity == null)
            return false;

        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
