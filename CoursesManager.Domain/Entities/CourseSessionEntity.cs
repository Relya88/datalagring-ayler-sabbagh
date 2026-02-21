using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Domain.Entities;

//representerar ett kurstillfällle för en specifik kurs
public class CourseSessionEntity
{
    public int Id { get; set; }

    //startdatum för kurstillfället
    public DateTime StartDate { get; set; }

    //slutdatum för kurstillfället
    public DateTime EndDate { get; set; }

    //FK till Course
    public int CourseId { get; set; }

    //navigation property till Course
    public CourseEntity Course { get; set; } = null!;
}

