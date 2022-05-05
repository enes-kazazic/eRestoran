using eRestoran.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly ApiService _apiService = new ApiService("Korisnik");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ApiService.Username = txtUsername.Text;
            ApiService.Password = txtPassword.Text;


            var user = await _apiService.Authenticate(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                frmGlavna frm = new frmGlavna();
                frm.Show();
                this.Hide();
            }
            else
            {
                txtPassword.Text = string.Empty;
            }

            Cursor = Cursors.Default;
        }
    }
}
