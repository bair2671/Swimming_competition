using System;
using System.Windows.Forms;
using Networking;
using Service;

namespace Client
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IServices server = new ServerProxy("127.0.0.1", 55555);
            Application.Run(new FormLogin(server));
        }

    }
}