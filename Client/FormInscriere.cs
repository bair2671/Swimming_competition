using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;

namespace Client
{
    public partial class FormInscriere : Form
    {
        IServices server;
        public FormInscriere(IServices server)
        {
            this.server = server;
            InitializeComponent();
        }
        
        private void FormInscriere_Load(object sender, EventArgs e)
        {
            server.FindAllProbe().ToList().ForEach(x => listBoxProbe.Items.Add(x.GetDistanta() + "m " + x.GetStil()));
        }
        
        private void FormInscriere_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            Form form = new FormHome(server);
            form.Show();
            Hide();
        }

        private void buttonInscriere_Click(object sender, EventArgs e)
        {
            if (textBoxNume.Text == "")
            {
                MessageBox.Show("Nu ai introdus numele participantului!", "Eroare", 0, MessageBoxIcon.Warning);
            }
            else
                try
                {
                    var list = listBoxProbe.CheckedItems;
                    if (list.Count == 0)
                    {
                        MessageBox.Show("Nu ai selectat nicio proba!", "Eroare", 0, MessageBoxIcon.Warning);
                        return;
                    }
                    List<Inscriere> inscrieri = new List<Inscriere>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        string[] str = list[i].ToString().Split(' ');
                        int distanta = Int32.Parse(str[0].Split('m')[0]);
                        string stil = str[1];
                        inscrieri.Add(new Inscriere(new Participant(textBoxNume.Text,(int)numericUpDownVarsta.Value),new Proba(distanta,stil)));
                    } 
                    server.Inscriere(inscrieri.ToArray());
                    MessageBox.Show("Participant inscris cu succes!", "", 0, MessageBoxIcon.Information);
                    textBoxNume.Clear();
                    numericUpDownVarsta.Value = 18;
                    foreach (int i in listBoxProbe.CheckedIndices)
                    {
                        listBoxProbe.SetItemChecked(i, false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eroare", 0, MessageBoxIcon.Error);
                }
        }

       
    }
}
