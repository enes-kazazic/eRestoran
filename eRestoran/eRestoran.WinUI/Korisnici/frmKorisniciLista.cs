using eRestoran.Model;
using eRestoran.Model.Requests;
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

namespace eRestoran.WinUI.Korisnici
{
    public partial class frmKorisniciLista : Form
    {

        private readonly ApiService _korisnici = new ApiService("Korisnik");
        public frmKorisniciLista()
        {
            InitializeComponent();
        }

        private async void frmKorisniciLista_Load(object sender, EventArgs e)
        {
            await LoadKorisniciAsync();
        }

        private async Task LoadKorisniciAsync(KorisnikSearchRequest request = null)
        {
            var korisnici = await _korisnici.Get<List<Korisnik>>(request);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = korisnici;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var request = new KorisnikSearchRequest()
            {
                ImePrezime = txtImePrezime.Text.ToLower()
            };

            await LoadKorisniciAsync(request);
        }
    }
}
