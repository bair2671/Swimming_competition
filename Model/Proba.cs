using System;

namespace Model
{
    [Serializable]
    public class Proba : Entity<int>
    {
        private int Distanta;
        private string Stil;

        public Proba(int distanta, string stil)
        {
            this.Distanta = distanta;
            this.Stil = stil;
        }

        public int GetDistanta()
        {
            return Distanta;
        }

        public void SetDistanta(int distanta)
        {
            this.Distanta = distanta;
        }

        public string GetStil()
        {
            return Stil;
        }

        public void SetStil(string stil)
        {
            this.Stil = stil;
        }
    }
}
