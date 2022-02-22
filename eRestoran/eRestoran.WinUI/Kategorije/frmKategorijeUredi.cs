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
    public partial class frmKategorijeUredi : Form
    {

        private readonly ApiService _kategorije = new ApiService("Kategorija");
        public int Id { get; set; }

        public frmKategorijeUredi(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private async void frmKategorijeUredi_Load(object sender, EventArgs e)
        {
            await LoadData(Id);
        }

        private async Task LoadData(int id)
        {
            var kategorija = await _kategorije.GetById<Kategorija>(id);

            txtNaziv.Text = kategorija.Naziv;
            txtOpis.Text = kategorija.Opis;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {

            if (!Validacija())
                return;

            var request = new KategorijaUpsertRequest()
            {
                Naziv = txtNaziv.Text,
                Opis = txtOpis.Text
            };

            await _kategorije.Update<Kategorija>(Id, request);
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

            return true;
        }
    }
}
