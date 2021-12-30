using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WinUI.Services;

namespace eRestoran.WinUI.Narudzbe
{
    public partial class frmNarudzbeLista : Form
    {
        private readonly ApiService _narudzbe = new ApiService("Narudzba");
        private readonly ApiService _statusNarudzbe = new ApiService("StatusNarudzbe");
        public frmNarudzbeLista()
        {
            InitializeComponent();
        }

        private async void frmNarudzbeLista_Load(object sender, EventArgs e)
        {
            var statusiNarudzbe = await _statusNarudzbe.Get<List<StatusNarudzbe>>();

            cmbStatusNaruzbe.DataSource = statusiNarudzbe;
            cmbStatusNaruzbe.DisplayMember = "Naziv";
            cmbStatusNaruzbe.ValueMember = "Id";

            await LoadNarudzbe();                
        }

        private async Task LoadNarudzbe(NarudzbaSearchRequest narudzba = null)
        {
            var narudzbe = await _narudzbe.Get<List<Narudzba>>(narudzba);
            dgvNarudzbe.AutoGenerateColumns = false;
            dgvNarudzbe.DataSource = narudzbe;
        }

        private async void cmbStatusNaruzbe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? _id = null;
            var objId = cmbStatusNaruzbe.SelectedValue;

            if (int.TryParse(objId.ToString(), out int id))
            {
                _id = id;
            }

            NarudzbaSearchRequest search = new NarudzbaSearchRequest
            {
                StatusNarudzbeId = _id ?? 0
            };

            await LoadNarudzbe(search);
        }

        private async void dtpDatumNarudzbe_ValueChangedAsync(object sender, EventArgs e)
        {
            NarudzbaSearchRequest search = new NarudzbaSearchRequest
            {
                DatumNarudzbe = Convert.ToDateTime(dtpDatumNarudzbe.Text)
            };

            await LoadNarudzbe(search);
        }
    }
}