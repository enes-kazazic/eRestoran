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
    public partial class frmNarudzbaStatus : Form
    {
        private readonly ApiService _statusNarudzbe = new ApiService("StatusNarudzbe");
        private readonly ApiService _narudzbe = new ApiService("Narudzba");
        private int narudzbaId { get; set; }

        public frmNarudzbaStatus(int narudzbaId)
        {
            InitializeComponent();
            this.narudzbaId = narudzbaId;
        }

        private async void frmNarudzbaStatus_Load(object sender, EventArgs e)
        {
            await LoadStatusiAsync();
        }

        private async Task LoadStatusiAsync()
        {
            var statusiNarudzbe = await _statusNarudzbe.Get<List<StatusNarudzbe>>();

            var narudzba = await _narudzbe.GetById<Narudzba>(narudzbaId);

            lblNarudzba.Text = "Narudzba br. " + narudzba.Id;

            cmbStatusiNarudzbe.DataSource = statusiNarudzbe;
            cmbStatusiNarudzbe.DisplayMember = "Naziv";
            cmbStatusiNarudzbe.ValueMember = "Id";

            cmbStatusiNarudzbe.SelectedValue = narudzba.StatusNarudzbeId;
        }

        private async void btnSpremi_ClickAsync(object sender, EventArgs e)
        {
            int? _id = null;
            var objId = cmbStatusiNarudzbe.SelectedValue;

            if (int.TryParse(objId.ToString(), out int id))
            {
                _id = id;
            }

            var request = new NarudzbaUpsertRequest
            {
                StatusNarudzbeId = id
            };

           await _narudzbe.Update<Narudzba>(narudzbaId, request);

            Close();
        }
    }
}
