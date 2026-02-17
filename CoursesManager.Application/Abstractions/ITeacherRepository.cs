using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

//repo för teacher 
public interface ITeacherRepository
{
    Task<TeacherEntity> AddAsync(TeacherEntity entity);

    Task<IEnumerable<TeacherEntity>> GetAllAsync();

    Task<TeacherEntity?> GetByIdAsync(int id);

    Task<bool> DeleteAsync(int id);
}
