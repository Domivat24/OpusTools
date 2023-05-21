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
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace OpusTool
{
    public partial class Form1 : Form
    {
        public static WaveOutEvent backgroundMusic;
        private UC_Settings uC_Settings;
        public CultureManager<Form1> _cultureManager;
        public static string gameDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\OPUS ROCKET OF WHISPERS\";
        public Form1()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<Form1>(this);
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

            string gameName = "OPUS ROCKET OF WHISPERS";

            // Replace "Game AppID" with the AppID of the game you want to check
            string gameAppId = "742250";

            // Check if the game is installed
            string gamePath = GetSteamGamePath(gameName, gameAppId);
            if (gamePath != null)
            {
                Console.WriteLine("{0} is installed at {1}", gameName, gamePath);
            }
            else
            {
                Console.WriteLine("{0} is not installed", gameName);
            }
        }

        static string GetSteamGamePath(string gameName, string gameAppId)
        {
            // Open the Steam registry key
            RegistryKey steamKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            if (steamKey == null)
            {
                return null;
            }

            // Get the installation directory of Steam
            string steamPath = steamKey.GetValue("SteamPath") as string;
            if (steamPath == null)
            {
                return null;
            }

            // Get the library folders
            string[] libraryFolders = GetSteamLibraryFolders(steamPath);
            if (libraryFolders == null || libraryFolders.Length == 0)
            {
                return null;
            }

            // Search for the game in each library folder
            foreach (string libraryFolder in libraryFolders)
            {
                string appManifestFile = Path.Combine(libraryFolder, "steamapps", $"appmanifest_{gameAppId}.acf");
                if (File.Exists(appManifestFile))
                {
                    string appName = GetAppNameFromAppManifest(appManifestFile);
                    if (appName.Equals(gameName, StringComparison.OrdinalIgnoreCase))
                    {
                        return libraryFolder;
                    }
                }
            }

            return null;
        }

        static string[] GetSteamLibraryFolders(string steamPath)
        {
            string libraryFile = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
            if (!File.Exists(libraryFile))
            {
                return null;
            }

            string[] lines = File.ReadAllLines(libraryFile);
            string[] libraryFolders = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.EndsWith("\""))
                {
                    int startIndex = line.IndexOf('"');
                    int endIndex = line.LastIndexOf('"');
                    if (startIndex >= 0 && endIndex >= 0 && startIndex != endIndex)
                    {
                        string libraryFolder = line.Substring(startIndex + 1, endIndex - startIndex - 1);
                        if (!string.IsNullOrWhiteSpace(libraryFolder))
                        {
                            libraryFolders[i] = libraryFolder;
                        }
                    }
                }
            }

            return libraryFolders.Where(folder => !string.IsNullOrEmpty(folder)).ToArray();
        }

        static string GetAppNameFromAppManifest(string appManifestFile)
        {
            string appManifestContent = File.ReadAllText(appManifestFile);
            Match match = Regex.Match(appManifestContent, "\"name\"\\s*\"(.*?)\"");
            if (match.Success)
            {
                return match.Groups[1].Value;
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
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            backgroundMusic.Dispose();
        }
    }
}