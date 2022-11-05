
using System;
using Model;
using Model.Wrraper;

namespace Networking
{
    public interface Response {}
    
    
    [Serializable]
    public class OkResponse : Response {}
    
    
    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }
    
    
    [Serializable]
    public class FindAllProbeResponse : Response
    {
        private Proba[] probe;

        public FindAllProbeResponse(Proba[] probe)
        {
            this.probe = probe;
        }

        public virtual Proba[] Probe
        {
            get
            {
                return probe;
            }
        }
    }
    
    
    [Serializable]
    public class FindAllProbaWrrapersResponse : Response
    {
        private ProbaWrraper[] probe;

        public FindAllProbaWrrapersResponse(ProbaWrraper[] probe)
        {
            this.probe = probe;
        }

        public virtual ProbaWrraper[] Probe
        {
            get
            {
                return probe;
            }
        }
    }
    
    
    [Serializable]
    public class FindOneProbaByDistanceAndStyleResponse : Response
    {
        private Proba proba;

        public FindOneProbaByDistanceAndStyleResponse(Proba proba)
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
    public class ParticipantWrrapersProbaResponse : Response
    {
        private ParticipantWrraper[] participanti;

        public ParticipantWrrapersProbaResponse(ParticipantWrraper[] participanti)
        {
            this.participanti = participanti;
        }

        public virtual ParticipantWrraper[] Participanti
        {
            get
            {
                return participanti;
            }
        }
    }
    
    
    [Serializable]
    public class UpdateResponse : Response {}
    
    
    [Serializable]
    public class InscriereUpdateResponse : UpdateResponse {}
}