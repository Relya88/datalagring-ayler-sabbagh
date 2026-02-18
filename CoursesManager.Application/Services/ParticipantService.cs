using System;
using System.Collections.Generic;
using System.Text;
using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Services;

//logik för Participant
public class ParticipantService
{
    private readonly IParticipantRepository _participantRepository;

    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    //Skapar ny deltagare
    public async Task<ParticipantEntity> CreateParticipantAsync(
        string firstName,
        string lastName,
        string email)
    {
        var participant = new ParticipantEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        return await _participantRepository.AddAsync(participant);
    }

    //hämtar alla deltagare
    public async Task<IEnumerable<ParticipantEntity>> GetAllParticipantsAsync()
    {
        return await _participantRepository.GetAllAsync();
    }

    //hämtar deltagare via id
    public async Task<ParticipantEntity?> GetParticipantByIdAsync(int id)
    {
        return await _participantRepository.GetByIdAsync(id);
    }

    //tar bort deltagare
    public async Task<bool> DeleteParticipantAsync(int id)
    {
        return await _participantRepository.DeleteAsync(id);
    }
}
