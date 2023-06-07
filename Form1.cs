using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Resources;
using OpusTool.Properties;
using Microsoft.Win32;
using Gameloop.Vdf;
using System.Diagnostics;

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

            if (steamPath == null)
            {
                return null;
            }
            //Search for tne AppId in the Steam Library Folders
            dynamic libraries = VdfConvert.Deserialize(File.ReadAllText(steamPath + @"\steamapps\libraryfolders.vdf"));
            foreach (var kvp in libraries.Value)
            {
                dynamic library = kvp.Value;

                if (library != null)
                {
                    string folderPath = library["path"].ToString();
                    dynamic apps = library["apps"];
                    var possiblePath = Path.Combine(folderPath.ToString(), "steamapps", "common", "OPUS Rocket Of Whispers");
                    if (Directory.Exists(Path.Combine(possiblePath, "OPUS Rocket Of Whispers_data")) && File.Exists(Path.Combine(folderPath.ToString(),"steamapps", "appmanifest_742250.acf")))
                    {
                        return possiblePath;
                }

                /*
                 * ITERATE on apps library only gets updated after steam is restarted and is not strictly needed
                 * if (apps != null)
            {   foreach (var appKvp in apps)
                 {
                     string appId = appKvp.Key;
                     //ID of Opus Rocket of Whispers
                     if (appId == "742250")
                     {
                         dynamic app = appKvp.Value;
                         var possiblePath = Path.Combine(folderPath.ToString(), "steamapps", "common", "OPUS Rocket Of Whispers");
                         if (Directory.Exists(Path.Combine(possiblePath, "OPUS Rocket Of Whispers_data")))
                         {
                             return Path.Combine(folderPath.ToString(), "steamapps", "common", "OPUS Rocket Of Whispers");
                         }
                     }
                 }
             }

                */
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
            var Browser = UC_About.webView;
            if (Browser.Created)
            {
                try
                {
                    // Delete WebView2 user data before application exits
                    string? webViewCacheDir = Browser.CoreWebView2.Environment.UserDataFolder;
                    var webViewProcessId = Convert.ToInt32(Browser.CoreWebView2.BrowserProcessId);
                    var webViewProcess = Process.GetProcessById(webViewProcessId);

                    // Shutdown browser with Dispose, and wait for process to exit
                    Browser.Dispose();
                    webViewProcess.WaitForExit(3000);

                    Directory.Delete(webViewCacheDir, true);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100);
            //If the actual user path is not setted or incorrect, tries to find it in Steam folders and tells the user in case it cannot find it
            if (!Directory.Exists(Path.Combine(Settings.Default.GamePath, "OPUS Rocket of Whispers_Data")))
            {
                string gamePath = GetSteamGamePath();
                Debug.WriteLine(gamePath);
                Debug.WriteLine(Directory.Exists(Path.Combine(Settings.Default.GamePath, "OPUS Rocket of Whispers_Data")));
                //check if game is found and is not the remains of a previous installation
                if (gamePath != null && Directory.Exists(Path.Combine(gamePath, "OPUS Rocket of Whispers_Data")))
                {
                    Console.WriteLine("Opus Rocket of Whispers installed at {0}", gamePath);
                    Properties.Settings.Default.GamePath = gamePath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.GamePath = gamePath;
                    Properties.Settings.Default.Save();
                    MessageBox.Show(rm.GetString("gamePathMissing"), rm.GetString("captionGamePathMissing"), MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
    }
}