using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Domain.Entities;

//representerar en lärare i systemet
public class TeacherEntity
{
    public int Id { get; set; }

    //lärarens förnamn
    public string FirstName { get; set; } = null!;

    // Lärarens efternamn
    public string LastName { get; set; } = null!;

    //mail
    public string Email { get; set; } = null!;

    // En lärare kan hålla i flera kurstillfällen
    public ICollection<CourseSessionEntity> CourseSessions { get; set; } = [];
}
