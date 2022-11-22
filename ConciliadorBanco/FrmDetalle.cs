using ConciliadorBanco.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConciliadorBanco
{
    public partial class FrmDetalle : Form
    {
        public List<EdoCtaBANCO> filtradosEdoCtaBANCO;
        public List<DescargaATL> filtradosDescargaATL;
        public int contenido;
        public Form1 Opener { get; set; }
        public FrmDetalle()
        {
            InitializeComponent();
            if(contenido==0)
            {
                dgvDetalle.DataSource = filtradosEdoCtaBANCO;
            } else
            {
                dgvDetalle.DataSource = filtradosDescargaATL;
            }

            dgvDetalle.Refresh();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            if (contenido == 0)
            {
                dgvDetalle.DataSource = filtradosEdoCtaBANCO;
                AparienciadgvDetalleEdoCta();
                this.Width = dgvDetalle.Width + 20;
                this.Height = dgvDetalle.Height;
            }
            else
            {
                dgvDetalle.DataSource = filtradosDescargaATL;
                AparienciadgvDetalleArchivos();
                this.Width = dgvDetalle.Width+20;
                this.Height = dgvDetalle.Height;

            }
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        private void AparienciadgvDetalleArchivos()
        {
            dgvDetalle.Width = 240;

            //AllCells - AllCellsExceptHeader - ColumnHeader - DisplayedCells - DisplayedCellsExceptHeader - Fill - None - NotSet
            //dgvArchivos.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns[0].Width = 70;
            dgvDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[1].Width = 80;
            dgvDetalle.Columns[1].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[2].Width = 30;
            dgvDetalle.Columns[2].DefaultCellStyle.Format = "#";
            dgvDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void AparienciadgvDetalleEdoCta()
        {
            dgvDetalle.Width = 590;

            //AllCells - AllCellsExceptHeader - ColumnHeader - DisplayedCells - DisplayedCellsExceptHeader - Fill - None - NotSet
            //dgvArchivos.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalle.Columns[0].Width = 70;
            dgvDetalle.Columns[0].DefaultCellStyle.Format = "#";
            dgvDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[1].Width = 220;

            dgvDetalle.Columns[2].Width = 90;
            dgvDetalle.Columns[2].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[3].Width = 30;
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[4].Width = 60;

            dgvDetalle.Columns[5].Width = 30;
            dgvDetalle.Columns[5].DefaultCellStyle.Format = "0";
            dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
