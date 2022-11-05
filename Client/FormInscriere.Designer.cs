namespace Client
{
    partial class FormInscriere
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
            this.listBoxProbe = new System.Windows.Forms.CheckedListBox();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.buttonInscriere = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.numericUpDownVarsta = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarsta)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxProbe
            // 
            this.listBoxProbe.FormattingEnabled = true;
            this.listBoxProbe.Location = new System.Drawing.Point(44, 210);
            this.listBoxProbe.Name = "listBoxProbe";
            this.listBoxProbe.Size = new System.Drawing.Size(209, 174);
            this.listBoxProbe.TabIndex = 0;
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(315, 427);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(107, 38);
            this.buttonInapoi.TabIndex = 1;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // buttonInscriere
            // 
            this.buttonInscriere.Location = new System.Drawing.Point(198, 427);
            this.buttonInscriere.Name = "buttonInscriere";
            this.buttonInscriere.Size = new System.Drawing.Size(111, 38);
            this.buttonInscriere.TabIndex = 2;
            this.buttonInscriere.Text = "Inscriere";
            this.buttonInscriere.UseVisualStyleBackColor = true;
            this.buttonInscriere.Click += new System.EventHandler(this.buttonInscriere_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Varsta";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(101, 73);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(152, 22);
            this.textBoxNume.TabIndex = 5;
            // 
            // numericUpDownVarsta
            // 
            this.numericUpDownVarsta.Location = new System.Drawing.Point(101, 121);
            this.numericUpDownVarsta.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownVarsta.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownVarsta.Name = "numericUpDownVarsta";
            this.numericUpDownVarsta.Size = new System.Drawing.Size(152, 22);
            this.numericUpDownVarsta.TabIndex = 6;
            this.numericUpDownVarsta.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selecteaza probele:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Introdu datele participantului:";
            // 
            // FormInscriere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 481);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownVarsta);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInscriere);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.listBoxProbe);
            this.Name = "FormInscriere";
            this.Text = "Inscriere";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInscriere_FormClosing);
            this.Load += new System.EventHandler(this.FormInscriere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarsta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listBoxProbe;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.Button buttonInscriere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.NumericUpDown numericUpDownVarsta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}