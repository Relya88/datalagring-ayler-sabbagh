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




#region Dependency Injection

//reggar repo och service i DI containern
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<ICourseSessionRepository, CourseSessionRepository>();

#endregion




#region Swagger

//reggar stöd för min-API och swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion


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

// hämtar kurs baserat på id
courses.MapGet("/{id:int}", async (int id, CourseService service) =>
{
    var result = await service.GetCourseByIdAsync(id);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

// tar bort kurs (tog hjälp av chatgpt fö delete-endpoint)
courses.MapDelete("/{id}", async (int id, CourseService service) =>
{
    var deleted = await service.DeleteCourseAsync(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

#endregion

//start av applikation
app.Run();


