using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Text;
using Yarhl.FileSystem;
using Yarhl.Media.Text;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;
using OpusTool.Properties;
using System.Resources;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Gameloop.Vdf;

namespace OpusTool
{
    public partial class Form1 : Form
    {
        public static WaveOutEvent backgroundMusic;
        private UC_Settings uC_Settings;
        public CultureManager<Form1> _cultureManager;
        private ResourceManager rm;
        private string currentButton = "";
        public Form1()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<Form1>(this);
            _cultureManager.updateCurrentControlCulture();
            rm = _cultureManager.rm;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var ms = new MemoryStream(Resources.backgroundMusic);
            WaveStream waveStream = new Mp3FileReader(ms);

            backgroundMusic = new WaveOutEvent();

            backgroundMusic.Init(new LoopStream(waveStream));
            backgroundMusic.Play();

            //If the actual user path is not setted or incorrect, tries to find it in Steam folders and tells the user in case it cannot find it
            if (!Directory.Exists(Path.Combine(Settings.Default.GamePath, "OPUS Rocket of Whispers_data")))
            {
                string gamePath = GetSteamGamePath();
                if (gamePath != null)
                {
                    Console.WriteLine("Opus Rocket of Whispers installed at {0}", gamePath);
                    Properties.Settings.Default.GamePath = gamePath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show(rm.GetString("gamePathMissing"), rm.GetString("captionGamePathMissing"), MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            add_UserControls(new UC_Patcher());
        }

        static string GetSteamGamePath()
        {
            // Open the Steam registry key
            RegistryKey steamKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            if (steamKey == null)
            {
                return null;
            }

            // Get the installation directory of Steam
            string steamPath = steamKey.GetValue("SteamPath") as string;
            Console.WriteLine(steamPath);

            if (steamPath == null)
            {
                return null;
            }
            //Search for tne AppId in the Steam Library Folders
            dynamic libraries = VdfConvert.Deserialize(File.ReadAllText(steamPath + @"\steamapps\libraryfolders.vdf"));
            foreach (var kvp in libraries.Value)
            {
                string libraryIndex = kvp.Key;
                dynamic library = kvp.Value;

                if (library != null)
                {
                    string folderPath = library["path"].ToString();
                    dynamic apps = library["apps"];

                    Console.WriteLine("Library Index: " + libraryIndex);
                    Console.WriteLine("Folder Path: " + folderPath);
                    if (apps != null)
                    {
                        foreach (var appKvp in apps)
                        {
                            string appId = appKvp.Key;
                            //ID of Opus Rocket of Whispers
                            if (appId == "742250")
                            {
                                dynamic app = appKvp.Value;
                                string appName = library["path"].ToString();
                                Console.WriteLine("App ID: " + appId);
                                Console.WriteLine("App Name: " + appName);
                                return Path.Combine(library["path"].ToString(), "steamapps", "common", "Opus Rocket Of Whispers");
                            }
                        }
                    }
                }
            }
            return null;
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
            foreach (var panel in tableLayoutPanel1.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.FromArgb((byte)(114), (byte)117, (byte)147); ;
            }
            Button button = (Button)sender;
            if (button.Name != currentButton)
            {
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
                currentButton = button.Name;
            }


        }
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            backgroundMusic.Dispose();
        }
    }
}