using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Application.Dtos.Participants;

//DTO för att uppdatera en deltagare
public class UpdateParticipantDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
