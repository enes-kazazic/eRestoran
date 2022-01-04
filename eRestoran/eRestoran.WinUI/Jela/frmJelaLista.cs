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

namespace eRestoran.WinUI.Jela
{
    public partial class frmJelaLista : Form
    {

        private readonly ApiService _kategorije = new ApiService("Kategorija");
        private readonly ApiService _jela = new ApiService("Jelo");
        public frmJelaLista()
        {
            InitializeComponent();
        }

        private async void frmJelaLista_Load(object sender, EventArgs e)
        {
           LoadKategorijeAsync();
           await LoadJelaAsync();
        }

        private async Task LoadJelaAsync(JeloSearchRequest request = null)
        {
            var jela = await _jela.Get<List<Jelo>>(request);
            dgvJela.AutoGenerateColumns = false;
            dgvJela.DataSource = jela;
        }

        private async Task LoadKategorijeAsync()
        {
            var kategorije = await _kategorije.Get<List<Kategorija>>();

            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Id";
        }

        private async void txtNaziv_TextChangedAsync(object sender, EventArgs e)
        {
            var request = new JeloSearchRequest()
            {
                Naziv = txtNaziv.Text.ToLower()
            };

            await LoadJelaAsync(request);
        }

        private async void cmbKategorije_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            int? _id = null;
            var objId = cmbKategorije.SelectedValue;

            if (int.TryParse(objId.ToString(), out int id))
            {
                _id = id;
            }

            var request = new JeloSearchRequest()
            {
                KategorijaId = _id ?? 0
            };

            await LoadJelaAsync(request);
        }
    }
}
