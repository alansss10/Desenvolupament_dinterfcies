using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ===================== CONFIGURACIÓN INICIAL =====================
// 1. Poner el proyecto en x64:
//    Compilar -> Administrador de configuración -> Nueva -> x64

// 2. Instalar paquetes NuGet (clic derecho proyecto -> Administrar paquetes NuGet):
//    - Emgu.CV
//    - Emgu.CV.runtime.windows
//    - Emgu.CV.Bitmap
//    - PDFsharp
//    IMPORTANTE: las tres primeras tienen que ser la misma versión

// ===================== DISEÑO DEL FORMULARIO =====================
// Controles que hay que añadir:
//    - pictureBox1 (arriba izquierda): muestra la imagen original y el resultado procesado
//      Propiedad SizeMode -> StretchImage
//    - dataGridView1 (arriba derecha): muestra la tabla de piezas detectadas

// Botones:
//    - btnCarregar1    -> "Carregar Imatge"   (carga la imagen del disco)
//    - btnGris1        -> "Convertir a Gris"  (convierte la imagen a escala de grises, Bloc 1A)
//    - btnSuavitzat1   -> "Suavitzat"         (aplica GaussianBlur para reducir ruido, Bloc 1A)
//    - btnSegmentacio1 -> "Segmentació"       (binariza la imagen con Threshold, Bloc 1A)
//    - btnContorn1     -> "Contorn"           (detecta y clasifica las figuras, Bloc 1B)
//    - btnAfegir1      -> "Afegir Polígon"    (añade la pieza detectada a la lista, Bloc 2A)
//    - btnInforme1     -> "Informe PDF"       (genera el informe PDF, Bloc 2C)

// TextBox:
//    - tbCerca1: para buscar/filtrar piezas en la tabla (Bloc 2B)
// Label:
//    - label1: etiqueta informativa al lado del TextBox

// ===================== CLASE Peca.cs =====================
// El ejercicio (Bloc 2A) dice: "Instancieu un objecte de la classe Peca passant el tipus detectat"
// Cada Peca guarda:
//    - Tipus (string): el tipo de figura detectada (Triangle, Rectangle, Cercle)
//    - Data (DateTime): la fecha/hora de detección, se asigna automáticamente con DateTime.Now
// Se crea con: Agregar -> Clase nueva -> Peca.cs

// ===================== VARIABLES GLOBALES (Form1.cs) =====================
// Dentro de la clase Form1, encima del constructor, declaramos:
//    - _imatgeActual (Mat): el ejercicio (Bloc 1) dice "Utilitzeu la variable global _imatgeActual"
//      guarda la imagen que vamos procesando en cada paso
//    - _llistaPeces (List<Peca>): el ejercicio (Bloc 2A) dice "Afegiu aquest objecte a la llista global"
//      guarda todas las piezas detectadas

// ===================== BOTONES IMPLEMENTADOS =====================
// btnCarregar1: abre un OpenFileDialog para elegir imagen (jpg, png, bmp)
//    - CvInvoke.Imread lee la imagen del disco y la guarda en _imatgeActual
//    - ToBitmap() la convierte para mostrarla en pictureBox1

// btnGris1: convierte la imagen a escala de grises (Bloc 1A)
//    - Validación: si no hay imagen cargada muestra un MessageBox (Bloc 4)
//    - CvInvoke.CvtColor con ColorConversion.Bgr2Gray hace la conversión

// btnSuavitzat1: aplica desenfoque gaussiano (Bloc 1A)
//    - Validación: si no hay imagen cargada muestra un MessageBox (Bloc 4)
//    - CvInvoke.GaussianBlur con Size(5,5) porque el ejercicio lo especifica explícitamente

// btnSegmentacio1: binariza la imagen (Bloc 1A)
//    - Validación: si no hay imagen cargada muestra un MessageBox (Bloc 4)
//    - CvInvoke.Threshold con umbral 100 y ThresholdType.Binary
//    - Convierte la imagen a blanco y negro puro para aislar las figuras del fondo 

// btnContorn1: detecta y clasifica las figuras (Bloc 1B)
//    - Validación: si no hay imagen cargada muestra un MessageBox (Bloc 4)
//    - Convertimos la imagen binarizada a color con Gray2Bgr para poder dibujar rectángulos rojos
//    - VectorOfVectorOfPoint: estructura que devuelve FindContours, es una lista de contornos
//      donde cada contorno es una lista de puntos
//    - FindContours con RetrType.External: solo detecta contornos exteriores
//    - Dentro del bucle por cada contorno:
//      * ContourArea: calculamos el área y si es menor de 500 la ignoramos (es ruido)
//      * ApproxPolyDP: simplifica el contorno para contar vértices, epsilon 0.04 es el punto crítico
//        según avisa el profesor en la guía
//      * Clasificación por vértices (aprox.Size): 3=Triangle, 4=Rectangle, >=5=Cercle (Bloc 1B)
//      * BoundingRectangle: obtiene el rectángulo que rodea la figura
//      * CvInvoke.Rectangle: dibuja el rectángulo rojo (0,0,255 en BGR) sobre la imagen

