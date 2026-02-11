var builder = WebApplication.CreateBuilder(args);

//själva applikationen som skapas
var app = builder.Build();

//test-endpoint för att verifiera att APIet funkar
app.MapGet("/", () => "CoursesManager API is running");

//start av applikation
app.Run();

