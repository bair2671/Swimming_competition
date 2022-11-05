using System;

namespace Networking
{
    [Serializable]
    public class UtilizatorDTO
    {
        private string username;
        private string password;

        public UtilizatorDTO(string username) : this(username, ""){}
        public UtilizatorDTO(string username, string password) 
        {
            this.username = username;
            this.password = password;
        }

        public string GetUsername() 
        {
            return username;
        }

        public void GetUsername(string username) 
        {
            this.username = username;
        }

        public string GetPassword()
        {
            return password;
        }

        public override string ToString(){
            return "UserDTO["+ username +' '+ password +"]";
        }
    }
}