// btnAfegir1: muestra las piezas detectadas en la tabla (Bloc 2A)
//    - Validación: si no hay piezas detectadas muestra un MessageBox
//    - dataGridView1.DataSource = _llistaPeces: asigna la lista como fuente de datos
//      y automáticamente aparecen todas las piezas en la tabla
//    - Se pone DataSource a null primero para evitar duplicados

// tbCerca1 (TextChanged): filtro dinámico de búsqueda (Bloc 2B)
//    - El ejercicio dice "ignoreu majúscules/minúscules" por eso usamos ToLower()
//    - Consulta LINQ con Where y Contains para filtrar la lista por Tipus
//    - Se ejecuta cada vez que el usuario escribe una letra
//    - Actualiza el DataGridView con los resultados filtrados

// btnInforme1: genera el informe PDF (Bloc 2C)
//    - Validación: si la tabla está vacía muestra un MessageBox
//    - PdfDocument, PdfPage y XGraphics son las clases de PDFsharp para crear el PDF
//    - El ejercicio dice "Ha d'incloure el títol Inventari de Peces Filtrades"
//    - Recorre las filas del dataGridView1 (no la lista global) como dice el ejercicio
//    - IsNewRow evita procesar la fila vacía que siempre tiene el DataGridView al final
//    - Al final añade el total de piezas exportadas como pide el ejercicio
//    - Guarda el archivo como "Resultats.pdf" como especifica el ejercicio
//    - NOTA: usar PDFsharp versión 1.50.5147, la versión 6.x tiene problemas con las fuentes

namespace Hobby_Mania_2
{
    public partial class Form1 : Form
    {
        // es la img que vamos a procesar 
        private Mat _imatgeActual = new Mat();
        //Es la lista donde guardamos todas las piezas detectadas
        private List<Peca> _llistaPeces = new List<Peca>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCarregar1_Click(object sender, EventArgs e)
        {
            //abre la ventana del explorador de archivos para elegir una imagen
            OpenFileDialog dialeg = new OpenFileDialog();
            //  solo muestra archivos jpg, png y bmp
            dialeg.Filter = "Imatges|*.jpg;*.png;*.bmp";

            if (dialeg.ShowDialog() == DialogResult.OK)
            {
                //es la función de Emgu.CV que lee la imagen del disco y la guarda en _imatgeActual
                _imatgeActual = CvInvoke.Imread(dialeg.FileName);
                // convierte la imagen de formato Emgu.CV a formato que entiende el PictureBox para mostrarla
                pictureBox1.Image = _imatgeActual.ToBitmap();
            }
        }

        private void btnGris1_Click(object sender, EventArgs e)
        {
            // esto evita errores si pulsa el botón sin haber cargado imagen antes
            if (_imatgeActual.IsEmpty)
            {
                // avisa al usuario 
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            //  creamos una imagen nueva vacía donde guardaremos el resultado
            Mat imatgeGris = new Mat();
            // le dice que convierta de color (BGR) a gris
            CvInvoke.CvtColor(_imatgeActual, imatgeGris, ColorConversion.Bgr2Gray);
            //  actualizamos la variable global con la nueva imagen gris
            _imatgeActual = imatgeGris;
            // mostramos el resultado en el PictureBox
            pictureBox1.Image = _imatgeActual.ToBitmap();
        }

        private void btnSuavitzat1_Click(object sender, EventArgs e)
        {
            // esto evita errores si pulsa el botón sin haber cargado imagen antes
            if (_imatgeActual.IsEmpty)
            {
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            // imagen nueva vacía para guardar el resultado
            Mat imatgeSuavitzada = new Mat();
            // el ejercicio dice explícitamente "feu servir un Size(5,5)"
            CvInvoke.GaussianBlur(_imatgeActual, imatgeSuavitzada, new Size(5, 5), 0);
            // actualizamos la variable global
            _imatgeActual = imatgeSuavitzada;
            // mostramos el resultado en el PictureBox
            pictureBox1.Image = _imatgeActual.ToBitmap();
        }

        private void btnSegmentacio1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual.IsEmpty)
            {
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }

            Mat imatgeBinaritzada = new Mat();
            // Utilitzeu un llindar que aïlli correctament les figures del fons, los píxeles por debajo de 100 se vuelven negros
            // el valor máximo, los píxeles que superen el umbral se ponen a 255 (blanco puro)
            //  el tipo de binarización, blanco o negro, sin grises
            CvInvoke.Threshold(_imatgeActual, imatgeBinaritzada, 100, 255, ThresholdType.Binary);
            _imatgeActual = imatgeBinaritzada;
            pictureBox1.Image = _imatgeActual.ToBitmap();
        }

