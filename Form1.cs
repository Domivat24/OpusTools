using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Yarhl.FileSystem;
using Yarhl.Media.Text;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace OpusTool
{
    public partial class Form1 : Form
    {
        public static WaveOutEvent backgroundMusic;
        private UC_Settings uC_Settings;
        public CultureManager<Form1> _cultureManager;
        public Form1()
        {
            InitializeComponent();
            _cultureManager= new CultureManager<Form1>(this);
            _cultureManager.updateCurrentControlCulture();

        }

      

    [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundMusic = new WaveOutEvent();
            var audioFile = new AudioFileReader("backgroundMusic.mp3");
            backgroundMusic.Init(new LoopStream(audioFile));
            backgroundMusic.Play();
            AllocConsole();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundMusic.Dispose();

        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void add_UserControls(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void tab_Click(object sender, EventArgs e)
        {
            foreach(var panel in tableLayoutPanel1.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.FromArgb((byte)(114),(byte) 117, (byte) 147); ;
            }
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "btnPatcher":
                    add_UserControls(new UC_Patcher());
                    panelPatcher.BackColor = Color.Turquoise;
                    break;
                case "btnTools":
                    add_UserControls(new UC_Tools());
                    panelTools.BackColor = Color.Turquoise;
                    break;
                case "btnSettings":
                    uC_Settings = new UC_Settings((Form1)this);
                    add_UserControls(uC_Settings);
                    panelSettings.BackColor = Color.Turquoise;
                    break;
                case "btnAbout":
                    add_UserControls(new UC_About());
                    panelAbout.BackColor = Color.Turquoise;
                    break;
                default:
                    break;
            }

        }
        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}