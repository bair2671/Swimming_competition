using System;

namespace Model
{
    [Serializable]
    public class Utilizator : Entity<int>
    {
        private string Nume;
        private string Prenume;
        private string Username;
        private string Password;

        public Utilizator(string nume, string prenume, string username, string password)
        {
            Nume = nume;
            Prenume = prenume;
            Username = username;
            Password = password;
        }

        public string GetNume()
        {
            return Nume;
        }

        public string GetPrenume()
        {
            return Prenume;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void SetNume(string nume)
        {
            Nume = nume;
        }

        public void SetPrenume(string prenume)
        {
            Prenume = prenume;
        }

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
