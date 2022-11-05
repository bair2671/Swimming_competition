using System;

namespace Model.Wrraper
{
    [Serializable]
    public class ProbaWrraper : Proba
    {
        int nrParticipanti;

        public ProbaWrraper(Proba proba,int nrParticipanti) :  base(proba.GetDistanta(), proba.GetStil()){
            SetID(proba.GetID());
            this.nrParticipanti = nrParticipanti;
        }

        public int GetNrParticipanti() {
            return nrParticipanti;
        }

        public void setNrParticipanti(int nrParticipanti) {
            this.nrParticipanti = nrParticipanti;
        }

    }
}