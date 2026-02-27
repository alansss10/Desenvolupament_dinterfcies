// Emgu CV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using PdfSharp.Drawing;
// PDF
using PdfSharp.Pdf;
using PdfSharp; // Aquí és on resideix GlobalFontSettings
using PdfSharp.Fonts; // Necessari per a IFontResolver
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing; // <--- IMPRESCINDIBLE per a fer servir Bitmaps

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace TriatgePeces
{
    public partial class frmTriatge1 : Form
    {
        // Variables globals
        private Mat? _imatgeActual;
        private List<Peca> _llistaPeces = new List<Peca>();

        public frmTriatge1()
        {
            if (GlobalFontSettings.FontResolver == null)
            {
                GlobalFontSettings.FontResolver = new WindowsFontResolver();
            }

            InitializeComponent();
        }
        private void btnCarregar1_Click(object sender, EventArgs e)
        {
            if (ofdObrir1.ShowDialog() == DialogResult.OK)
            {
                _imatgeActual = CvInvoke.Imread(ofdObrir1.FileName);
                pbImatge1.Image = _imatgeActual.ToBitmap();
            }
        }
        // --- BLOC 1: VISIÓ ---
        private void btnGris1_Click(object sender, EventArgs e)
        {
           if (_imatgeActual == null) return;
          //  Mat gris = new Mat();

            // EXAMEN INICI: Implementeu la invocació per a  convertir la _imatgeActual a Mat gris = new Mat();
            if (_imatgeActual.IsEmpty)
            {
                // avisa al usuario 
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            Mat imatgeGris = new Mat();
            CvInvoke.CvtColor(_imatgeActual, imatgeGris, ColorConversion.Bgr2Gray);
            _imatgeActual = imatgeGris;
            pbImatge1.Image = _imatgeActual.ToBitmap();
            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge grisa (gris) al visor
           // ActualitzarVisor(gris);
        }

        private void btnSuavitzat1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null) return;
           // Mat suavitzat = new Mat();

            // EXAMEN INICI: Implementeu la invocació per a  convertir la _imatgeActual a Mat suavitzat = new Mat();
            if (_imatgeActual.IsEmpty)
            {
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            Mat imatgeSuavitzada = new Mat();
            CvInvoke.GaussianBlur(_imatgeActual, imatgeSuavitzada, new Size(5, 5), 0);
            _imatgeActual = imatgeSuavitzada;
            pbImatge1.Image = _imatgeActual.ToBitmap();

            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge suavitzada (suavitzat) al visor
            // ActualitzarVisor(suavitzat);
        }

        private void btnSegmentacio1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null) return;
            // Mat binaria = new Mat();

            // EXAMEN INICI: Implementeu la invocació Threshold per a segmentar la _imatgeActual a Mat binaria = new Mat();
            if (_imatgeActual.IsEmpty)
            {
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            Mat imatgeBinaritzada = new Mat();
            CvInvoke.Threshold(_imatgeActual, imatgeBinaritzada, 100, 255, ThresholdType.BinaryInv);
            _imatgeActual = imatgeBinaritzada;
            pbImatge1.Image = _imatgeActual.ToBitmap();

            // EXAMEN FI

            // Aquí ja teniu l'enviament de la vostra imatge segmentada (binaria) al visor
            //ActualitzarVisor(binaria);
        }

        private void btnContorn1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual == null)
            {
                MessageBox.Show("Heu de carregar una imatge primer.");
                return;
            }

            // Treballem sobre una còpia per no perdre la imatge original neta si cal
            Mat imatgeColor = _imatgeActual.Clone();

            // Suposem que la imatge actual ja ha estat processada (Gris -> Suavitzat -> Threshold)
            // Si no, caldria fer el processament aquí abans de FindContours
            using (VectorOfVectorOfPoint contorns = new VectorOfVectorOfPoint())
            {
                Mat jerarquia = new Mat();

                // EXAMEN INICI: Invoca la llibreria per a trobar els contorns de la figura
                CvInvoke.FindContours(_imatgeActual, contorns, jerarquia, RetrType.External, ChainApproxMethod.ChainApproxSimple);


                // EXAMEN FI

                for (int i = 0; i < contorns.Size; i++)
                {
                    // Filtre d'àrea per evitar soroll (ajustable segons la foto)
                    VectorOfPoint contorn = contorns[i];
                    double area = CvInvoke.ContourArea(contorn);
                    if (area < 500) continue;

                    // 1. Aproximació de polígons per comptar vèrtexs
                    VectorOfPoint aprox = new VectorOfPoint();

                    // EXAMEN INICI: Invoca la llibreria per a trobar els contorns de la figura i comptar els vèrtex aprox.Size
                    CvInvoke.ApproxPolyDP(contorn, aprox, 0.04 * CvInvoke.ArcLength(contorn, true), true);


                    // EXAMEN FI

                    // 2. Classificació segons el nombre de vèrtexs
                    string tipus = "";

                    // EXAMEN INICI
                    if (aprox.Size == 3)
                    {
                        tipus = "Triangle";
                    }
                    else if (aprox.Size == 4)
                    {
                        tipus = "Rectangle";
                    }
                    else if (aprox.Size >= 5)
                    {
                        tipus = "Cercle";
                    }
                    else
                    {
                        tipus = "Desconegut";
                    }

                    // EXAMEN FI

                    // Actualitzem el label amb l'última detecció
                    lblPoligon1.Text = tipus;

                    Peca novaPeca = new Peca(tipus, area);

                    _llistaPeces.Add(novaPeca);

                    Rectangle boundingRect = CvInvoke.BoundingRectangle(contorn);

                    CvInvoke.Rectangle(imatgeColor, boundingRect, new MCvScalar(0, 0, 255), 2);

                }

                // Mostrem el resultat final amb els rectangles dibuixats
                pbImatge1.Image = imatgeColor.ToBitmap();
            }
        }

        // --- BLOC 2: GESTIÓ I PDF ---

        private void btnAfegir1_Click(object sender, EventArgs e)
        {
            // Lògica simplificada per a l'examen: afegeix la darrera peça detectada


            // EXAMEN INICI: Afegeix una péça (Objecte Peca.cs) passant el tipus de la peça (nom). L'ària i la data poden quedar buits.
            if (_llistaPeces.Count == 0)
            {
                MessageBox.Show("No hi ha figures detectades. Primer prem el botó Contorn!");
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _llistaPeces;

            // EXAMEN FI

            // Crida a funció per a refrescar el contingut de la graella
            //  RefrescarGraella(_llistaPeces);

        }

        private void tbCerca1_TextChanged(object sender, EventArgs e)
        {
            // Filtre LINQ dinàmic
            string cerca = tbCerca1.Text.ToLower();

            List<Peca> llistaFiltrada = _llistaPeces
            // EXAMEN INICI: Apliqueu el filtre dinàmic per a refrescar el que es mostra a la graella DataGridView
            .Where(p => p.Tipus.ToLower().Contains(cerca))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = llistaFiltrada;


            // EXAMEN FI

            // Crida a funció per a refrescar el contingut de la graella
            // RefrescarGraella(filtrada);
        }

        private void btnInforme1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hi ha dades per exportar!");
                return;
            }

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont fontTitol = new XFont("Arial", 16, XFontStyle.Regular);
            XFont fontNormal = new XFont("Arial", 12, XFontStyle.Regular);

            gfx.DrawString("Inventari de Peces Filtrades", fontTitol, XBrushes.Black, 40, 40);

            int yPos = 80;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;

                string tipus = fila.Cells["Tipus"].Value.ToString();
                string data = fila.Cells["Data"].Value.ToString();

                gfx.DrawString($"{tipus} - {data}", fontNormal, XBrushes.Black, 40, yPos);
                yPos += 20;
            }

            gfx.DrawString($"Total de peces exportades: {dataGridView1.Rows.Count - 1}", fontNormal, XBrushes.Black, 40, yPos + 20);

            string rutaFitxer = "Resultats.pdf";
            document.Save("Resultats.pdf");
            MessageBox.Show($"PDF generat correctament: {"Resultats.pdf"}");
        }
    }
}