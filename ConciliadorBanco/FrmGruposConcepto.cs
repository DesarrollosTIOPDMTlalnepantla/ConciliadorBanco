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
    public partial class FrmGruposConcepto : Form
    {
        public List<GrupoConcepto> filtradosEdoCtaBANCO;
        public Form1 Opener { get; set; }
        public FrmGruposConcepto()
        {
            InitializeComponent();
            dgvGruposConcepto.DataSource = filtradosEdoCtaBANCO;
        }

        private void FrmGruposConcepto_Load(object sender, EventArgs e)
        {



            dgvGruposConcepto.DataSource = filtradosEdoCtaBANCO;

            AparienciadgvConceptos();

            dgvGruposConcepto.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dgvGruposConcepto.Columns[1].DefaultCellStyle.Format = "#";
            dgvGruposConcepto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGruposConcepto.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dgvGruposConcepto.Columns[2].DefaultCellStyle.Format = "#,#.00";
            dgvGruposConcepto.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void AparienciadgvConceptos()
        {
            dgvGruposConcepto.Width = 520;

            //AllCells - AllCellsExceptHeader - ColumnHeader - DisplayedCells - DisplayedCellsExceptHeader - Fill - None - NotSet
            //dgvArchivos.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dgvGruposConcepto.Columns[0].Width = 70;

            dgvGruposConcepto.Columns[1].Width = 30;
            dgvGruposConcepto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvGruposConcepto.Columns[2].Width = 70;
            dgvGruposConcepto.Columns[2].DefaultCellStyle.Format = "#";
            dgvGruposConcepto.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvGruposConcepto.Columns[3].Width = 110;
            //dgvGruposConcepto.Columns[3].DefaultCellStyle.Format = "#,#.00";
            //dgvGruposConcepto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvGruposConcepto.Columns[4].Width = 70;
            //dgvGruposConcepto.Columns[4].DefaultCellStyle.Format = "#";
            //dgvGruposConcepto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvGruposConcepto.Columns[5].Width = 110;
            //dgvGruposConcepto.Columns[5].DefaultCellStyle.Format = "N2";
            //dgvGruposConcepto.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            //dgvArchivos.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;

            //dgvArchivos.Columns[5].CellType


        }

        private void dgvGruposConcepto_DoubleClick(object sender, EventArgs e)
        {
            //var edos = from edo in edosCtaBANCO
            //           where edo.Dia == (int)dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value && edo.Movimiento == 0 &&
            //           (edo.Clave == "2199" || edo.Clave == "2299" || edo.Clave == "2399" || edo.Clave == "2499" || edo.Clave == "2799")
            //           select edo;

            //FrmDetalle frmDetalle = new FrmDetalle();
            //frmDetalle.contenido = 0;
            //frmDetalle.filtradosEdoCtaBANCO = edos.ToList();
            //frmDetalle.Text = "Estado de Cuenta del dia:" + dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value.ToString();
            //frmDetalle.FormClosed += formDetalle_FormClosed;
            //frmDetalle.Opener = this;
            //frmDetalle.WindowState = FormWindowState.Normal;


            //frmDetalle.ShowDialog();
        }
    }
}
