using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace CoursesManager.Domain.Entities;

//representerar deltagare som kan registreras på kurstillfällen
public class ParticipantEntity
{
    public int Id { get; set; }

    //deras förnamn
    public string FirstName { get; set; } = null!;

    //efternamn
    public string LastName { get; set; } = null!;

    //mail
    public string Email { get; set; } = null!;
}
