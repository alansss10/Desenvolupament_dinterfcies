# 🖥️ Desenvolupament d'Interfícies

Repositori de pràctiques i exercicis de l'assignatura **Desenvolupament d'Interfícies**.

Cada branca conté un projecte independent. La branca `main` serveix com a índex general on es documenten tots els projectes.

---

## 📁 Estructura del repositori

| Branca | Descripció |
|--------|------------|
| `main` | README general i índex de projectes |
| `en-revisio` | Projecte 1 — Sistema de Triatge de Figures Geomètriques |

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
- **EmguCV** (wrapper de OpenCV per a .NET) — Processament d'imatge i detecció de contorns
- **iTextSharp** — Generació de documents PDF

#### Com funciona per dins

El procés d'anàlisi segueix els passos clàssics de visió per computador:

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

## 🛠️ Requisits generals

- Visual Studio 2019 o superior
- .NET Framework 4.x
- Paquets NuGet: `Emgu.CV`, `iTextSharp`

---

## 👤 Autor

**Alan** — Curs d'FP en Desenvolupament d'Aplicacions Multiplataforma (DAM)