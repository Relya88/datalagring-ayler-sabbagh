using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;

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
}

