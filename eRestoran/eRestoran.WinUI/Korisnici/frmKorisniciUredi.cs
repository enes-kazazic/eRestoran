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
    public partial class frmKorisniciUredi : Form
    {
        private readonly ApiService _korisnici = new ApiService("Korisnik");
        private readonly int KorisnikId;
        public frmKorisniciUredi(int korisnikId)
        {
            InitializeComponent();
            KorisnikId = korisnikId;
        }

        private async void frmKorisniciUredi_Load(object sender, EventArgs e)
        {
            var korisnik = await _korisnici.GetById<Korisnik>(KorisnikId);
            LoadData(korisnik);
        }

        private void LoadData(Korisnik korisnik)
        {
            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtUsername.Text = korisnik.KorisnickoIme;

            if (korisnik.Uposlenik != null)
            {
                groupBox2.Visible = true;
                txtNazivPosla.Text = korisnik.Uposlenik.NazivPosla;
                dtpDatumZaposlenja.Value = korisnik.Uposlenik.DatumZaposlenja;
            }
        }
        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            var request = new KorisnikUpsertRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtUsername.Text,
                NazivPosla = txtNazivPosla.Text,
                DatumZaposlenja = Convert.ToDateTime(dtpDatumZaposlenja.Text)
            };

            await _korisnici.Update<Korisnik>(KorisnikId, request);

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
            else if (string.IsNullOrWhiteSpace(txtNazivPosla.Text))
            {
                errorProvider1.SetError(txtNazivPosla, "Obavezno polje.");
                return false;
            }

            return true;
        }
    }
}

