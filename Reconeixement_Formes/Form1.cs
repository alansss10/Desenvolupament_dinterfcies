using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace Reconeixement_Formes
{
    public partial class Form1 : Form
    {
        private VideoCapture capture;
        private bool capturing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
            capture.ImageGrabbed += ProcessFrame;
            capture.Start();
            capturing = true;
        }

        private void btnAturar_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Stop();
                capture.Dispose();
                capturing = false;
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            capture.Retrieve(frame);

            Image<Bgr, byte> imgColor = frame.ToImage<Bgr, byte>();
            Image<Gray, byte> imgGray = imgColor.Convert<Gray, byte>();
            imgGray = imgGray.SmoothGaussian(5);
            Image<Gray, byte> imgCanny = imgGray.Canny(100, 60);

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(imgCanny, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                string formaDetectada = "Cap";

                for (int i = 0; i < contours.Size; i++)
                {
                    double area = CvInvoke.ContourArea(contours[i]);
                    if (area < 1000) continue;

                    using (VectorOfPoint approx = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contours[i], approx, CvInvoke.ArcLength(contours[i], true) * 0.04, true);

                        int vertices = approx.Size;
                        string forma = "";

                        if (vertices == 3) forma = "Triangle";
                        else if (vertices == 4) forma = "Rectangle";
                        else if (vertices > 6) forma = "Cercle";

                        if (forma != "")
                        {
                            formaDetectada = forma;

                            // Dibuixa el contorn
                            if (chkContorns.Checked)
                                CvInvoke.CvtColor(imgCanny.Mat, imgColor.Mat, ColorConversion.Gray2Bgr);

                            CvInvoke.DrawContours(imgColor.Mat, contours, i, new MCvScalar(0, 255, 0), 2);

                            // Escriu el nom al centre
                            var moments = CvInvoke.Moments(contours[i]);
                            int cx = (int)(moments.M10 / moments.M00);
                            int cy = (int)(moments.M01 / moments.M00);
                            CvInvoke.PutText(imgColor.Mat, forma, new System.Drawing.Point(cx, cy),
                                FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), 2);
                        }
                    }
                }

                // Actualitza la interfície
                pictureBox1.Invoke((Action)(() =>
                {
                    // Liberamos la imagen anterior para no saturar la memoria RAM
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();

                    // Convertimos a Bitmap y asignamos
                    // Si .ToBitmap() sigue dando error, asegúrate de tener 'using Emgu.CV.UI;'
                    pictureBox1.Image = imgColor.ToBitmap();

                    lblForma.Text = "Forma detectada: " + formaDetectada;
                }));
            }
        }
    }
}