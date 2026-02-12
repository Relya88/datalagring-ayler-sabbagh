using Microsoft.EntityFrameworkCore;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Infrastructure.Persistence;

//hanterar databaskopplingen
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CourseEntity> Courses { get; set; } = null!;
}

