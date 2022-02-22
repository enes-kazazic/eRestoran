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

namespace eRestoran.WinUI.Kategorije
{
    public partial class frmKategorijeLista : Form
    {
        private readonly ApiService _kategorije = new ApiService("Kategorija");
        public frmKategorijeLista()
        {
            InitializeComponent();
        }

        private async void frmKategorijeLista_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
        }

        private async Task LoadKategorije(KategorijaSearchRequest request = null)
        {
            var kategorije = await _kategorije.Get<List<Kategorija>>(request);
            dgvKategorije.DataSource = kategorije;
            dgvKategorije.AutoGenerateColumns = false;
        }

        private async void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            var request = new KategorijaSearchRequest()
            {
                Naziv = txtNaziv.Text.ToLower()
            };

            await LoadKategorije(request);
        }

        private async void dgvKategorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKategorije.Columns[e.ColumnIndex].Name == "Uredi")
            {
                var kategorijaId = int.Parse(dgvKategorije.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmKategorijeUredi frm = new frmKategorijeUredi(kategorijaId);
                if (frm.ShowDialog() == DialogResult.OK) ;
                await LoadKategorije();
            }

            if (dgvKategorije.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                var id = int.Parse(dgvKategorije.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                await _kategorije.Delete<Kategorija>(id);
                await LoadKategorije();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmKategorijeDodaj frm = new frmKategorijeDodaj();
            frm.Show();
        }
    }
}
