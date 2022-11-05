using Model;
using System.Collections.Generic;

namespace Persistence
{
    public interface InscriereRepo : IRepository<int, Inscriere>
    {
        IEnumerable<Participant> ParticipantiProba(int probaId);
        IEnumerable<Proba> ProbeParticipant(int participantId);
    }
}
