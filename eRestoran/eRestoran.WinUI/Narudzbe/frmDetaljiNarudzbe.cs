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

        private void dgvJela_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];
            if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
            {
                string[] props = col.DataPropertyName.Split('.');
                var propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++)
                {
                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }
                e.Value = val;
            }
        }
    }
}
