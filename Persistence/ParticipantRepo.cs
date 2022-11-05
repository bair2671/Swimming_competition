using Model;

namespace Persistence
{
    public interface ParticipantRepo : IRepository<int, Participant>
    {
        Participant FindOneByName(string nume);
    }
}
