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

namespace eRestoran.WinUI.Narudzbe
{
    public partial class frmDetaljiNarudzbe : Form
    {
        private readonly ApiService _narudzbe = new ApiService("Narudzba");
        private readonly ApiService _stavkeNarudzbe = new ApiService("StavkeNarudzbe");

        private int NarudzbaId { get; set; }
        private int KorisnikId { get; set; }
        public frmDetaljiNarudzbe(int narudzbaId, int korisnikId)
        {
            InitializeComponent();
            NarudzbaId = narudzbaId;
            KorisnikId = korisnikId;
        }

        private async void frmDetaljiNarudzbe_Load(object sender, EventArgs e)
        {
            await LoadDetalji();
            await LoadJela();
        }

        private async Task LoadJela()
        {
            var request = new StavkeNarudzbeSearchRequest()
            {
                NarudzbaId = this.NarudzbaId,
                KorisnikId = this.KorisnikId
            };
            var jela = await _stavkeNarudzbe.Get<List<StavkeNarudzbe>>(request);
            dgvJela.AutoGenerateColumns = false;
            dgvJela.DataSource = jela;
        }

        private async Task LoadDetalji()
        {
            var request = new NarudzbaSearchRequest()
            {
                Id = NarudzbaId,
                KorisnikId = this.KorisnikId
            };

            var narudzba = await _narudzbe.Get<List<Narudzba>>(request);
            lblBrojNarudzbe.Text = "Narudzba br. " + narudzba.First().Id.ToString();
            lblKlijentImePrezime.Text = narudzba.First().Korisnik;
            lblDatumNarudzbe.Text = narudzba.First().DatumNarudzbe.ToString("dd.MM.yyyy");
            lblStatusNarudzbe.Text = narudzba.First().StatusNarudzbe;
        }

        private async void btnPromijeniStatus_Click(object sender, EventArgs e)
        {
            var frm = new frmNarudzbaStatus(NarudzbaId);
            frm.ShowDialog();
            await LoadDetalji();
        }
    }
}
