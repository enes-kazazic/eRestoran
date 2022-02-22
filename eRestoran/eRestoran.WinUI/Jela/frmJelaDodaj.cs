using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WinUI.Helpers;
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
    public partial class frmJelaDodaj : Form
    {
        private readonly ApiService _kategorije = new ApiService("Kategorija");
        private readonly ApiService _jelo = new ApiService("Jelo");
        public frmJelaDodaj()
        {
            InitializeComponent();
        }
        private async void frmJelaDodaj_Load(object sender, EventArgs e)
        {
            LoadKategorije();
        }

        private async void LoadKategorije()
        {
            var kategorije = await _kategorije.Get<List<Model.Kategorija>>();

            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Id";
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
                KategorijaId = int.Parse(cmbKategorije.SelectedValue.ToString()),
                Slika = ImageHelper.SystemDrawingToByteArray(pbSlika.Image)
            };

            await _jelo.Insert<Jelo>(request);

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

        private void pbSlika_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