        private void btnContorn1_Click(object sender, EventArgs e)
        {
            if (_imatgeActual.IsEmpty)
            {
                MessageBox.Show("Primer carrega una imatge!");
                return;
            }
            //  creamos una imagen en color donde dibujaremos los rectángulos rojos encima de las figuras
            Mat imatgeColor = new Mat();
            // convertimos la imagen binarizada (blanco/negro) a color otra vez, porque para dibujar rectángulos rojos necesitamos una imagen en color
            CvInvoke.CvtColor(_imatgeActual, imatgeColor, ColorConversion.Gray2Bgr);
            // el ejercicio en el Bloc 1B dice "enteneu què retorna (VectorOfVectorOfPoint)", es una lista de contornos donde cada contorno es una lista de puntos
            VectorOfVectorOfPoint contorns = new VectorOfVectorOfPoint();
            // FindContours necesita una variable donde guardar la jerarquía de contornos, la necesitamos aunque no la usemos
            Mat jerarquia = new Mat();
            // solo detecta los contornos exteriores, no los que están dentro de otros // comprime los contornos guardando solo los puntos esenciales
            CvInvoke.FindContours(_imatgeActual, contorns, jerarquia, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contorns.Size; i++)
            {
                // cogemos el contorno actual
                VectorOfPoint contorn = contorns[i];
                double area = CvInvoke.ContourArea(contorn);
                // ignoramos contornos muy pequeños que son ruido, no figuras reales
                if (area < 500) continue;
                // imagen simplificada del contorno
                VectorOfPoint aprox = new VectorOfPoint();
                // el epsilon, el profesor avisa en la guía que ajustarlo bien es el punto crítico
                CvInvoke.ApproxPolyDP(contorn, aprox, 0.04 * CvInvoke.ArcLength(contorn, true), true);

                string tipus = "";

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
                Peca novaPeca = new Peca(tipus);
                _llistaPeces.Add(novaPeca);
                //el ejercicio en el Bloc 1B dice "Com obtenir el rectangle que envolta una figura", nos da las coordenadas del rectángulo que rodea la figura
                Rectangle boundingRect = CvInvoke.BoundingRectangle(contorn);
                // el ejercicio dice "Invoqueu CvInvoke.Rectangle per dibuixar un rectangle vermell", dibuja el rectángulo encima de la imagen
                // el color rojo en formato BGR (no RGB), por eso el rojo es el último número
                CvInvoke.Rectangle(imatgeColor, boundingRect, new MCvScalar(0, 0, 255), 2);
            }
                pictureBox1.Image = imatgeColor.ToBitmap();
        }

        private void btnAfegir1_Click(object sender, EventArgs e)
        {
            if (_llistaPeces.Count == 0)
            {
                MessageBox.Show("No hi ha figures detectades. Primer prem el botó Contorn!");
                return;
            }
            // el ejercicio en el Bloc 2B dice "Actualitzeu la graella dataGridView1",
            // asignamos la lista como fuente de datos y automáticamente aparecen todas las piezas en la tabl
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _llistaPeces;
        }

        private void tbCerca1_TextChanged(object sender, EventArgs e)
        {
            // el ejercicio dice "ignoreu majúscules/minúscules"
            string cerca = tbCerca1.Text.ToLower();

            List<Peca> llistaFiltrada = _llistaPeces
                // el ejercicio en el Bloc 2B dice "consulta LINQ que filtri la llista"
                // busca si el tipus contiene el texto escrito
                .Where(p => p.Tipus.ToLower().Contains(cerca))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = llistaFiltrada;
        }

        private void btnInforme1_Click(object sender, EventArgs e)
        {
            // el ejercicio en el Bloc 2C dice "Si la graella és buida, mostreu un MessageBox d'error"
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hi ha dades per exportar!");
                return;
            }

            // creamos el documento PDF vacío
            PdfDocument document = new PdfDocument();
            // añadimos una página al documento
            PdfPage page = document.AddPage();
            // es el "lápiz" con el que escribiremos en la página
            XGraphics gfx = XGraphics.FromPdfPage(page);
            // fuente grande para el título
            XFont fontTitol = new XFont("Arial", 16, XFontStyle.Bold);
            // fuente normal para el contenido
            XFont fontNormal = new XFont("Arial", 12, XFontStyle.Regular);

            // el ejercicio dice "Ha d'incloure el títol Inventari de Peces Filtrades"
            gfx.DrawString("Inventari de Peces Filtrades", fontTitol, XBrushes.Black, 40, 40);

            // controla la posición vertical donde escribimos cada línea
            int yPos = 80;

            // el ejercicio dice "recórrer les files del dataGridView1, no la llista global"
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // el DataGridView tiene siempre una fila vacía al final, la saltamos
                if (fila.IsNewRow) continue;

                string tipus = fila.Cells["Tipus"].Value.ToString();
                string data = fila.Cells["Data"].Value.ToString();

                gfx.DrawString($"{tipus} - {data}", fontNormal, XBrushes.Black, 40, yPos);
                // bajamos 20 píxeles para la siguiente línea
                yPos += 20;
            }

            // el ejercicio dice "al final, el recompte total d'elements exportats"
            gfx.DrawString($"Total de peces exportades: {dataGridView1.Rows.Count - 1}", fontNormal, XBrushes.Black, 40, yPos + 20);

            // el ejercicio dice explícitamente "un fitxer anomenat Resultats.pdf"
            string rutaFitxer = "Resultats.pdf";
            document.Save(rutaFitxer);
            MessageBox.Show($"PDF generat correctament: {rutaFitxer}");
        }
    }
}
