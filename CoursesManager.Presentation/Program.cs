using CoursesManager.Application.Abstractions;
using CoursesManager.Application.Services;
using CoursesManager.Infrastructure.Persistence;
using CoursesManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//för reg av DbContext och kopplingen till sql servern

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//själva applikationen som skapas
var app = builder.Build();

//test-endpoint för att verifiera att APIet funkar
app.MapGet("/", () => "CoursesManager API is running");

//start av applikation
app.Run();

//reggar repo och service i DI containern
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<CourseService>();

