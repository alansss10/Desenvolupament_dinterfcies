using System;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace PracticaEvaluable2
{
    public partial class MainForm : Form
    {
        private UsersRepository Repository;
        private SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        private Button btnVoice;
        private Label playbackLabel;

        public MainForm()
        {
            InitializeComponent();
            Repository = UsersRepository.GetInstance();
            InitVoiceControls();
            ConfigurarReconocimientoVoz();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUsersRepository();
            BuildMenu();
            InitListBoxes();
        }

        private void BuildMenu()
        {
            var menu = new MenuStrip();

            var file = new ToolStripMenuItem("File");
            var open = new ToolStripMenuItem("Open") { ShortcutKeys = Keys.Control | Keys.O };
            open.Click += (s, e) => ShowDataGridForm();
            var exit = new ToolStripMenuItem("Exit") { ShortcutKeys = Keys.Alt | Keys.F4 };
            exit.Click += (s, e) => Application.Exit();
            file.DropDownItems.Add(open);
            file.DropDownItems.Add(new ToolStripSeparator());
            file.DropDownItems.Add(exit);

            var helpMenu = new ToolStripMenuItem("Help");
            var manual = new ToolStripMenuItem("Manual") { ShortcutKeys = Keys.Control | Keys.H };
            manual.Click += (s, e) => AbrirHelpForm();
            helpMenu.DropDownItems.Add(manual);

            menu.Items.Add(file);
            menu.Items.Add(helpMenu);

            this.Controls.Add(menu);
            this.MainMenuStrip = menu;
        }

        private void InitVoiceControls()
        {
            btnVoice = new Button { Text = "Voice command", Top = 60, Left = 450, Width = 120 };
            btnVoice.Click += (s, e) => {
                btnVoice.Text = "Listening...";
                recEngine.RecognizeAsync(RecognizeMode.Single);
            };

            playbackLabel = new Label { Text = "...", Top = 90, Left = 450, Width = 150 };

            this.Controls.Add(btnVoice);
            this.Controls.Add(playbackLabel);
        }

        private void ConfigurarReconocimientoVoz()
        {
            try
            {
                Choices comandos = new Choices();
                comandos.Add(new string[] { "ajuda", "help" });
                GrammarBuilder gb = new GrammarBuilder(comandos);
                Grammar gramatica = new Grammar(gb);

                recEngine.LoadGrammar(gramatica);
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.SpeechRecognized += (s, e) => {
                    playbackLabel.Text = e.Result.Text;
                    if (e.Result.Text == "ajuda" || e.Result.Text == "help")
                    {
                        AbrirHelpForm();
                    }
                    btnVoice.Text = "Voice command";
                };
            }
            catch { }
        }

        private void AbrirHelpForm()
        {
            HelpForm help = new HelpForm();
            help.Show();
        }

        private void InitUsersRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                var name = RandomUserDataGenerator.GetRandomName();
                AddStudent(Repository.GetNextUserId(), name, RandomUserDataGenerator.NameToMail(name), RandomUserDataGenerator.NameToCourse(name));
            }

            for (int i = 0; i < 5; i++)
            {
                var name = RandomUserDataGenerator.GetRandomName();
                AddAdmin(Repository.GetNextUserId(), name, RandomUserDataGenerator.NameToMail(name), "DAM");
            }
        }

        private void AddStudent(int id, string name, string mail, string course)
        {
            var s = new Student(id, name, mail, course);
            Repository.Add(s);
        }

        private void AddAdmin(int id, string name, string mail, string department)
        {
            var a = new Admin(id, name, mail, department);
            Repository.Add(a);
        }

        private void InitListBoxes()
        {
            listBoxAdmins.Items.Clear();
            listBoxStudents.Items.Clear();
            Repository.GetStudents().ForEach(s => listBoxStudents.Items.Add(s.ToString()));
            Repository.GetAdmins().ForEach(s => listBoxAdmins.Items.Add(s.ToString()));
        }

        private void ShowDataGridForm()
        {
            var usersForm = new UsersDataGridForm(this);
            usersForm.ShowDialog();
        }

        public void RefreshFormData()
        {
            InitListBoxes();
        }
    }
}