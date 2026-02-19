using CoursesManager.Application.Abstractions;
using CoursesManager.Domain.Entities;

namespace CoursesManager.Application.Services;

//logik för registreringn
public class RegistrationService
{
    private readonly IRegistrationRepository _repository;

    public RegistrationService(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    //skapar ny registrering
    public async Task<RegistrationEntity> CreateRegistrationAsync(int participantId, int courseSessionId)
    {
        var registration = new RegistrationEntity
        {
            ParticipantId = participantId,
            CourseSessionId = courseSessionId
        };

        return await _repository.AddAsync(registration);
    }

    //hämtar alla registreringar
    public async Task<IEnumerable<RegistrationEntity>> GetAllRegistrationsAsync()
    {
        return await _repository.GetAllAsync();
    }

    // Hämtar reg via id
    public async Task<RegistrationEntity?> GetRegistrationByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    //tar bort reg
    public async Task<bool> DeleteRegistrationAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

}

