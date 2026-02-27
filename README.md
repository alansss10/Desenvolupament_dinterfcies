# 🖥️ Desenvolupament d'Interfícies
Repositori de pràctiques i exercicis de l'assignatura **Desenvolupament d'Interfícies**.
Cada branca conté un projecte independent. La branca `main` serveix com a índex general on es documenten tots els projectes.

---

## 📁 Estructura del repositori

| Branca | Descripció |
|--------|------------|
| `main` | README general i índex de projectes |
| `en-revisio` | Projecte 1 — Sistema de Triatge de Figures Geomètriques |
| `hobby-mania` | Projecte 2 — Sistema de Triatge de Peces (Hobby Mania) |
| `reconeixement-formes` | Projecte 3 — Reconeixement de Formes i Realitat Augmentada Bàsica |

> Les branques s'aniran afegint a mesura que s'avanci en l'assignatura.

---

## 🚀 Projectes

### 📌 Projecte 1 — Sistema de Triatge de Figures Geomètriques (`en-revisio`)
Aplicació d'escriptori desenvolupada en **C# WinForms** per a la detecció i classificació automàtica de figures geomètriques en imatges.

#### Descripció
L'aplicació simula un sistema de triatge per a una empresa de fabricació de peces (*Hobby Mania*). Permet carregar una imatge, analitzar-ne el contingut per detectar les formes geomètriques presents, i exportar un inventari en format PDF.

#### Funcionalitats
- **Carregar imatge** — Suporta formats JPG, PNG i BMP.
- **Analitzar imatge** — Detecta i classifica automàticament triangles, rectangles i cercles, calculant l'àrea de cadascun en píxels quadrats.
- **Visualització** — Mostra les figures detectades directament sobre la imatge amb el seu tipus indicat.
- **Taula de resultats** — Presenta en un DataGridView l'ID, el tipus i l'àrea de cada figura trobada.
- **Cerca en temps real** — Permet filtrar les figures per tipus mentre s'escriu.
- **Exportar a PDF** — Genera un fitxer `Resultats.pdf` amb l'inventari complet de peces, amb format de taula estilitzada.

#### Tecnologies i llibreries
- **C# / WinForms** (.NET Framework)
- **EmguCV** — Processament d'imatge i detecció de contorns
- **iTextSharp** — Generació de documents PDF

#### Com funciona per dins
1. Conversió de la imatge a escala de grisos
2. Suavitzat amb filtre Gaussià (5×5)
3. Binarització per llindar (*threshold*)
4. Detecció de contorns externs
5. Aproximació poligonal per comptar vèrtexs:
   - 3 vèrtexs → Triangle
   - 4 vèrtexs → Rectangle
   - Més de 6 vèrtexs → Cercle
6. Les figures amb àrea inferior a 500 px² es descarten com a soroll

---

### 📌 Projecte 2 — Sistema de Triatge de Peces Hobby Mania (`hobby-mania`)
Aplicació d'escriptori desenvolupada en **C# WinForms** per a la detecció, classificació i gestió de peces per a l'empresa Hobby Mania.

#### Descripció
L'aplicació permet carregar una imatge, processar-la mitjançant visió per computador per detectar figures geomètriques, gestionar les dades en una taula interactiva i exportar un informe en PDF.

#### Funcionalitats
- **Carregar imatge** — Suporta formats JPG, PNG i BMP.
- **Pipeline de visió** — Conversió a gris, suavitzat gaussià, binarització i detecció de contorns.
- **Classificació automàtica** — Detecta Triangles, Rectangles i Cercles.
- **Feedback visual** — Dibuixa rectangles vermells al voltant de cada figura detectada.
- **Taula de resultats** — Presenta en un DataGridView el tipus i la data de detecció.
- **Cerca en temps real** — Filtra les figures per tipus ignorant majúscules/minúscules.
- **Exportar a PDF** — Genera un fitxer `Resultats.pdf` amb l'inventari filtrat i el total de peces.

#### Tecnologies i llibreries
- **C# / WinForms** (.NET 8)
- **EmguCV** — Processament d'imatge i detecció de contorns
- **PDFsharp 1.50** — Generació de documents PDF

#### Com funciona per dins
1. Conversió de la imatge a escala de grisos (CvtColor)
2. Suavitzat amb filtre Gaussià (5×5) (GaussianBlur)
3. Binarització per llindar amb valor 100 (Threshold)
4. Detecció de contorns externs (FindContours)
5. Aproximació poligonal (ApproxPolyDP, epsilon 0.04):
   - 3 vèrtexs → Triangle
   - 4 vèrtexs → Rectangle
   - 5 o més vèrtexs → Cercle
6. Les figures amb àrea inferior a 500 px² es descarten com a soroll

---

### 📌 Projecte 3 — Reconeixement de Formes i Realitat Augmentada Bàsica (`reconeixement-formes`)
Aplicació d'escriptori desenvolupada en **C# WinForms** que utilitza la càmera en temps real per identificar formes geomètriques i les etiqueta directament sobre el vídeo.

#### Descripció
L'aplicació captura el flux de la càmera, processa cada frame mitjançant visió per computador per detectar formes geomètriques (triangles, rectangles i cercles), i superposa el nom de la figura detectada sobre la imatge en temps real, simulant una experiència de Realitat Augmentada bàsica.

#### Funcionalitats
- **Iniciar/Aturar càmera** — Control del flux de vídeo en temps real.
- **Detecció en temps real** — Identifica triangles, rectangles i cercles mostrats davant la càmera.
- **Realitat Augmentada bàsica** — Dibuixa el contorn de la figura detectada i escriu el seu nom al centre directament sobre el vídeo.
- **Mostrar contorns** — CheckBox per activar/desactivar la visualització del processament intern (vores Canny).
- **Label de resultat** — Indica en tot moment quina és l'última forma reconeguda.

#### Tecnologies i llibreries
- **C# / WinForms** (.NET Framework 4.7.2)
- **EmguCV** — Captura de càmera, processament d'imatge i detecció de contorns
- **Emgu.CV.Bitmap** — Conversió de frames a Bitmap per mostrar al PictureBox

#### Com funciona per dins
1. Captura de frames via `VideoCapture` i event `ImageGrabbed`
2. Conversió del frame a escala de grisos
3. Suavitzat amb filtre Gaussià (5×5)
4. Detecció de vores amb l'algoritme Canny (100/60)
5. Detecció de contorns amb `FindContours`
6. Aproximació poligonal (ApproxPolyDP, epsilon 0.04):
   - 3 vèrtexs → Triangle
   - 4 vèrtexs → Rectangle
   - Més de 6 vèrtexs → Cercle
7. Els contorns amb àrea inferior a 1000 px² es descarten com a soroll
8. Superposició del nom i contorn sobre la imatge original en color

---

## 🛠️ Requisits generals
- Visual Studio 2022
- .NET Framework 4.7.2 / .NET 8.0
- Paquets NuGet: `Emgu.CV`, `Emgu.CV.runtime.windows`, `Emgu.CV.Bitmap`, `iTextSharp`, `PDFsharp 1.50`

---

## 👤 Autor
**Alan** — Curs d'FP en Desenvolupament d'Aplicacions Multiplataforma (DAM)
