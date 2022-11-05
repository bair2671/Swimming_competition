namespace Client
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabelProbe = new System.Windows.Forms.DataGridView();
            this.buttonParticipanti = new System.Windows.Forms.Button();
            this.buttonDeconectare = new System.Windows.Forms.Button();
            this.buttonInscriere = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TabelProbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabelProbe
            // 
            this.TabelProbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabelProbe.Location = new System.Drawing.Point(54, 59);
            this.TabelProbe.Name = "TabelProbe";
            this.TabelProbe.RowHeadersWidth = 51;
            this.TabelProbe.RowTemplate.Height = 24;
            this.TabelProbe.Size = new System.Drawing.Size(471, 315);
            this.TabelProbe.TabIndex = 0;
            // 
            // buttonParticipanti
            // 
            this.buttonParticipanti.Location = new System.Drawing.Point(587, 339);
            this.buttonParticipanti.Name = "buttonParticipanti";
            this.buttonParticipanti.Size = new System.Drawing.Size(159, 35);
            this.buttonParticipanti.TabIndex = 1;
            this.buttonParticipanti.Text = "Vezi participantii\r\n";
            this.buttonParticipanti.UseVisualStyleBackColor = true;
            this.buttonParticipanti.Click += new System.EventHandler(this.buttonParticipanti_Click);
            // 
            // buttonDeconectare
            // 
            this.buttonDeconectare.Location = new System.Drawing.Point(587, 59);
            this.buttonDeconectare.Name = "buttonDeconectare";
            this.buttonDeconectare.Size = new System.Drawing.Size(159, 35);
            this.buttonDeconectare.TabIndex = 2;
            this.buttonDeconectare.Text = "Deconectare";
            this.buttonDeconectare.UseVisualStyleBackColor = true;
            this.buttonDeconectare.Click += new System.EventHandler(this.buttonDeconectare_Click);
            // 
            // buttonInscriere
            // 
            this.buttonInscriere.Location = new System.Drawing.Point(587, 268);
            this.buttonInscriere.Name = "buttonInscriere";
            this.buttonInscriere.Size = new System.Drawing.Size(159, 35);
            this.buttonInscriere.TabIndex = 3;
            this.buttonInscriere.Text = "Inscriere participant";
            this.buttonInscriere.UseVisualStyleBackColor = true;
            this.buttonInscriere.Click += new System.EventHandler(this.buttonInscriere_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Probe";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInscriere);
            this.Controls.Add(this.buttonDeconectare);
            this.Controls.Add(this.buttonParticipanti);
            this.Controls.Add(this.TabelProbe);
            this.Name = "FormHome";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TabelProbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TabelProbe;
        private System.Windows.Forms.Button buttonParticipanti;
        private System.Windows.Forms.Button buttonDeconectare;
        private System.Windows.Forms.Button buttonInscriere;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label1;
    }
}

