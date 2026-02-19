using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

// Repo för CourseSession
public interface ICourseSessionRepository
{
    Task<CourseSessionEntity> AddAsync(CourseSessionEntity entity);
    Task<IEnumerable<CourseSessionEntity>> GetAllAsync();
}
