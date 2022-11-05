using System;

namespace Model
{   
    [Serializable]
    public class Inscriere : Entity<int>
    {
        private Participant Participant;
        private Proba Proba;

        public Inscriere(Participant Participant, Proba Proba)
        {
            this.Participant = Participant;
            this.Proba = Proba;
        }

        public Participant GetParticipant()
        {
            return Participant;
        }

        public void SetParticipant(Participant Participant)
        {
            this.Participant = Participant;
        }

        public Proba GetProba()
        {
            return Proba;
        }

        public void SetIdProba(Proba Proba)
        {
            this.Proba = Proba;
        }
    }
}
