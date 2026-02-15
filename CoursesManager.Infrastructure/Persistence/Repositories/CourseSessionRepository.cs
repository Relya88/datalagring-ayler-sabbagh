using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Infrastructure.Persistence.Repositories;

//implementering av repo för CourseSession
public class CourseSessionRepository
    : BaseRepository<CourseSessionEntity>, ICourseSessionRepository
{
    public CourseSessionRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}

