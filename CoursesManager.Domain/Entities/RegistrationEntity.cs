using System;
using System.Collections.Generic;
using System.Text;
namespace CoursesManager.Domain.Entities;

//koppling mellan deltagare och kurstillfälle som visar att en deltagare är registrerad på ett kurstillfälle
public class RegistrationEntity
{
    public int Id { get; set; }

    // FK till Participant
    public int ParticipantId { get; set; }

    public ParticipantEntity Participant { get; set; } = null!;

    // FK till CourseSession
    public int CourseSessionId { get; set; }

    public CourseSessionEntity CourseSession { get; set; } = null!;
}
