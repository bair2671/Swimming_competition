using Model;
using Service;
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
using Networking;
using Service;

namespace Client
{
    public partial class FormParticipanti : Form,Observer
    {
        IServices server;
        Proba proba;
        public FormParticipanti(IServices server, Proba proba)
        {
            this.server = server;
            this.proba = proba;
            InitializeComponent();
        }

        private void FormParticipanti_Load(object sender, EventArgs e)
        {
            ((ServerProxy) server).SetClient(this);
            TabelParticipanti.ColumnCount = 3;
            TabelParticipanti.Columns[0].Name = "Nume";
            TabelParticipanti.Columns[1].Name = "Varsta";
            TabelParticipanti.Columns[2].Name = "Probe ";
            labelParticipanti.Text += proba.GetDistanta() + "m " + proba.GetStil();
            initModel();
        }

        private void initModel()
        {
            TabelParticipanti.Rows.Clear();
            server.ParticipantWrrapersProba(proba.GetID()).ToList().ForEach(x =>
            {
                string probe = x.GetProbe();
                probe.Remove(probe.Length - 2);
                TabelParticipanti.Rows.Add(x.GetNume(), x.GetVarsta(), probe);
            });
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            Form form = new FormHome(server);
            form.Show();
            Hide();
        }

        private void FormParticipanti_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void InscriereUpdate()
        {
            BeginInvoke(new InvokeDelegate(initModel));
        }
        
        private delegate void InvokeDelegate();
    }
}
