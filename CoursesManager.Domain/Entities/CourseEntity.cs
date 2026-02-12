using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesManager.Domain.Entities;

//Representerar en kurs i systemet där kursen är själv mallen för grunden och den kan ha flera kurstillfällen
public class CourseEntity
{
    public int CourseId { get; set; }
    public string CourseCode { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public byte[] RowVersion { get; set; } = [];

}

