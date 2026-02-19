using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;
using CoursesManager.Application.Dtos.Teachers;

namespace CoursesManager.Application.Services;

//llogik för Teacher där service går via repot och inte använder DbContext direkt
public class TeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    //skapar en ny lärare
    public async Task<TeacherEntity> CreateTeacherAsync(
        string firstName,
        string lastName,
        string email)
    {
        var teacher = new TeacherEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        return await _teacherRepository.AddAsync(teacher);
    }

    //hämtar alla lärare
    public async Task<IEnumerable<TeacherEntity>> GetAllTeachersAsync()
    {
        return await _teacherRepository.GetAllAsync();
    }

    //hämtar lärare via id:et
    public async Task<TeacherEntity?> GetTeacherByIdAsync(int id)
    {
        return await _teacherRepository.GetByIdAsync(id);
    }

    //tar bort lärare
    public async Task<bool> DeleteTeacherAsync(int id)
    {
        return await _teacherRepository.DeleteAsync(id);
    }

    //uppdaterar en lärare via servicee
    public async Task<TeacherEntity?> UpdateTeacherAsync(int id, UpdateTeacherDto dto)
    {
        var updatedTeacher = new TeacherEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        return await _teacherRepository.UpdateAsync(id, updatedTeacher);
    }

}
