using Model;

namespace Networking
{
    public class DTOUtils
    {
        public static Utilizator GetFromDTO(UtilizatorDTO usdto)
        {
            string username =usdto.GetUsername();
            string pass =usdto.GetPassword();
            return new Utilizator("","",username, pass);

        }
        public static UtilizatorDTO GetDTO(Utilizator user)
        {
            string username = user.GetUsername();
            string pass =user.GetPassword();
            return new UtilizatorDTO(username, pass);
        }
    }
}