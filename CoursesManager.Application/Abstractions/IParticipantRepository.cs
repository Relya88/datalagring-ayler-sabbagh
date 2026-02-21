using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Abstractions;

// Repo för deltagare/Participant
public interface IParticipantRepository
{
    Task<ParticipantEntity> AddAsync(ParticipantEntity entity);

    Task<IEnumerable<ParticipantEntity>> GetAllAsync();

    Task<ParticipantEntity?> GetByIdAsync(int id);

    Task<bool> DeleteAsync(int id);

    Task<ParticipantEntity?> UpdateAsync(int id, ParticipantEntity entity);

}
