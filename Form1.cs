using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Yarhl.FileSystem;
using Yarhl.Media.Text;

namespace OpusTool
{
    public partial class Form1 : Form
    {
        private WaveOutEvent backgroundMusic;
        public Form1()
        {
            InitializeComponent();
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
            Console.WriteLine("CONSOLA");


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            backgroundMusic.Volume = (float)trackBar1.Value / 100f;
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
                    add_UserControls(new UC_Settings());
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