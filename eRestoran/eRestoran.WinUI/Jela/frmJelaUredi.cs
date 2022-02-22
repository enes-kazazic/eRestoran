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
    public partial class frmJelaUredi : Form
    {
        private readonly ApiService _jelo = new ApiService("Jelo");
        private readonly ApiService _kategorije = new ApiService("Kategorija");

        private readonly int JeloId;

        public frmJelaUredi(int jeloId)
        {
            InitializeComponent();
            JeloId = jeloId;
        }

        private async void frmJelaUredi_Load(object sender, EventArgs e)
        {
            var jelo = await _jelo.GetById<Jelo>(JeloId);
            LoadKategorije(jelo);
            LoadJelo(jelo);
        }

        private void LoadJelo(Jelo jelo)
        {
            txtNaziv.Text = jelo.Naziv;
            txtOpis.Text = jelo.Opis;
            txtCijena.Text = jelo.Cijena.ToString();
        }

        private async void LoadKategorije(Jelo jelo)
        {
            var kategorije = await _kategorije.Get<List<Model.Kategorija>>();

            cmbKategorije.DataSource = kategorije;
            cmbKategorije.ValueMember = "Id";
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.SelectedValue = jelo.KategorijaId;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            var request = new JeloUpsertRequest()
            {
                Naziv = txtNaziv.Text,
                Opis = txtOpis.Text,
                Cijena = txtCijena.Value,
                KategorijaId = int.Parse(cmbKategorije.SelectedValue.ToString())
            };

            await _jelo.Update<Jelo>(JeloId, request);

            this.Close();
        }

        private bool Validacija()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Obavezno polje.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, "Obavezno polje.");
                return false;
            }
            else if (txtCijena.Value == 0)
            {
                errorProvider1.SetError(txtCijena, "Obavezno polje.");
                return false;
            }

            return true;
        }
    }
}
