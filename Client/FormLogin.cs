using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model;
using Service;

namespace Client
{
    public partial class FormLogin : Form
    {
        IServices server;
        public FormLogin(IServices server)
        {
            this.server = server;
            InitializeComponent();
        }

        private void buttonConectare_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text == "")
            {
                MessageBox.Show("Nu ai introdus username-ul!", "Eroare", 0, MessageBoxIcon.Warning);            
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Nu ai introdus parola!", "Eroare", 0,MessageBoxIcon.Warning);   
            }
            else 
                try
                {
                    Form form = new FormHome(server);
                    server.Login(new Utilizator(null,null,textBoxUsername.Text,textBoxPassword.Text),(Observer)form);
                    form.Show();
                    Hide();
                    //form.Show();
                }
                catch(Exception ex)
                {
                    if(ex.Message=="Parola incorecta!") {
                        MessageBox.Show(ex.Message, null, 0, MessageBoxIcon.Warning);
                        textBoxPassword.Clear();
                    }
                    else if(ex.Message=="Nu exista utilizator cu acest username!"){
                        MessageBox.Show(ex.Message, null, 0, MessageBoxIcon.Warning);
                        textBoxUsername.Clear();
                        textBoxPassword.Clear();
                    }
                    else
                        MessageBox.Show(ex.Message, null, 0, MessageBoxIcon.Error);
                }  
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
