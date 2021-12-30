
namespace eRestoran.WinUI.Narudzbe
{
    partial class frmNarudzbeLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNarudzbe = new System.Windows.Forms.DataGridView();
            this.dtpDatumNarudzbe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatusNaruzbe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNarudzbe
            // 
            this.dgvNarudzbe.AllowUserToAddRows = false;
            this.dgvNarudzbe.AllowUserToDeleteRows = false;
            this.dgvNarudzbe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNarudzbe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Korisnik,
            this.StatusNarudzbe,
            this.DatumNarudzbe,
            this.Detalji});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNarudzbe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNarudzbe.Location = new System.Drawing.Point(12, 89);
            this.dgvNarudzbe.Name = "dgvNarudzbe";
            this.dgvNarudzbe.ReadOnly = true;
            this.dgvNarudzbe.RowHeadersWidth = 51;
            this.dgvNarudzbe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNarudzbe.Size = new System.Drawing.Size(780, 349);
            this.dgvNarudzbe.TabIndex = 0;
            // 
            // dtpDatumNarudzbe
            // 
            this.dtpDatumNarudzbe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumNarudzbe.Location = new System.Drawing.Point(15, 51);
            this.dtpDatumNarudzbe.Name = "dtpDatumNarudzbe";
            this.dtpDatumNarudzbe.Size = new System.Drawing.Size(220, 22);
            this.dtpDatumNarudzbe.TabIndex = 1;
            this.dtpDatumNarudzbe.ValueChanged += new System.EventHandler(this.dtpDatumNarudzbe_ValueChangedAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum narudzbe";
            // 
            // cmbStatusNaruzbe
            // 
            this.cmbStatusNaruzbe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusNaruzbe.FormattingEnabled = true;
            this.cmbStatusNaruzbe.Location = new System.Drawing.Point(286, 49);
            this.cmbStatusNaruzbe.Name = "cmbStatusNaruzbe";
            this.cmbStatusNaruzbe.Size = new System.Drawing.Size(148, 24);
            this.cmbStatusNaruzbe.TabIndex = 3;
            this.cmbStatusNaruzbe.SelectedIndexChanged += new System.EventHandler(this.cmbStatusNaruzbe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status narudzbe";
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 53.47594F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Korisnik
            // 
            this.Korisnik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.FillWeight = 111.631F;
            this.Korisnik.HeaderText = "Ime i prezime";
            this.Korisnik.MinimumWidth = 6;
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            // 
            // StatusNarudzbe
            // 
            this.StatusNarudzbe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusNarudzbe.DataPropertyName = "StatusNarudzbe";
            this.StatusNarudzbe.FillWeight = 111.631F;
            this.StatusNarudzbe.HeaderText = "Status Narudzbe";
            this.StatusNarudzbe.MinimumWidth = 6;
            this.StatusNarudzbe.Name = "StatusNarudzbe";
            this.StatusNarudzbe.ReadOnly = true;
            // 
            // DatumNarudzbe
            // 
            this.DatumNarudzbe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumNarudzbe.DataPropertyName = "DatumNarudzbe";
            this.DatumNarudzbe.FillWeight = 111.631F;
            this.DatumNarudzbe.HeaderText = "Datum Narudzbe";
            this.DatumNarudzbe.MinimumWidth = 6;
            this.DatumNarudzbe.Name = "DatumNarudzbe";
            this.DatumNarudzbe.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Detalji.FillWeight = 111.631F;
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.MinimumWidth = 6;
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // frmNarudzbeLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatusNaruzbe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDatumNarudzbe);
            this.Controls.Add(this.dgvNarudzbe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNarudzbeLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista narudzbi";
            this.Load += new System.EventHandler(this.frmNarudzbeLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNarudzbe;
        private System.Windows.Forms.DateTimePicker dtpDatumNarudzbe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatusNaruzbe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumNarudzbe;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
    }
}