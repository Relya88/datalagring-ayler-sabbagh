using CoursesManager.Application.Abstractions;
using CoursesManager.Application.Dtos.Courses;
using CoursesManager.Application.Services;
using CoursesManager.Infrastructure.Persistence;
using CoursesManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//för reg av DbContext och kopplingen till sql servern

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//reggar repo och service i DI containern
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<CourseService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//själva applikationen som skapas
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//test-endpoint för att verifiera att APIet funkar
app.MapGet("/", () => "CoursesManager API is running");

#region Courses

var courses = app.MapGroup("/api/courses");

//skapar kurs
courses.MapPost("/", async (CreateCourseDto dto, CourseService service) =>
{
    var result = await service.CreateCourseAsync(dto);
    return Results.Created($"/api/courses/{result.Id}", result);
});

//hämtar alla kurser
courses.MapGet("/", async (CourseService service) =>
{
    var result = await service.GetAllCoursesAsync();
    return Results.Ok(result);
});

#endregion

//start av applikation
app.Run();


