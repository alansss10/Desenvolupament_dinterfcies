// EmguCV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
// iTextSharp
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EN_REVISION
{
    public partial class Form1 : Form
    {
        private Mat imatgeOriginal = null;                       
        private List<Figura> llistaFigures = new List<Figura>();  

        public Form1()
        {
            InitializeComponent();

            textBox1.TextChanged += new EventHandler(FiltrarBusqueda);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Imatges|*.jpg;*.jpeg;*.png;*.bmp";
            open.Title = "Selecciona una imatge";

            if (open.ShowDialog() == DialogResult.OK)
            {
                imatgeOriginal = CvInvoke.Imread(open.FileName, ImreadModes.Color);

                pictureBox1.Image = imatgeOriginal.ToBitmap();

                llistaFigures.Clear();
                dataGridView1.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imatgeOriginal == null || imatgeOriginal.IsEmpty)
            {
                MessageBox.Show(
                    "Heu de carregar una imatge primer",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            llistaFigures.Clear();

            Mat grisos = new Mat();
            CvInvoke.CvtColor(imatgeOriginal, grisos, ColorConversion.Bgr2Gray);

            Mat suavitzat = new Mat();
            CvInvoke.GaussianBlur(grisos, suavitzat, new System.Drawing.Size(5, 5), 0);


            Mat binaria = new Mat();
            CvInvoke.Threshold(suavitzat, binaria, 127, 255, ThresholdType.Binary);

            VectorOfVectorOfPoint contorns = new VectorOfVectorOfPoint();
            Mat jerarquia = new Mat();
            CvInvoke.FindContours(
                binaria,
                contorns,
                jerarquia,
                RetrType.External,
                ChainApproxMethod.ChainApproxSimple
            );

            Mat imatgeResultat = imatgeOriginal.Clone();

            int comptador = 1;

            for (int i = 0; i < contorns.Size; i++)
            {
                VectorOfPoint contorn = contorns[i];

                double area = CvInvoke.ContourArea(contorn);
                if (area < 500) continue;

                VectorOfPoint poligon = new VectorOfPoint();
                double perimeter = CvInvoke.ArcLength(contorn, true);
                CvInvoke.ApproxPolyDP(contorn, poligon, 0.02 * perimeter, true);

                int vertexs = poligon.Size;

                string tipus;
                if (vertexs == 3)
                    tipus = "Triangle";
                else if (vertexs == 4)
                    tipus = "Rectangle";
                else if (vertexs > 6)
                    tipus = "Cercle";
                else
                    continue;

                llistaFigures.Add(new Figura(comptador, tipus, area));

                System.Drawing.Rectangle rect = CvInvoke.BoundingRectangle(contorn);
                CvInvoke.Rectangle(
                    imatgeResultat,
                    rect,
                    new MCvScalar(0, 0, 255),
                    2
                );

                CvInvoke.PutText(
                    imatgeResultat,
                    tipus,
                    new System.Drawing.Point(rect.X, rect.Y - 5),
                    FontFace.HersheySimplex,
                    0.6,
                    new MCvScalar(0, 0, 255),
                    2
                );

                comptador++;
            }

            pictureBox1.Image = imatgeResultat.ToBitmap();

            // Actualizamos el DataGridView
            ActualizarGrid(llistaFigures);

            MessageBox.Show(
                $"Anàlisi completada! S'han trobat {llistaFigures.Count} figures.",
                "Resultat",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (llistaFigures.Count == 0)
            {
                MessageBox.Show(
                    "No hi ha figures per exportar. Analitzeu una imatge primer.",
                    "Avís",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string rutaPDF = "Resultats.pdf";

            try
            {
                Document document = new Document(PageSize.A4, 40, 40, 60, 40);
                PdfWriter.GetInstance(document, new FileStream(rutaPDF, FileMode.Create));
                document.Open();

                iTextSharp.text.Font fontTitol = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 18,
                    iTextSharp.text.Font.BOLD,
                    BaseColor.DARK_GRAY
                );
                Paragraph titol = new Paragraph("Inventari de Peces\n\n", fontTitol);
                titol.Alignment = Element.ALIGN_CENTER;
                document.Add(titol);

                PdfPTable taula = new PdfPTable(3);
                taula.WidthPercentage = 100;

                iTextSharp.text.Font fontCap = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 12,
                    iTextSharp.text.Font.BOLD,
                    BaseColor.WHITE
                );
                foreach (string cap in new[] { "ID", "Tipus", "Àrea (px²)" })
                {
                    PdfPCell cel = new PdfPCell(new Phrase(cap, fontCap));
                    cel.BackgroundColor = new BaseColor(70, 130, 180);
                    cel.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel.Padding = 6;
                    taula.AddCell(cel);
                }

                iTextSharp.text.Font fontDades = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 11
                );
                foreach (Figura f in llistaFigures)
                {
                    taula.AddCell(new PdfPCell(new Phrase(f.Id.ToString(), fontDades)) { Padding = 5 });
                    taula.AddCell(new PdfPCell(new Phrase(f.Tipus, fontDades)) { Padding = 5 });
                    taula.AddCell(new PdfPCell(new Phrase(f.Area.ToString(), fontDades)) { Padding = 5 });
                }

                document.Add(taula);

                iTextSharp.text.Font fontTotal = new iTextSharp.text.Font(
                    iTextSharp.text.Font.FontFamily.HELVETICA, 12,
                    iTextSharp.text.Font.BOLD
                );
                document.Add(new Paragraph($"\nTotal d'elements: {llistaFigures.Count}", fontTotal));

                document.Close();

                MessageBox.Show(
                    $"PDF generat correctament:\n{Path.GetFullPath(rutaPDF)}",
                    "PDF Generat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generant el PDF: {ex.Message}", "Error");
            }
        }
        private void ActualizarGrid(List<Figura> figures)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BindingList<Figura>(figures);
        }
        private void FiltrarBusqueda(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(text))
            {
                ActualizarGrid(llistaFigures);
            }
            else
            {
                List<Figura> filtrades = llistaFigures
                    .Where(f => f.Tipus.ToLower().Contains(text))
                    .ToList();
                ActualizarGrid(filtrades);
            }
        }
    }

    public class Figura
    {
        public int Id { get; set; }
        public string Tipus { get; set; }
        public double Area { get; set; }

        public Figura(int id, string tipus, double area)
        {
            Id = id;
            Tipus = tipus;
            Area = Math.Round(area, 2);
        }
    }
}