using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

// Repo för Registration
public interface IRegistrationRepository
{
    Task<RegistrationEntity> AddAsync(RegistrationEntity entity);
    Task<IEnumerable<RegistrationEntity>> GetAllAsync();
}
