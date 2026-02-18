using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using CoursesManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Infrastructure.Repositories;

// Implementering av Registration repo
public class RegistrationRepository : IRegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //för ny registrering 
    public async Task<RegistrationEntity> AddAsync(RegistrationEntity entity)
    {
        _context.Registrations.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    //hämtar alla registreringar från databas (tagit hjälp av chatgpt) 
    public async Task<IEnumerable<RegistrationEntity>> GetAllAsync()
    {
        return await _context.Registrations
            .Include(r => r.Participant)
            .Include(r => r.CourseSession)
            .ToListAsync();
    }
}
