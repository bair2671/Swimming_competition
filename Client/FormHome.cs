using System;
using System.Linq;
using System.Windows.Forms;
using Model;
using Networking;
using Service;


namespace Client
{
    public partial class FormHome : Form,Observer
    {
        public event EventHandler<ChatUserEventArgs> updateEvent; 
        private readonly IServices server;
        public FormHome(IServices server)
        {
            this.server = server;
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            ((ServerProxy) server).SetClient(this);
            TabelProbe.ColumnCount = 3; 
            TabelProbe.Columns[0].Name = "Distanta";
            TabelProbe.Columns[1].Name = "Stil";
            TabelProbe.Columns[2].Name = "Nr. participanti";
            initModel();
        }

        private void initModel()
        {
            TabelProbe.Rows.Clear();
            server.FindAllProbaWrrapers().ToList().ForEach(x => TabelProbe.Rows.Add(x.GetDistanta(), x.GetStil(), x.GetNrParticipanti()));
        }

        private void buttonInscriere_Click(object sender, EventArgs e)
        {
            Form form = new FormInscriere(server);
            form.Show();
            Hide();
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {    
            server.Logout(this);
            Form form = new FormLogin(server);
            form.Show(); 
            Hide();
        }

        private void buttonParticipanti_Click(object sender, EventArgs e)
        {
            if (TabelProbe.SelectedRows.Count == 0 || TabelProbe.SelectedRows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Nu ati selectat nicio proba!","Eroare",0,MessageBoxIcon.Warning);
                return;
            }
            Form form = new FormParticipanti(server,server.FindOneProbaByDistanceAndStyle(new Proba((int)TabelProbe.SelectedRows[0].Cells[0].Value, (string)TabelProbe.SelectedRows[0].Cells[1].Value)));
            form.Show();
            Hide();
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
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
