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
    public partial class frmKorisniciDodaj : Form
    {
        private readonly ApiService _korisnici = new ApiService("Korisnik");
        public frmKorisniciDodaj()
        {
            InitializeComponent();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            var request = new KorisnikUpsertRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtUsername.Text,
                Password = txtPassword.Text,
                NazivPosla = txtNazivPosla.Text,
                DatumZaposlenja = Convert.ToDateTime(dtpDatumZaposlenja.Text)
            };

            await _korisnici.Insert<Korisnik>(request);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool Validacija()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, "Obavezno polje.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, "Obavezno polje.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Obavezno polje.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Obavezno polje.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNazivPosla.Text))
            {
                errorProvider1.SetError(txtNazivPosla, "Obavezno polje.");
                return false;
            }

            return true;
        }
    }
}
