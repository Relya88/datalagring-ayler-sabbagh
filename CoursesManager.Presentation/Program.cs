using CoursesManager.Application.Abstractions;
using CoursesManager.Application.Dtos.Courses;
using CoursesManager.Application.Dtos.CourseSessions;
using CoursesManager.Application.Dtos.Participants;
using CoursesManager.Application.Dtos.Teachers;
using CoursesManager.Application.Services;
using CoursesManager.Infrastructure.Persistence;
using CoursesManager.Infrastructure.Persistence.Repositories;
using CoursesManager.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
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

builder.Services.AddScoped<CourseSessionService>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<TeacherService>();

builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();

builder.Services.AddScoped<ParticipantService>();

builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddScoped<RegistrationService>();

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

// tar bort kurs (tog hjälp av chatgpt för delete-endpoint)
courses.MapDelete("/{id}", async (int id, CourseService service) =>
{
    var deleted = await service.DeleteCourseAsync(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

//uppdaterar kurs
courses.MapPut("/{id:int}", async (int id, UpdateCourseDto dto, CourseService service) =>
{
    var result = await service.UpdateCourseAsync(id, dto);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});


#endregion




#region CourseSessions

var sessions = app.MapGroup("/api/coursesessions");

// Skapar ett nytt kurstillfälle
sessions.MapPost("/", async (
    DateTime startDate,
    DateTime endDate,
    int courseId,
    CourseSessionService service) =>
{
    var result = await service.CreateCourseSessionAsync(startDate, endDate, courseId);
    return Results.Created($"/api/coursesessions/{result.Id}", result);
});

// Hämtar alla kurstillfällen
sessions.MapGet("/", async (CourseSessionService service) =>
{
    var result = await service.GetAllCourseSessionsAsync();
    return Results.Ok(result);
});

//hämtar kurstillfälle via id:t
sessions.MapGet("/{id:int}", async (int id, CourseSessionService service) =>
{
    var result = await service.GetCourseSessionByIdAsync(id);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

//uppdaterar kurstillfälle
sessions.MapPut("/{id:int}", async (int id, UpdateCourseSessionDto dto, CourseSessionService service) =>
{
    var result = await service.UpdateCourseSessionAsync(id, dto);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

//tar bort kurstillfälle
sessions.MapDelete("/{id:int}", async (int id, CourseSessionService service) =>
{
    var deleted = await service.DeleteCourseSessionAsync(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});


#endregion




#region Teachers

var teachers = app.MapGroup("/api/teachers");

//skapar ny lärare
teachers.MapPost("/", async (
    string firstName,
    string lastName,
    string email,
    TeacherService service) =>
{
    var result = await service.CreateTeacherAsync(firstName, lastName, email);
    return Results.Created($"/api/teachers/{result.Id}", result);
});

//hämtar alla lärare
teachers.MapGet("/", async (TeacherService service) =>
{
    var result = await service.GetAllTeachersAsync();
    return Results.Ok(result);
});

//hämtar lärare via id:et
teachers.MapGet("/{id:int}", async (int id, TeacherService service) =>
{
    var result = await service.GetTeacherByIdAsync(id);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

//tar bort lärare
teachers.MapDelete("/{id}", async (int id, TeacherService service) =>
{
    var deleted = await service.DeleteTeacherAsync(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

//upppdaterar lärare
teachers.MapPut("/{id:int}", async (int id, UpdateTeacherDto dto, TeacherService service) =>
{
    var result = await service.UpdateTeacherAsync(id, dto);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

#endregion




#region Participants

var participants = app.MapGroup("/api/participants");

// Skapar ny deltagare
participants.MapPost("/", async (
    string firstName,
    string lastName,
    string email,
    ParticipantService service) =>
{
    var result = await service.CreateParticipantAsync(firstName, lastName, email);
    return Results.Created($"/api/participants/{result.Id}", result);
});

//hämtar alla deltagare
participants.MapGet("/", async (ParticipantService service) =>
{
    var result = await service.GetAllParticipantsAsync();
    return Results.Ok(result);
});

// Hämtar deltagare via id
participants.MapGet("/{id:int}", async (int id, ParticipantService service) =>
{
    var result = await service.GetParticipantByIdAsync(id);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});

// Tar bort deltagare
participants.MapDelete("/{id}", async (int id, ParticipantService service) =>
{
    var deleted = await service.DeleteParticipantAsync(id);

    if (!deleted)
        return Results.NotFound();

    return Results.NoContent();
});

// Uppdaterar deltagare
participants.MapPut("/{id:int}", async (int id, UpdateParticipantDto dto, ParticipantService service) =>
{
    var result = await service.UpdateParticipantAsync(id, dto);

    if (result is null)
        return Results.NotFound();

    return Results.Ok(result);
});


#endregion




#region Registrations

var registrations = app.MapGroup("/api/registrations");

//skapar en ny reg (kopplar en deltagare till ett kurstillfälle)
registrations.MapPost("/", async (
    int participantId,
    int courseSessionId,
    RegistrationService service) =>
{
    var result = await service.CreateRegistrationAsync(participantId, courseSessionId);
    return Results.Created($"/api/registrations/{result.Id}", result);
});

//hämtar alla reg
registrations.MapGet("/", async (RegistrationService service) =>
{
    var result = await service.GetAllRegistrationsAsync();
    return Results.Ok(result);
});

#endregion



//start av applikation
app.Run();


