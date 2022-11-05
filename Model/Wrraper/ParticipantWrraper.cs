using System;

namespace Model.Wrraper
{
    [Serializable]
    public class ParticipantWrraper : Participant
    {
        string probe;

        public ParticipantWrraper(Participant participant, string probe) : base(participant.GetNume(), participant.GetVarsta()){
            SetID(participant.GetID());
            this.probe = probe;
        }

        public string GetProbe() {
            return probe;
        }

        public void SetProbe(string probe) {
            this.probe = probe;
        }
    }
}