
namespace eRestoran.WinUI.Narudzbe
{
    partial class frmNarudzbaStatus
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
            this.lblNarudzba = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatusiNarudzbe = new System.Windows.Forms.ComboBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNarudzba
            // 
            this.lblNarudzba.AutoSize = true;
            this.lblNarudzba.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarudzba.Location = new System.Drawing.Point(73, 24);
            this.lblNarudzba.Name = "lblNarudzba";
            this.lblNarudzba.Size = new System.Drawing.Size(103, 17);
            this.lblNarudzba.TabIndex = 0;
            this.lblNarudzba.Text = "Narudzba br.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status:";
            // 
            // cmbStatusiNarudzbe
            // 
            this.cmbStatusiNarudzbe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusiNarudzbe.FormattingEnabled = true;
            this.cmbStatusiNarudzbe.Location = new System.Drawing.Point(131, 65);
            this.cmbStatusiNarudzbe.Name = "cmbStatusiNarudzbe";
            this.cmbStatusiNarudzbe.Size = new System.Drawing.Size(180, 24);
            this.cmbStatusiNarudzbe.TabIndex = 3;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(149, 108);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(84, 33);
            this.btnSpremi.TabIndex = 4;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_ClickAsync);
            // 
            // frmNarudzbaStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 153);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.cmbStatusiNarudzbe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNarudzba);
            this.Name = "frmNarudzbaStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNarudzbaStatus";
            this.Load += new System.EventHandler(this.frmNarudzbaStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNarudzba;
        private System.Windows.Forms.ComboBox cmbStatusiNarudzbe;
        private System.Windows.Forms.Button btnSpremi;
    }
}