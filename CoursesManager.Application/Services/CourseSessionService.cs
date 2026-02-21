using CoursesManager.Application.Abstractions;
using CoursesManager.Application.Dtos.CourseSessions;
using CoursesManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Application.Services;

//logik för CourseSession som anropar repo istället för att prata direkt med DbContext (chatgpt hjälpte med halva)
public class CourseSessionService
{
    private readonly ICourseSessionRepository _courseSessionRepository;

    public CourseSessionService(ICourseSessionRepository courseSessionRepository)
    {
        _courseSessionRepository = courseSessionRepository;
    }

    //skapar ett nytt kurstillfälle
    public async Task<CourseSessionEntity> CreateCourseSessionAsync(
        DateTime startDate,
        DateTime endDate,
        int courseId)
    {
        var session = new CourseSessionEntity
        {
            StartDate = startDate,
            EndDate = endDate,
            CourseId = courseId
        };

        return await _courseSessionRepository.AddAsync(session);
    }

    //hämtar alla kurstillfällen
    public async Task<IEnumerable<CourseSessionEntity>> GetAllCourseSessionsAsync()
    {
        return await _courseSessionRepository.GetAllAsync();
    }

    // Hämtar kurstillfälle via id
    public async Task<CourseSessionEntity?> GetCourseSessionByIdAsync(int id)
    {
        return await _courseSessionRepository.GetByIdAsync(id);
    }

    // Uppdaterar kurstillfälle
    public async Task<CourseSessionEntity?> UpdateCourseSessionAsync(int id, UpdateCourseSessionDto dto)
    {
        var updatedSession = new CourseSessionEntity
        {
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            CourseId = dto.CourseId
        };

        return await _courseSessionRepository.UpdateAsync(id, updatedSession);
    }

    // Tar bort kurstillfälle
    public async Task<bool> DeleteCourseSessionAsync(int id)
    {
        return await _courseSessionRepository.DeleteAsync(id);
    }


}

