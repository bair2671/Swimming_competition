using System;
using Model;
using Model.Wrraper;

namespace Networking
{
    public interface Request {}

    
    [Serializable]
    public class LoginRequest : Request
    {
        private UtilizatorDTO user;

        public LoginRequest(UtilizatorDTO user)
        {
            this.user = user;
        }

        public virtual UtilizatorDTO User
        {
            get
            {
                return user;
            }
        }
    }
    
    
    [Serializable]
    public class LogoutRequest : Request {}
    
    [Serializable]
    public class InscriereRequest : Request
    {
        private Inscriere[] inscrieri;

        public InscriereRequest(Inscriere[] inscrieri)
        {
            this.inscrieri=inscrieri;
        }

        public virtual Inscriere[] Inscrieri
        {
            get
            {
                return inscrieri;
            }
        }
    }
    
    
    [Serializable]
    public class FindAllProbeRequest : Request {}
    
    
    [Serializable]
    public class FindAllProbaWrrapersRequest : Request {}
    
    
    [Serializable]
    public class FindOneProbaByDistanceAndStyleRequest : Request
    {
        private Proba proba;

        public FindOneProbaByDistanceAndStyleRequest(Proba proba)
        {
            this.proba = proba;
        }

        public virtual Proba Proba
        {
            get
            {
                return proba;
            }
        }
    }
    
    
    [Serializable]
    public class ParticipantWrrapersProbaRequest : Request
    {
        private int idProba;

        public ParticipantWrrapersProbaRequest(int idProba)
        {
            this.idProba = idProba;
        }

        public virtual int IdProba
        {
            get
            {
                return idProba;
            }
        }
    }
}