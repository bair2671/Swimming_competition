using Model;

namespace Persistence
{
    public interface ProbaRepo : IRepository<int, Proba>
    {
        Proba FindOneByDistanceAndStyle(int distanta,string stil);
    }
}
