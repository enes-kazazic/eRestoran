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
        public frmDetaljiNarudzbe(int narudzbaId)
        {
            InitializeComponent();
            NarudzbaId = narudzbaId;
        }

        private async void frmDetaljiNarudzbe_Load(object sender, EventArgs e)
        {
            LoadDetalji();
            LoadJela();
        }

        private void LoadJela()
        {
            //_stavkeNarudzbe.Get()
        }

        private async Task LoadDetalji()
        {
            var narudzba = await _narudzbe.GetById<Model.Narudzba>(NarudzbaId);
            lblBrojNarudzbe.Text = narudzba.Id.ToString();
            lblKlijentImePrezime.Text = narudzba.Korisnik;
            lblDatumNarudzbe.Text = narudzba.DatumNarudzbe.ToString("dd.MM.yyyy");
            lblStatusNarudzbe.Text = narudzba.StatusNarudzbe;
        }
    }
}
