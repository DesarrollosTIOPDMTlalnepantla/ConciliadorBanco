using ConciliadorBanco.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Create a data source by using a collection initializer.
//otro comentario

namespace ConciliadorBanco
{
    public partial class Form1 : Form
    {
        string[] archivosDescargaATL;
        string[] archivosDomiciliados;
        string[] archivosEdoCtaBANCO;
        List<DescargaATL> descargasATL;
        List<EdoCtaBANCO> edosCtaBANCO;
        List<DescargaATL> soloDescargasATL = new List<DescargaATL>();
        List<EdoCtaBANCO> soloEdosCtaBANCO = new List<EdoCtaBANCO>();
        List<Diferencia> diferentes = new List<Diferencia>();
        List<GrupoConcepto> gruposConcepto = new List<GrupoConcepto>();
        List<Archivo> archivos = new List<Archivo>();
        List<CorteDia> cortesDia = new List<CorteDia>();
        DateTime myVacation1 = new DateTime(2022, 6, 10);
        DateTime myVacation2 = new DateTime(2022, 6, 17);
        //List<EdoCtaBANCO> filtradosEdoCtaBANCO;
        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };
        private RadioButton selectedrb;
        private char[] delimiterChars = { ',' };
        int dia = 0;
        int cifraControlOperaciones = 0;
        decimal cifraControlAcumulado = 0;
        public Form1()
        {
            InitializeComponent();

            List<Archivo> archivos = new List<Archivo>();
            dgvArchivos.DataSource = archivos;
            AparienciadgvArchivos();
            //dgvmain.Columns["Amount"].DefaultCellStyle.Format = "N2";

            List<CorteDia> cortesDia = new List<CorteDia>();
            dgvCortesDia.DataSource = cortesDia;
            AparienciadgvCortesDia();


            List<DescargaATL> soloDescargasATL = new List<DescargaATL>();
            dgvSoloDescargasATL.DataSource = soloDescargasATL;

            dgvSoloDescargasATL.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dgvSoloDescargasATL.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            dgvSoloDescargasATL.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvSoloDescargasATL.Columns[1].DefaultCellStyle.Format = "#,#.00";
            dgvSoloDescargasATL.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvSoloDescargasATL.Columns[2].DefaultCellStyle.Format = "#";
            dgvSoloDescargasATL.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            List<EdoCtaBANCO> soloEdosCtaBANCO = new List<EdoCtaBANCO>();
            dgvSoloEdosCtaBANCO.DataSource = soloEdosCtaBANCO;


            lblCCIDescargaATL.Text = "";
            lblCCNDescargaATL.Text = "";
            lblConIDescargaATL.Text = "";
            lblConIEdoCtaBANCO.Text = "";
            lblConNDescargaATL.Text = "";
            lblConNEdoCtaBANCO.Text = "";
            monthCalendar1.TodayDate = new DateTime(2022, 4, 17);  
            DateTime[] VacationDates = { myVacation1, myVacation2 };
            monthCalendar1.BoldedDates = VacationDates;

            descargasATL = new List<DescargaATL>();
            pictureBox2.Image = Image.FromFile(@"D:\ConciliadorBanco\ConciliadorBanco\flecha-imagen-animada-0182.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile(@"D:\ConciliadorBanco\ConciliadorBanco\flecha-imagen-animada-0182.gif");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = Image.FromFile(@"D:\ConciliadorBanco\ConciliadorBanco\flecha-imagen-animada-0476.gif");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxGruposConceptos.Image = Image.FromFile(@"D:\ConciliadorBanco\ConciliadorBanco\eyes-joypixels.gif");
            pbxGruposConceptos.SizeMode = PictureBoxSizeMode.StretchImage;
            btnGruposConceptos.BackgroundImage= Image.FromFile(@"D:\ConciliadorBanco\ConciliadorBanco\eyes-joypixels.gif");
            btnGruposConceptos.BackgroundImageLayout=ImageLayout.Stretch;
        }

        private void AparienciadgvArchivos()
        {
            dgvArchivos.Width = 520;

            //AllCells - AllCellsExceptHeader - ColumnHeader - DisplayedCells - DisplayedCellsExceptHeader - Fill - None - NotSet
            //dgvArchivos.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dgvArchivos.Columns[0].Width = 70;

            dgvArchivos.Columns[1].Width = 30;
            dgvArchivos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvArchivos.Columns[2].Width = 70;
            dgvArchivos.Columns[2].DefaultCellStyle.Format = "#";
            dgvArchivos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvArchivos.Columns[3].Width = 110;
            dgvArchivos.Columns[3].DefaultCellStyle.Format = "#,#.00";
            dgvArchivos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvArchivos.Columns[4].Width = 70;
            dgvArchivos.Columns[4].DefaultCellStyle.Format = "#";
            dgvArchivos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvArchivos.Columns[5].Width = 110;
            dgvArchivos.Columns[5].DefaultCellStyle.Format = "N2";
            dgvArchivos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            //dgvArchivos.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[2].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[4].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            //dgvArchivos.Columns[5].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;

            //dgvArchivos.Columns[5].CellType
        }
        private void AparienciadgvCortesDia()
        {
            dgvCortesDia.Width = 270;

            //AllCells - AllCellsExceptHeader - ColumnHeader - DisplayedCells - DisplayedCellsExceptHeader - Fill - None - NotSet
            //dgvArchivos.Columns[0].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dgvCortesDia.Columns[0].Width = 30;
            dgvCortesDia.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCortesDia.Columns[1].Width = 70;
            dgvCortesDia.Columns[1].DefaultCellStyle.Format = "#";
            dgvCortesDia.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCortesDia.Columns[2].Width = 110;
            dgvCortesDia.Columns[2].DefaultCellStyle.Format = "#,#.00";
            dgvCortesDia.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtDescargaATL_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void txtDescargaATL_DragDrop(object sender, DragEventArgs e)
        {
            // Obtenemos el arreglo con los archivos
            archivosDescargaATL = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            txtDescargaATL.Text = "Archivo:" + archivosDescargaATL[0];

            CargaDescargaATL();
        }
        private void CargaDescargaATL()
        {
            List<Archivo> archivosCargados = new List<Archivo>();
            string linea = "";

            for (int i = 0; i < archivosDescargaATL.Count(); i++)
            {
                cifraControlOperaciones = 0;
                cifraControlAcumulado = 0;
                //leemos el archivo
                StreamReader lector = File.OpenText(archivosDescargaATL[i]);
                Archivo archivo = new Archivo();
                archivo.Nombre = Path.GetFileName(archivosDescargaATL[i]);


                switch (selectedrb.Text)
                {
                    case "AZTECA":
                        break;
                    case "BANAMEX":
                        break;
                    case "BANCOMER(Sucursales)":
                        archivo.Dia = Convert.ToInt32(archivo.Nombre.Substring(0, 2));
                        break;
                    case "BANCOMER(Multipagos)":
                        archivo.Dia = Convert.ToInt32(archivo.Nombre.Substring(0, 2));
                        break;
                    case "BANCOMER (Domiciliados)":
                        archivo.Dia = Convert.ToInt32(archivo.Nombre.Substring(12, 2));
                        break;
                    case "BANORTE":
                        break;
                    case "IUSA":
                        break;
                    case "QIUBO":
                        break;
                    case "SANTANDER":
                        break;
                    case "SCOTIABANK":
                        break;
                    default:
                        Console.WriteLine(String.Format("Unknown command: {0}", selectedrb.Text));
                        break;
                }


                decimal conIDescargaATL = 0;
                int conNDescargaATL = 0;

                while ((linea = lector.ReadLine()) != null)
                {
                    DescargaATL descargaATL = new DescargaATL();

                    descargaATL=cargaLineaDescargaATL(linea, archivo.Dia);
                    if(descargaATL.Referencia>0 && descargaATL.Importe>0)
                    {
                        conNDescargaATL++;
                        conIDescargaATL = conIDescargaATL + descargaATL.Importe;
                        descargasATL.Add(descargaATL);
                    }
                }

                lblConNDescargaATL.Text = String.Format("{0,6:#}", (conNDescargaATL));
                lblConIDescargaATL.Text = String.Format("{0,10:#,#.00}", conIDescargaATL);

                lector.Close();


                archivo.CCOperaciones = cifraControlOperaciones;
                archivo.CCAcumulado = cifraControlAcumulado;
                archivo.Operaciones = conNDescargaATL;
                archivo.Acumulado = conIDescargaATL;
                archivosCargados.Add(archivo);
            }


            foreach (Archivo archivo in archivosCargados)
            {
                archivos.Add(archivo);
            }
            archivosCargados = archivos;
            archivos = archivosCargados.OrderBy(a => a.Dia).ToList();
            dgvArchivos.DataSource = archivos.ToList();
            AparienciadgvArchivos();


            lblCCNDescargaATL.Text = String.Format("{0,6:#}", (archivos.Sum(a => a.CCOperaciones)));
            lblCCIDescargaATL.Text = String.Format("{0,10:#,#.00}", (archivos.Sum(a => a.CCAcumulado)));
            lblConNDescargaATL.Text = String.Format("{0,6:#}", (archivos.Sum(a => a.Operaciones)));
            lblConIDescargaATL.Text = String.Format("{0,10:#,#.00}", (archivos.Sum(a => a.Acumulado)));

            lblDifOperaciones.Text= String.Format("{0,10:#,#.00}", (archivos.Sum(a => a.CCOperaciones) - cortesDia.Sum(c => c.Operaciones)));
            lblDifAcumulado.Text= String.Format("{0,10:#,#.00}", (archivos.Sum(a => a.CCAcumulado))- cortesDia.Sum(c => c.Acumulado));
        }
        private DescargaATL cargaLineaDescargaATL(string linea, int Dia)
        {
            DescargaATL descargaATL = new DescargaATL();
            char[] delimiterChars = { '|' };
            string[] fila = { "1111", "2222" };
            //ultimaLinea = linea;
            switch (selectedrb.Text)
            {
                case "AZTECA":
                    descargaATL.Referencia = Convert.ToInt32(linea.Substring(188, 9));
                    descargaATL.Importe = Convert.ToDecimal(linea.Substring(423, 10) + linea.Substring(434, 2)) / 100;
                    descargaATL.Dia = Dia;
                    break;
                case "BANAMEX":
                    if (linea.Substring(0, 1) == "0")
                    {

                    }
                    else if (linea.Substring(0, 1) == "9")
                    {
                        //ultimaLinea = linea;
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(58, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(7, 15)) / 100;
                    }
                    else
                    {
                        descargaATL.Referencia = Convert.ToInt32(linea.Substring(58, 9));
                        descargaATL.Importe = Convert.ToDecimal(linea.Substring(7, 15)) / 100;
                        descargaATL.Dia = Dia;
                    }
                    break;
                case "BANCOMER(Sucursales)":
                    if (linea.Substring(0, 1) == "0")
                    {
                        descargaATL.Referencia = Convert.ToInt32(linea.Substring(19, 8));
                        descargaATL.Importe = Convert.ToDecimal(linea.Substring(89, 13) + linea.Substring(103, 2)) / 100;
                        descargaATL.Dia = Dia;
                    }
                    else if (linea.Substring(0, 19) == "TOTAL TRANSACCIONES")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(26, 16));
                    }
                    else if (linea.Substring(0, 13) == "TOTAL ABONADO")
                    {
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(26, 13) + linea.Substring(40, 2)) / 100;
                    }
                    break;
                case "BANCOMER(Multipagos)":
                    descargaATL.Referencia = Convert.ToInt32(linea.Substring(127, 9));
                    descargaATL.Importe = Convert.ToDecimal(linea.Substring(245, 10) + linea.Substring(256, 2)) / 100;
                    descargaATL.Dia = Dia;
                    break;
                case "BANCOMER (Domiciliados)":
                    if (linea.Substring(0, 2) == "02" && linea.Substring(277, 2) == "00")
                    {
                        descargaATL.Referencia = Convert.ToInt32(linea.Substring(260, 8));
                        descargaATL.Importe = Convert.ToDecimal(linea.Substring(13, 15)) / 100;
                        descargaATL.Dia = Dia;
                    }
                    else if (linea.Substring(0, 2) == "09")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(2, 7));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(25, 18)) / 100;
                    }
                    else if (linea.Substring(0, 2) == "01")
                    {

                    }
                    break;
                case "BANORTE":
                    if (linea.Substring(0, 1) == "0")
                    {
                    }
                    else if (linea.Substring(0, 1) == "4")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(2, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(11, 17)) / 100;
                    }
                    else
                    {
                        descargaATL.Referencia = Convert.ToInt32(linea.Substring(65, 8));
                        descargaATL.Importe = Convert.ToDecimal(linea.Substring(49, 14)) / 100;
                        descargaATL.Dia = Dia;
                    }
                    break;
                case "IUSA":
                    delimiterChars = new char[] { ',' };
                    fila = linea.Split(delimiterChars);
                    descargaATL.Referencia = Convert.ToInt32(linea.Substring(19, 8));
                    descargaATL.Importe = Convert.ToDecimal(linea.Substring(89, 13) + linea.Substring(103, 2)) / 100;
                    descargaATL.Dia = Dia;

                    descargaATL.Referencia = Convert.ToInt32(fila[9].Substring(12, 8));
                    descargaATL.Importe = Convert.ToDecimal(fila[6]);
                    descargaATL.Dia = Dia;
                    break;
                case "QIUBO":
                    delimiterChars = new char[] { '|' };
                    if (linea.Substring(0, 1) == "0")
                    {
                        fila = linea.Split(delimiterChars);
                        descargaATL.Referencia = Convert.ToInt32(fila[2]);
                        descargaATL.Importe = Convert.ToDecimal(fila[3]);
                        descargaATL.Dia = Dia;
                    }
                    break;
                case "SANTANDER":
                    descargaATL.Referencia = Convert.ToInt32(linea.Substring(121, 8));
                    descargaATL.Importe = Convert.ToDecimal(linea.Substring(73, 14)) / 100;
                    descargaATL.Dia = Dia;
                    break;
                case "SCOTIABANK":
                    delimiterChars = new char[] { '|' };
                    if (linea.Substring(0, 1) == "H")
                    {
                    }
                    else if (linea.Substring(0, 1) == "T")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(1, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(10, 17)) / 100;
                    }
                    else
                    {
                        fila = linea.Split(delimiterChars);
                        descargaATL.Referencia = Convert.ToInt32(fila[1].Substring(11, 9));
                        descargaATL.Importe = Convert.ToDecimal(fila[0].Substring(24, 12)) / 100;
                        descargaATL.Dia = Dia;
                    }
                    break;
                default:
                    Console.WriteLine(String.Format("Unknown command: {0}", selectedrb.Text));
                    break;
            }
            return descargaATL;
        }

        private void CargaEdoCtaBANCO()
        {
            List<CorteDia> cortesDiaCargados = new List<CorteDia>();
            string linea = "";
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            //for (int i = 0; i < archivosEdoCtaBANCO.Count(); i++)
            //{

            //}

            //leemos el archivo
            StreamReader lector = File.OpenText(archivosEdoCtaBANCO[0]);

            int lineaActual = 0;
            decimal conIEdoCtaBANCO = 0;
            int conNEdoCtaBANCO = 0;

            while ((linea = lector.ReadLine()) != null)
            {
                EdoCtaBANCO edoCtaBANCO = new EdoCtaBANCO();

                edoCtaBANCO = cargaLineaEdoCtaBANCO(linea);
                if (edoCtaBANCO != null)
                {
                    conNEdoCtaBANCO++;
                    conIEdoCtaBANCO = conIEdoCtaBANCO + edoCtaBANCO.Importe;
                    edosCtaBANCO.Add(edoCtaBANCO);
                }
            }
            switch (selectedrb.Text)
            {
                case "AZTECA":
                    break;
                case "BANAMEX":
                    break;
                case "BANCOMER(Sucursales)":
                    
                    cortesDiaCargados = (from estado in edosCtaBANCO
                                                 where estado.Clave == "2199" || estado.Clave == "2299" || estado.Clave == "2399" || estado.Clave == "2499" || estado.Clave == "2799"
                                         //2199 = Aviso de pago, 2299 = Reposiciòn 2399 = Presupuesto 2499 = Pagare 2799 = Referencia de pago, uno o varios periodos
                                         group estado by estado.Dia into g
                                             select new CorteDia
                                             {
                                                 Operaciones = g.Count(),
                                                 Dia = g.Key,
                                                 Acumulado = g.Sum(e => e.Importe)
                                             }).ToList();
                    break;
                case "BANCOMER(Multipagos)":
                    cortesDiaCargados = (from estado in edosCtaBANCO
                                         where estado.Clave == "W02"
                                         //W02 Aplicación a Estado de Cuenta ABONO MISMA PLAZA VIA CW
                                         group estado by estado.Dia into g
                                         select new CorteDia
                                         {
                                             Operaciones = g.Count(),
                                             Dia = g.Key,
                                             Acumulado = g.Sum(e => e.Importe)
                                         }).ToList();
                    break;
                case "BANCOMER (Domiciliados)":
                    cortesDiaCargados = (from estado in edosCtaBANCO
                                         where estado.Clave == "P17"
                                         //P17 Aplicación a Estado de Cuenta LIQUIDACION DE COBRANZA
                                         group estado by estado.Dia into g
                                         select new CorteDia
                                         {
                                             Operaciones = g.Count(),
                                             Dia = g.Key,
                                             Acumulado = g.Sum(e => e.Importe)
                                         }).ToList();
                    break;
                case "BANORTE":
                    break;
                case "IUSA":
                    break;
                case "QIUBO":
                    break;
                case "SANTANDER":
                    break;
                case "SCOTIABANK":
                    break;
                default:
                    Console.WriteLine(String.Format("Unknown command: {0}", selectedrb.Text));
                    break;
            }

            foreach (CorteDia corteDia in cortesDiaCargados)
            {
                cortesDia.Add(corteDia);
            }
            cortesDiaCargados = cortesDia;
            cortesDia = cortesDiaCargados.OrderBy(c => c.Dia).ToList();

            dgvCortesDia.DataSource = cortesDia.ToList();
            AparienciadgvCortesDia();

            lblConNEdoCtaBANCO.Text = String.Format("{0,6:#}", (cortesDia.Sum(c => c.Operaciones)));
            lblConIEdoCtaBANCO.Text = String.Format("{0,10:#,#.00}", (cortesDia.Sum(c => c.Acumulado)));



            lector.Close();

            lblDifOperaciones.Text = String.Format("{0,6:#,#}", (archivos.Sum(a => a.CCOperaciones) - cortesDia.Sum(c => c.Operaciones)));
            lblDifAcumulado.Text = String.Format("{0,10:#,#.00}", (archivos.Sum(a => a.CCAcumulado)) - cortesDia.Sum(c => c.Acumulado));

            var depositos = (from estado in edosCtaBANCO
                             where estado.Movimiento==0
                             select estado).ToList();

            lblDepositos.Text = String.Format("{0,10:#,#.00}", (depositos.Sum(e => e.Importe)));

            var retiros = (from estado in edosCtaBANCO
                             where estado.Movimiento == 1
                             select estado).ToList();

            lblRetiros.Text = String.Format("{0,10:#,#.00}", (retiros.Sum(e => e.Importe)));
        }
        private EdoCtaBANCO cargaLineaEdoCtaBANCO(string linea)
        {
            EdoCtaBANCO edoCtaBANCO = new EdoCtaBANCO();
            switch (selectedrb.Text)
            {
                case "AZTECA":
                    break;
                case "BANAMEX":
                    break;
                case "BANCOMER(Sucursales)":
                break;
                case "BANCOMER(Multipagos)":
                    break;
                case "BANCOMER (Domiciliados)":
                    break;
                case "BANORTE":
                    break;
                case "IUSA":
                    break;
                case "QIUBO":
                    break;
                case "SANTANDER":
                    char[] delimiterChars = { ',' };
                    break;
                case "SCOTIABANK":
                    break;
                default:
                    Console.WriteLine(String.Format("Unknown command: {0}", selectedrb.Text));
                    break;
            }


            string[] fila = { "1111", "2222" };
            switch (selectedrb.Text)
            {
                case "AZTECA":
                    //descargaATL.Referencia = Convert.ToInt32(linea.Substring(188, 9));
                    //descargaATL.Importe = Convert.ToDecimal(linea.Substring(423, 10) + linea.Substring(434, 2)) / 100;
                    break;
                case "BANAMEX":
                    if (linea.Substring(0, 1) == "0")
                    {

                    }
                    else if (linea.Substring(0, 1) == "9")
                    {
                        //ultimaLinea = linea;
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(58, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(7, 15)) / 100;
                    }
                    else
                    {
                        //descargaATL.Referencia = Convert.ToInt32(linea.Substring(58, 9));
                        //descargaATL.Importe = Convert.ToDecimal(linea.Substring(7, 15)) / 100;
                    }
                    break;
                case "BANCOMER(Sucursales)":
                    //if (linea.Substring(42, 4) == "2199" || linea.Substring(42, 4) == "2299" || linea.Substring(42, 4) == "2399" || linea.Substring(42, 4) == "2499" || linea.Substring(42, 4) == "2799")
                    //    //2199=Aviso de pago, 2299=Reposiciòn 2399=Presupuesto 2499=Pagare 2799=Referencia de pago, uno o varios periodos
                    //{
                    //    edoCtaBANCO.Referencia = Convert.ToInt32(linea.Substring(53, 9));
                    //    edoCtaBANCO.Importe = Convert.ToDecimal(linea.Substring(64, 14) + linea.Substring(79, 2)) / 100;
                    //    edoCtaBANCO.Descripcion = Convert.ToString(linea.Substring(34, 30));
                    //    edoCtaBANCO.Dia= Convert.ToInt32(linea.Substring(26, 2));
                    //    edoCtaBANCO.Clave = linea.Substring(42, 4);
                    //}

                    //break;
                case "BANCOMER(Multipagos)":
                    //if (linea.Substring(152, 3) == "W02")
                    ////W02 Aplicación a Estado de Cuenta ABONO MISMA PLAZA VIA CW
                    //{
                    //    edoCtaBANCO.Referencia = 0;// Convert.ToInt32(linea.Substring(53, 9));
                    //    edoCtaBANCO.Importe = Convert.ToDecimal(linea.Substring(64, 14) + linea.Substring(79, 2)) / 100;
                    //    edoCtaBANCO.Descripcion = Convert.ToString(linea.Substring(34, 30));
                    //    edoCtaBANCO.Dia = Convert.ToInt32(linea.Substring(26, 2));
                    //}
                    //break;
                case "BANCOMER (Domiciliados)":
                    //if (linea.Substring(152, 3) == "P17")
                    ////P17 Aplicación a Estado de Cuenta LIQUIDACION DE COBRANZA
                    //{
                    //    edoCtaBANCO.Referencia = 0;// Convert.ToInt32(linea.Substring(53, 9));
                    //    edoCtaBANCO.Importe = Convert.ToDecimal(linea.Substring(64, 14) + linea.Substring(79, 2)) / 100;
                    //    edoCtaBANCO.Descripcion = Convert.ToString(linea.Substring(34, 30));
                    //    edoCtaBANCO.Dia = Convert.ToInt32(linea.Substring(26, 2));
                    //}
                    if (linea.Substring(42, 4) == "2199" || linea.Substring(42, 4) == "2299" || linea.Substring(42, 4) == "2399" || linea.Substring(42, 4) == "2499" || linea.Substring(42, 4) == "2799")
                    {
                        edoCtaBANCO.Referencia = Convert.ToInt32(linea.Substring(53, 9));
                        edoCtaBANCO.Descripcion = "PAGOS REFERENCIADOS";
                        edoCtaBANCO.Clave = linea.Substring(42, 4);
                    } else
                    {
                        edoCtaBANCO.Descripcion = Convert.ToString(linea.Substring(34, 30));
                        edoCtaBANCO.Referencia = 0;
                        edoCtaBANCO.Clave = linea.Substring(152, 3);
                    }
                        
                    edoCtaBANCO.Importe = Convert.ToDecimal(linea.Substring(65, 13) + linea.Substring(79, 2)) / 100;

                    edoCtaBANCO.Dia = Convert.ToInt32(linea.Substring(26, 2));

                    edoCtaBANCO.Movimiento = Convert.ToInt32(linea.Substring(64, 1));
                    break;
                case "BANORTE":
                    if (linea.Substring(0, 1) == "0")
                    {
                    }
                    else if (linea.Substring(0, 1) == "4")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(2, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(11, 17)) / 100;
                    }
                    else
                    {
                        //descargaATL.Referencia = Convert.ToInt32(linea.Substring(65, 8));
                        //descargaATL.Importe = Convert.ToDecimal(linea.Substring(49, 14)) / 100;
                    }
                    break;
                case "IUSA":
                    delimiterChars = new char[] { ',' };
                    fila = linea.Split(delimiterChars);
                    //descargaATL.Referencia = Convert.ToInt32(linea.Substring(19, 8));
                    //descargaATL.Importe = Convert.ToDecimal(linea.Substring(89, 13) + linea.Substring(103, 2)) / 100;

                    //descargaATL.Referencia = Convert.ToInt32(fila[9].Substring(12, 8));
                    //descargaATL.Importe = Convert.ToDecimal(fila[6]);
                    break;
                case "QIUBO":
                    delimiterChars = new char[] { '|' };
                    if (linea.Substring(0, 1) == "0")
                    {
                        fila = linea.Split(delimiterChars);
                        //descargaATL.Referencia = Convert.ToInt32(fila[2]);
                        //descargaATL.Importe = Convert.ToDecimal(fila[3]);
                    }
                    break;
                case "SANTANDER":
                    fila = linea.Split(delimiterChars);

                    if (linea.Substring(0, 5) == "Fecha")
                    {

                    }
                    else
                    {
                        //SumarATabla(fila[9], Convert.ToDecimal(fila[6]));
                        if (fila[9].Substring(0, 4) == "2199" || fila[9].Substring(0, 4) == "2799")
                        {
                            edoCtaBANCO.Referencia = Convert.ToInt32(fila[9].Substring(12, 8));
                            edoCtaBANCO.Importe = Convert.ToDecimal(fila[6]);
                            edoCtaBANCO.Descripcion = fila[4];
                        }
                        else
                        {

                            edoCtaBANCO.Referencia = 0;
                            edoCtaBANCO.Importe = Convert.ToDecimal(fila[6]);
                            edoCtaBANCO.Descripcion = fila[4];

                            edosCtaBANCO.Add(edoCtaBANCO);
                        }
                    }
                    break;
                case "SCOTIABANK":
                    delimiterChars = new char[] { '|' };
                    if (linea.Substring(0, 1) == "H")
                    {
                    }
                    else if (linea.Substring(0, 1) == "T")
                    {
                        cifraControlOperaciones = Convert.ToInt32(linea.Substring(1, 9));
                        cifraControlAcumulado = Convert.ToDecimal(linea.Substring(10, 17)) / 100;
                    }
                    else
                    {
                        fila = linea.Split(delimiterChars);
                        //descargaATL.Referencia = Convert.ToInt32(fila[1].Substring(11, 9));
                        //descargaATL.Importe = Convert.ToDecimal(fila[0].Substring(24, 12)) / 100;
                    }
                    break;
                default:
                    Console.WriteLine(String.Format("Unknown command: {0}", selectedrb.Text));
                    break;
            }
            return edoCtaBANCO;
        }
        void bancosRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                selectedrb = rb;
                txtDescargaATL.Enabled = true;
                txtEdoCtaBANCO.Enabled = true;
                txtDescargaATL.Focus();
            }
        }
        private void txtEstadoCuentaBANCO_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void txtEstadoCuentaBANCO_DragDrop(object sender, DragEventArgs e)
        {
            // Obtenemos el arreglo con los archivos
            archivosEdoCtaBANCO = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            txtEdoCtaBANCO.Text = "Archivo:" + archivosEdoCtaBANCO[0];

            edosCtaBANCO = new List<EdoCtaBANCO>();

            CargaEdoCtaBANCO();
            
        }

        private void btnConciliar_Click(object sender, EventArgs e)
        {
            List<int> des= descargasATL.Select(d => d.Referencia).ToList();
            List<int> edo = edosCtaBANCO.Where(b => b.Clave == "2199" || b.Clave == "2299" || b.Clave == "2399" || b.Clave == "2499" || b.Clave == "2799").Select(b => b.Referencia).ToList();

            IEnumerable<int> noEnEdoCtaQuery =  des.Except(edo);

            foreach (int d in noEnEdoCtaQuery)
            {
                DescargaATL result = descargasATL.Find(delegate (DescargaATL bk)
                {
                    return bk.Referencia == d;
                }
                );
                if (result != null)
                {
                    soloDescargasATL.Add(result);
                }
                else
                {
                }
            }

            dgvSoloDescargasATL.DataSource=soloDescargasATL;

            lblSoloDescargaOperaciones.Text= String.Format("{0,6:#}", (soloDescargasATL.Count()));
            lblSoloDescargaAcumulado.Text = String.Format("{0,10:#,#.00}", (soloDescargasATL.Sum(s => s.Importe)));

            IEnumerable<int> noEnDescargaATLQuery = edo.Except(des);

            foreach (int d in noEnDescargaATLQuery)
            {
                EdoCtaBANCO result = edosCtaBANCO.Find(delegate (EdoCtaBANCO bk)
                {
                    return bk.Referencia == d;
                }
                );
                if (result != null)
                {
                    soloEdosCtaBANCO.Add(result);
                }
                else
                {
                }
            }

            dgvSoloEdosCtaBANCO.DataSource = soloEdosCtaBANCO;

            lblSoloEdoCtaOperaciones.Text = String.Format("{0,6:#}", (soloEdosCtaBANCO.Count()));
            lblSoloEdoCtaAcumulado.Text = String.Format("{0,10:#,#.00}", (soloEdosCtaBANCO.Sum(s => s.Importe)));

            var results = from ds in descargasATL
                         join eb in edosCtaBANCO
                         on ds.Referencia equals eb.Referencia
                         where ds.Importe != eb.Importe || ds.Dia!= eb.Dia
                         select new Diferencia
                         {
                             Referencia = ds.Referencia,
                             Descarga = ds.Importe,
                             EdoCta = eb.Importe,
                             DiaDescarga= ds.Dia,
                             DiaEdoCta= eb.Dia
                         };

            foreach (Diferencia difer in results)
            {
                Diferencia diferencia = new Diferencia();
                diferencia = difer;
                diferentes.Add(diferencia);
            }
            dgvDiferencias.DataSource = diferentes;

            lblConDiferenciasOperaciones.Text = String.Format("{0,6:#}", (diferentes.Count()));
            lblConDiferenciasAcumulado.Text = String.Format("{0,10:#,#.00}", (diferentes.Sum(s => s.Descarga)));
            //IEnumerable<DescargaATL> descargaQuery =
            //    from descarga in descargasATL
            //    where descarga.Referencia > 0
            //    select descarga;

            //foreach (DescargaATL descarga in descargaQuery)
            //{
            //    Console.WriteLine("{0}, {1}", descarga.Referencia, descarga.Importe);
            //}

            //var referenciasEdoCtaBANCO = edosCtaBANCO.Select(b => b.Referencia).ToList();
            //foreach (Product fruit in except)
            //soloDescargasATL = descargasATL.Where(d => !referenciasEdoCtaBANCO.Contains(d.Referencia)).ToList();

        }

        private void dgvCortesDia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var edos = from edo in edosCtaBANCO
                       where edo.Dia == (int)dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value && edo.Movimiento == 0 && 
                       (edo.Clave == "2199" || edo.Clave == "2299" || edo.Clave == "2399" || edo.Clave == "2499" || edo.Clave == "2799")
                       orderby edo.Referencia
                       select edo;

            FrmDetalle frmDetalle=new FrmDetalle();
            frmDetalle.contenido = 0;
            frmDetalle.filtradosEdoCtaBANCO = edos.ToList();
            frmDetalle.Text = "Estado de Cuenta del dia:" + dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value.ToString();
            frmDetalle.FormClosed += formDetalle_FormClosed;
            frmDetalle.Opener = this;
            frmDetalle.WindowState = FormWindowState.Normal;
  
    
            frmDetalle.ShowDialog();
        }
        void formDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargaDestinatarios((int)dgvDocumentos.Rows[dgvDocumentos.CurrentRow.Index].Cells[0].Value);
            //CargaDestinatarios(int.Parse(txtDocumentoId.Text));
        }
        private void selectedCellsButton_Click(object sender, System.EventArgs e)
        {
            Int32 selectedCellCount =
                dgvArchivos.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (dgvArchivos.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0;
                        i < selectedCellCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(dgvArchivos.SelectedCells[i].RowIndex
                            .ToString());
                        sb.Append(", Column: ");
                        sb.Append(dgvArchivos.SelectedCells[i].ColumnIndex
                            .ToString());
                        sb.Append(Environment.NewLine);
                    }

                    sb.Append("Total: " + selectedCellCount.ToString());
                    MessageBox.Show(sb.ToString(), "Selected Cells");
                }
            }
        }

        private void dgvArchivos_MouseUp(object sender, MouseEventArgs e)
        {
            decimal conIDescargaATL = 0;
            int conNDescargaATL = 0;
            decimal conCCIDescargaATL = 0;
            int conCCNDescargaATL = 0;
            Int32 selectedRowCount =
                dgvArchivos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //Customer cust = row.DataBoundItem as Customer



                //System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    Archivo archivo = dgvArchivos.SelectedRows[i].DataBoundItem as Archivo;
                    conNDescargaATL = conNDescargaATL + archivo.Operaciones;
                    conIDescargaATL= conIDescargaATL + archivo.Acumulado;
                    conCCNDescargaATL = conCCNDescargaATL + archivo.CCOperaciones;
                    conCCIDescargaATL = conCCIDescargaATL + archivo.CCAcumulado;

                    //sb.Append("Row: ");
                    //sb.Append(dgvArchivos.SelectedRows[i].Index.ToString());
                    //sb.Append(Environment.NewLine);
                }

                //sb.Append("Total: " + selectedRowCount.ToString());
                //MessageBox.Show(sb.ToString(), "Selected Rows");
                lblConNDescargaATL.Text = String.Format("{0,6:#}", (conNDescargaATL));
                lblConIDescargaATL.Text = String.Format("{0,10:#,#.00}", conIDescargaATL);
                lblCCNDescargaATL.Text = String.Format("{0,6:#}", (conCCNDescargaATL));
                lblCCIDescargaATL.Text = String.Format("{0,10:#,#.00}", conCCIDescargaATL);
            }
            AjustaDiferencias();
        }

        private void dgvCortesDia_MouseUp(object sender, MouseEventArgs e)
        {
            decimal conIEdoCtaBANCO = 0;
            int conNEdoCtaBANCO = 0;
            Int32 selectedRowCount =
                dgvCortesDia.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //Customer cust = row.DataBoundItem as Customer



                //System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    CorteDia corteDia = dgvCortesDia.SelectedRows[i].DataBoundItem as CorteDia;
                    conNEdoCtaBANCO = conNEdoCtaBANCO + corteDia.Operaciones;
                    conIEdoCtaBANCO = conIEdoCtaBANCO + corteDia.Acumulado;

                    //sb.Append("Row: ");
                    //sb.Append(dgvArchivos.SelectedRows[i].Index.ToString());
                    //sb.Append(Environment.NewLine);
                }

                //sb.Append("Total: " + selectedRowCount.ToString());
                //MessageBox.Show(sb.ToString(), "Selected Rows");
                lblConNEdoCtaBANCO.Text = String.Format("{0,6:#}", conNEdoCtaBANCO);
                lblConIEdoCtaBANCO.Text = String.Format("{0,10:#,#.00}", conIEdoCtaBANCO);
            }
            AjustaDiferencias();
        }
        private void AjustaDiferencias()
        {
            decimal conIEdoCtaBANCO = 0;
            int conNEdoCtaBANCO = 0;
            Int32 selectedRowCountEdoCta =
                dgvCortesDia.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCountEdoCta > 0)
            {
                for (int i = 0; i < selectedRowCountEdoCta; i++)
                {
                    CorteDia corteDia = dgvCortesDia.SelectedRows[i].DataBoundItem as CorteDia;
                    conNEdoCtaBANCO = conNEdoCtaBANCO + corteDia.Operaciones;
                    conIEdoCtaBANCO = conIEdoCtaBANCO + corteDia.Acumulado;
                }
            }

            decimal conIDescargaATL = 0;
            int conNDescargaATL = 0;
            Int32 selectedRowCountDescarga =
                dgvArchivos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCountDescarga > 0)
            {
                for (int i = 0; i < selectedRowCountDescarga; i++)
                {
                    Archivo archivo = dgvArchivos.SelectedRows[i].DataBoundItem as Archivo;
                    conNDescargaATL = conNDescargaATL + archivo.Operaciones;
                    conIDescargaATL = conIDescargaATL + archivo.Acumulado;
                }
            }

            lblDifOperaciones.Text = (conNEdoCtaBANCO - conNDescargaATL).ToString();
            lblDifAcumulado.Text = (conIEdoCtaBANCO - conIDescargaATL).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescargaATL.Text = "";
            txtEdoCtaBANCO.Text = "";
            archivos.Clear();
            dgvArchivos.DataSource = null;
            dgvArchivos.Refresh();
            cortesDia.Clear();
            soloDescargasATL.Clear();
            soloEdosCtaBANCO.Clear();
            dgvCortesDia.DataSource = null;
            dgvCortesDia.Refresh();
            txtDescargaATL.Enabled = false;
            txtEdoCtaBANCO.Enabled = false;
            lblCCNDescargaATL.Text = "0";
            lblCCIDescargaATL.Text = "0";
            lblConIDescargaATL.Text = "0";
            lblConNDescargaATL.Text = "0";
            lblConIEdoCtaBANCO.Text = "0";
            lblConNEdoCtaBANCO.Text = "0";
            lblDifAcumulado.Text = "0";
            lblDifOperaciones.Text = "0";
            lblDepositos.Text = "0";
            lblRetiros.Text = "0";
            lblSoloDescargaAcumulado.Text = "0";
            lblSoloDescargaOperaciones.Text="0";
            lblSoloEdoCtaAcumulado.Text = "0";
            lblSoloEdoCtaOperaciones.Text = "0";
            lblConDiferenciasAcumulado.Text = "0";
            lblConDiferenciasOperaciones.Text = "0";
        }

        private void dgvArchivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var descs = from desc in descargasATL
                        where desc.Dia == (int)dgvArchivos.Rows[dgvArchivos.CurrentRow.Index].Cells[1].Value
                        orderby desc.Referencia
                        select desc;

            FrmDetalle frmDetalle = new FrmDetalle();
            frmDetalle.contenido = 1;
            frmDetalle.filtradosDescargaATL = descs.ToList();
            frmDetalle.Text = "Archivo:" + dgvArchivos.Rows[dgvArchivos.CurrentRow.Index].Cells[0].Value.ToString();
            frmDetalle.FormClosed += formDetalle_FormClosed;
            frmDetalle.Opener = this;
            frmDetalle.WindowState = FormWindowState.Normal;


            frmDetalle.ShowDialog();
        }

        private void btnGruposConceptos_Click(object sender, EventArgs e)
        {
            var gruposConcepto = (from estado in edosCtaBANCO
                                  where estado.Movimiento == 0// && (estado.Descripcion.Trim() == "ABONO MISMA PLAZA VIA CW" || estado.Descripcion.Trim() == "PAGOS REFERENCIADOS" || estado.Descripcion.Trim() == "LIQUIDACION DE COBRANZA" || estado.Descripcion.Trim() == "INTERESES MES ANTERIOR" || estado.Descripcion.Trim().Contains("VENTAS"))
                                  group estado by estado.Descripcion into g
                                  select new GrupoConcepto
                                  {
                                      Operaciones = g.Count(),
                                      Descripcion = g.Key,
                                      Acumulado = g.Sum(e => e.Importe)
                                  }).ToList();

            FrmGruposConcepto frmGruposConcepto = new FrmGruposConcepto();
            frmGruposConcepto.filtradosEdoCtaBANCO = gruposConcepto.ToList();
            frmGruposConcepto.Text = "Agrupación depositos X Concepto  del dia:" + dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value.ToString();
            frmGruposConcepto.FormClosed += frmGruposConcepto_FormClosed;
            frmGruposConcepto.Opener = this;
            frmGruposConcepto.WindowState = FormWindowState.Normal;


            frmGruposConcepto.ShowDialog();
        }
        void frmGruposConcepto_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CargaDestinatarios((int)dgvDocumentos.Rows[dgvDocumentos.CurrentRow.Index].Cells[0].Value);
            //CargaDestinatarios(int.Parse(txtDocumentoId.Text));
        }

        private void pbxGruposConceptos_Click(object sender, EventArgs e)
        {
            var gruposConcepto = (from estado in edosCtaBANCO
                                  where estado.Movimiento == 0// && (estado.Descripcion.Trim() == "ABONO MISMA PLAZA VIA CW" || estado.Descripcion.Trim() == "PAGOS REFERENCIADOS" || estado.Descripcion.Trim() == "LIQUIDACION DE COBRANZA" || estado.Descripcion.Trim() == "INTERESES MES ANTERIOR" || estado.Descripcion.Trim().Contains("VENTAS"))
                                  group estado by estado.Descripcion into g
                                  select new GrupoConcepto
                                  {
                                      Operaciones = g.Count(),
                                      Descripcion = g.Key,
                                      Acumulado = g.Sum(e => e.Importe)
                                  }).ToList();

            FrmGruposConcepto frmGruposConcepto = new FrmGruposConcepto();
            frmGruposConcepto.filtradosEdoCtaBANCO = gruposConcepto.ToList();
            frmGruposConcepto.Text = "Agrupación depositos X Concepto  del dia:" + dgvCortesDia.Rows[dgvCortesDia.CurrentRow.Index].Cells[0].Value.ToString();
            frmGruposConcepto.FormClosed += frmGruposConcepto_FormClosed;
            frmGruposConcepto.Opener = this;
            frmGruposConcepto.WindowState = FormWindowState.Normal;


            frmGruposConcepto.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();

        }

        private void dgvSoloEdosCtaBANCO_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvSoloDescargasATL_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvDiferencias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
    public class Diferencia
    {
        public int Referencia { get; set; }
        public decimal Descarga { get; set; }
        public decimal EdoCta { get; set; }
        public int DiaDescarga { get; set; }
        public int DiaEdoCta { get; set; }
    }
    public class GrupoConcepto
    {
        public string Descripcion { get; set; }
        public int Operaciones { get; set; }
        public decimal Acumulado { get; set; }
    }
    public class Archivo
    {
        public string Nombre  { get; set; }
        public int Dia { get; set; }
        public int CCOperaciones { get; set; }
        public decimal CCAcumulado { get; set; }
        public int Operaciones { get; set; }
        public decimal Acumulado { get; set; }
    }
    public class CorteDia
    {
        public int Dia { get; set; }
        public int Operaciones { get; set; }
        public decimal Acumulado { get; set; }
    }
    class Person
    {
        public int PersonId;
        public string car;
    }

    class Result
    {
        public int PersonId;
        public List<string> Cars;
    }

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

}
