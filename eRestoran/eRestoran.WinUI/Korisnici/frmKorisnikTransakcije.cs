using eRestoran.Model.Requests;
using eRestoran.WinUI.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI.Korisnici
{
    public partial class frmKorisnikTransakcije : Form
    {
        private readonly ApiService _uplate = new ApiService("Uplata");
        private readonly ApiService _korisnici = new ApiService("Korisnik");

        public frmKorisnikTransakcije()
        {
            InitializeComponent();
        }

        private async void frmKorisnikTransakcije_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            await LoadKorisnici();
        }

        private async Task LoadKorisnici()
        {
            var korisnici = await _korisnici.Get<List<Model.Korisnik>>();

            cmbKorisnici.DataSource = korisnici;
            cmbKorisnici.DisplayMember = "ImePrezime";
            cmbKorisnici.ValueMember = "Id";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var uplateRequest = new UplataSearchRequest()
            {
                KorisnikId = int.Parse(cmbKorisnici.SelectedValue.ToString())
            };

            var uplate = await _uplate.Get<List<Model.Uplata>>(uplateRequest);
            if(uplate == null)
            {
                MessageBox.Show("Korisnik nema uplata.");
                return;
            }

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", uplate);
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.ReportEmbeddedResource = "eRestoran.WinUI.Reports.rptKorisnikTransakcije.rdlc";
            reportViewer1.LocalReport.SetParameters(new ReportParameter("ImeKlijenta", cmbKorisnici.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}