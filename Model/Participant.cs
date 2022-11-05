using System;

namespace Model
{   
    [Serializable]
    public class Participant : Entity<int>
    {
        private string Nume;
        private int Varsta;

        public Participant(string nume, int varsta)
        {
            this.Nume = nume;
            this.Varsta = varsta;
        }

        public string GetNume()
        {
            return Nume;
        }

        public void SetNume(string nume)
        {
            this.Nume = nume;
        }

        public int GetVarsta()
        {
            return Varsta;
        }

        public void SetVarsta(int varsta)
        {
            this.Varsta = varsta;
        }
    }
}
