
namespace eRestoran.WinUI.Narudzbe
{
    partial class frmDetaljiNarudzbe
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
            this.lblBrojNarudzbe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKlijentImePrezime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDatumNarudzbe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatusNarudzbe = new System.Windows.Forms.Label();
            this.dgvJela = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ukupno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPromijeniStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrojNarudzbe
            // 
            this.lblBrojNarudzbe.AutoSize = true;
            this.lblBrojNarudzbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojNarudzbe.Location = new System.Drawing.Point(12, 9);
            this.lblBrojNarudzbe.Name = "lblBrojNarudzbe";
            this.lblBrojNarudzbe.Size = new System.Drawing.Size(103, 17);
            this.lblBrojNarudzbe.TabIndex = 0;
            this.lblBrojNarudzbe.Text = "Narudzba br.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Klijent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 3;
            // 
            // lblKlijentImePrezime
            // 
            this.lblKlijentImePrezime.AutoSize = true;
            this.lblKlijentImePrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlijentImePrezime.Location = new System.Drawing.Point(57, 43);
            this.lblKlijentImePrezime.Name = "lblKlijentImePrezime";
            this.lblKlijentImePrezime.Size = new System.Drawing.Size(0, 17);
            this.lblKlijentImePrezime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Datum narudzbe:";
            // 
            // lblDatumNarudzbe
            // 
            this.lblDatumNarudzbe.AutoSize = true;
            this.lblDatumNarudzbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumNarudzbe.Location = new System.Drawing.Point(517, 9);
            this.lblDatumNarudzbe.Name = "lblDatumNarudzbe";
            this.lblDatumNarudzbe.Size = new System.Drawing.Size(0, 17);
            this.lblDatumNarudzbe.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status narudzbe:";
            // 
            // lblStatusNarudzbe
            // 
            this.lblStatusNarudzbe.AutoSize = true;
            this.lblStatusNarudzbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusNarudzbe.Location = new System.Drawing.Point(517, 43);
            this.lblStatusNarudzbe.Name = "lblStatusNarudzbe";
            this.lblStatusNarudzbe.Size = new System.Drawing.Size(0, 17);
            this.lblStatusNarudzbe.TabIndex = 8;
            // 
            // dgvJela
            // 
            this.dgvJela.AllowUserToAddRows = false;
            this.dgvJela.AllowUserToDeleteRows = false;
            this.dgvJela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Opis,
            this.Cijena,
            this.Kolicina,
            this.Ukupno});
            this.dgvJela.Location = new System.Drawing.Point(16, 122);
            this.dgvJela.Name = "dgvJela";
            this.dgvJela.ReadOnly = true;
            this.dgvJela.RowHeadersWidth = 51;
            this.dgvJela.RowTemplate.Height = 24;
            this.dgvJela.Size = new System.Drawing.Size(773, 316);
            this.dgvJela.TabIndex = 9;
            // 
            // Naziv
            // 
            this.Naziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Naziv.DataPropertyName = "JeloNaziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opis.DataPropertyName = "JeloOpis";
            this.Opis.HeaderText = "Opis";
            this.Opis.MinimumWidth = 6;
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.MinimumWidth = 6;
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // Ukupno
            // 
            this.Ukupno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ukupno.DataPropertyName = "Ukupno";
            this.Ukupno.HeaderText = "Ukupno";
            this.Ukupno.MinimumWidth = 6;
            this.Ukupno.Name = "Ukupno";
            this.Ukupno.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Lista jela:";
            // 
            // btnPromijeniStatus
            // 
            this.btnPromijeniStatus.Location = new System.Drawing.Point(688, 36);
            this.btnPromijeniStatus.Name = "btnPromijeniStatus";
            this.btnPromijeniStatus.Size = new System.Drawing.Size(101, 31);
            this.btnPromijeniStatus.TabIndex = 11;
            this.btnPromijeniStatus.Text = "Promijeni";
            this.btnPromijeniStatus.UseVisualStyleBackColor = true;
            this.btnPromijeniStatus.Click += new System.EventHandler(this.btnPromijeniStatus_Click);
            // 
            // frmDetaljiNarudzbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPromijeniStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvJela);
            this.Controls.Add(this.lblStatusNarudzbe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDatumNarudzbe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKlijentImePrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBrojNarudzbe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetaljiNarudzbe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalj iNarudzbe";
            this.Load += new System.EventHandler(this.frmDetaljiNarudzbe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrojNarudzbe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKlijentImePrezime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDatumNarudzbe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatusNarudzbe;
        private System.Windows.Forms.DataGridView dgvJela;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ukupno;
        private System.Windows.Forms.Button btnPromijeniStatus;
    }
}