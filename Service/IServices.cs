using Model;
using Model.Wrraper;

namespace Service
{
    public interface IServices
    {
        void Login(Utilizator user, Observer client);
        void Logout(Observer client);
        Proba[] FindAllProbe();
        Proba FindOneProbaByDistanceAndStyle(Proba proba);
        ProbaWrraper[] FindAllProbaWrrapers();
        ParticipantWrraper[] ParticipantWrrapersProba(int id);
        void Inscriere(Inscriere[] inscrieri);
    }
}