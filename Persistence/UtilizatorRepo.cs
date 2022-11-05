using Model;

namespace Persistence
{
    public interface UtilizatorRepo : IRepository<int, Utilizator>
    {
        Utilizator FindOneByUsername(string username);
    }
}
