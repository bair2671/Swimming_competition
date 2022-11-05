namespace Client
{
    partial class FormParticipanti
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.TabelParticipanti = new System.Windows.Forms.DataGridView();
            this.labelParticipanti = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TabelParticipanti)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(356, 427);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(128, 38);
            this.buttonInapoi.TabIndex = 0;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // TabelParticipanti
            // 
            this.TabelParticipanti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TabelParticipanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TabelParticipanti.DefaultCellStyle = dataGridViewCellStyle1;
            this.TabelParticipanti.Location = new System.Drawing.Point(22, 72);
            this.TabelParticipanti.Name = "TabelParticipanti";
            this.TabelParticipanti.RowHeadersWidth = 51;
            this.TabelParticipanti.RowTemplate.Height = 24;
            this.TabelParticipanti.Size = new System.Drawing.Size(462, 286);
            this.TabelParticipanti.TabIndex = 1;
            // 
            // labelParticipanti
            // 
            this.labelParticipanti.AutoSize = true;
            this.labelParticipanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParticipanti.Location = new System.Drawing.Point(18, 30);
            this.labelParticipanti.Name = "labelParticipanti";
            this.labelParticipanti.Size = new System.Drawing.Size(167, 20);
            this.labelParticipanti.TabIndex = 2;
            this.labelParticipanti.Text = "Participantii la proba ";
            // 
            // FormParticipanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 487);
            this.Controls.Add(this.labelParticipanti);
            this.Controls.Add(this.TabelParticipanti);
            this.Controls.Add(this.buttonInapoi);
            this.Name = "FormParticipanti";
            this.Text = "Participanti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParticipanti_FormClosing);
            this.Load += new System.EventHandler(this.FormParticipanti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TabelParticipanti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.DataGridView TabelParticipanti;
        private System.Windows.Forms.Label labelParticipanti;
    }
}