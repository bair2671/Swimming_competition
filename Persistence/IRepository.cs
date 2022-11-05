using Model;
using System.Collections.Generic;

namespace Persistence
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);

        IEnumerable<E> FindAll();

        void Save(E entity);

        void Delete(ID id);

        void Update(E entity);

    }
}
