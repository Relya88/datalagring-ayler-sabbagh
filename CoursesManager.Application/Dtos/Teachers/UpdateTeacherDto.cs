namespace CoursesManager.Application.Dtos.Teachers;

//DTO för att uppdatera en läraree
public class UpdateTeacherDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
