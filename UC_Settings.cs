using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpusTool
{
    public partial class UC_Settings : UserControl
    {
        private string previousSelectedItem = null;
        public Form1 ParentForm { get; set; }
        private CultureManager<UC_Settings> _cultureManager;
        private ResourceManager rm;

        public UC_Settings(Form1 parent)
        {
            InitializeComponent();
            ParentForm = parent;
            volumeBar.Value = (int) (Form1.backgroundMusic.Volume * 100f);
            _cultureManager = new CultureManager<UC_Settings>(this);
            rm = _cultureManager.rm;
            languageBox.Items.Add(rm.GetString("languageEn"));
            languageBox.Items.Add(rm.GetString("languageEs"));
            var p= Properties.Settings.Default.CultureInfo == "en" ? languageBox.SelectedIndex = 0 : languageBox.SelectedIndex = 1;
           
        }
        public async void checkUpdate()
        {
            if (isInternetAvailable()) 
            {
                try
                {
                    using (var client = new HttpClient())
                    {

                        client.DefaultRequestHeaders.Add("User-Agent", "UpdateApp");
                        var response = await client.GetAsync(@"https://api.github.com/repos/Domivat24/OpustTools/releases/latest");
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var latestRelease = JsonConvert.DeserializeObject<GitHubRelease>(responseContent);

                        // in case there is no releases section as of development phase
                        string latestVersion = latestRelease.TagName == null ? "0.0.0.0" : latestRelease.TagName;
                        Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);

                        if (Version.Parse(latestVersion) > Assembly.GetExecutingAssembly().GetName().Version)
                        {
                            DialogResult dialogResult = MessageBox.Show(rm.GetString("messageNewVersion"), rm.GetString("captionNewVersion"), MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                var asset = latestRelease.Assets.FirstOrDefault(a => a.Name.EndsWith(".zip"));
                                if (asset != null)
                                {
                                    var downloadUrl = asset.BrowserDownloadUrl;
                                    var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".zip");
                                    using (var downloadClient = new HttpClient())
                                    using (var downloadStream = await downloadClient.GetStreamAsync(downloadUrl))
                                    using (var fileStream = File.Create(tempFilePath))
                                    {
                                        await downloadStream.CopyToAsync(fileStream);
                                    }
                                    // Extract the new release package to a temporary directory
                                    var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                                    ZipFile.ExtractToDirectory(tempFilePath, tempDir);

                                    // Find the executable file in the new release package
                                    var newExePath = Directory.GetFiles(tempDir, "*.exe", SearchOption.AllDirectories)
                                        .FirstOrDefault();

                                    if (newExePath != null)
                                    {

                                        // Close the current instance of the application
                                        var currentProcess = Process.GetCurrentProcess();
                                        foreach (var process in Process.GetProcessesByName(currentProcess.ProcessName))
                                        {
                                            if (process.Id != currentProcess.Id && process.MainModule.FileName == currentProcess.MainModule.FileName)
                                            {
                                                process.Kill();
                                            }
                                        }

                                        // Move the new executable to the application directory
                                        var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                                        var newExeName = Path.GetFileName(newExePath);
                                        var newExeDestPath = Path.Combine(appDir, newExeName);
                                        File.Move(newExePath, newExeDestPath);

                                        // Run the new version of the application
                                        Process.Start(newExeDestPath);
                                    }
                                    else
                                    {
                                        // Display an error message if the new release package does not contain an executable file
                                        MessageBox.Show("Failed to find an executable file in the new release package.", "Update Error");
                                    }

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay actualizaciones disponibles", "Versión al día", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Se ha producido el siguiente error al intentar actualizar la aplicación {0}", ex.ToString()), "Error al descargar la actualización .", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("No hay conexión a Internet. Para comprobar si hay nuevas actualizaciones debes tener acceso a la red.", "Error al buscar actualizaciones.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            Form1.backgroundMusic.Volume = (float)volumeBar.Value / 100f;
        }
        public static bool isInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.google.com"); 
                return true;
            }
            catch (SocketException ex)
            {
                return false;
            }
        }

        private void checkUpdates_Click(object sender, EventArgs e)
        {
            checkUpdate();
        }

        private void languageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedValue = comboBox.SelectedItem?.ToString();

            if (selectedValue != null && selectedValue != previousSelectedItem)
            {
                switch(comboBox.SelectedIndex)
                {
                    case 0:
                        Properties.Settings.Default.CultureInfo = "en";
                        Properties.Settings.Default.Save();
                        break;
                    case 1:
                        Properties.Settings.Default.CultureInfo = "es";
                        Properties.Settings.Default.Save();
                        break;
                }
                _cultureManager.setCultureInfo();
                _cultureManager.updateCurrentControlCulture();
                ParentForm._cultureManager.setCultureInfo();
                ParentForm._cultureManager.updateCurrentControlCulture();
                previousSelectedItem = selectedValue;
            }

        }
    }
}
