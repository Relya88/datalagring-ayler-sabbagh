using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

// Repokontrakt för CourseSession som definierar vilka databasoperationer som är tillåtna för CourseSession
public interface ICourseSessionRepository
{
    Task<CourseSessionEntity> AddAsync(CourseSessionEntity entity);
    Task<IEnumerable<CourseSessionEntity>> GetAllAsync();
}
