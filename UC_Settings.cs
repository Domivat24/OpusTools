using Mono.Cecil.Cil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private ToolTip toolTipEnter = new ToolTip();
        private ToolTip toolTipDragDrop = new ToolTip();

        public UC_Settings(Form1 parent)
        {
            InitializeComponent();
            ParentForm = parent;
            volumeBar.Value = (int)(Form1.backgroundMusic.Volume * 100f);
            _cultureManager = new CultureManager<UC_Settings>(this);
            rm = _cultureManager.rm;
            languageBox.Items.Add(rm.GetString("languageEn"));
            languageBox.Items.Add(rm.GetString("languageEs"));
            languageBox.SelectedIndex = Properties.Settings.Default.CultureInfo == "en" ? 0 : 1;
            textBoxDirectory.Text = Properties.Settings.Default.GamePath;


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
                        var response = await client.GetAsync(@"https://api.github.com/repos/Domivat24/OpusTools/releases?per_page=1");

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseContent);
                            var releases = JsonConvert.DeserializeObject<List<GitHubRelease>>(responseContent);

                            var latestRelease = releases.FirstOrDefault();



                            var latestVersion = new Version(latestRelease.TagName.Substring(1, latestRelease.TagName.Length - 1));
                            // in case there is no releases section as of development phase

                            Console.WriteLine(latestRelease.TagName);
                            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);

                            if (latestVersion > Assembly.GetExecutingAssembly().GetName().Version)
                            {
                                var downloadUrl = latestRelease.Assets.FirstOrDefault()?.BrowserDownloadUrl;
                                DialogResult dialogResult = MessageBox.Show(rm.GetString("messageNewVersion"), rm.GetString("captionNewVersion"), MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    using (var downloadClient = new HttpClient())
                                    {
                                        var downloadResponse = await downloadClient.GetAsync(downloadUrl);
                                        if (downloadResponse.IsSuccessStatusCode)
                                        {
                                            var fileName = Path.GetFileName(downloadUrl);
                                            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OpusTool_" + latestRelease.TagName + ".exe");

                                            using (var fileStream = File.Create(filePath))
                                            {
                                                var downloadStream = await downloadResponse.Content.ReadAsStreamAsync();
                                                await downloadStream.CopyToAsync(fileStream);
                                            }

                                            var currentProcess = Process.GetCurrentProcess();
                                            var startInfo = new ProcessStartInfo
                                            {
                                                FileName = filePath,
                                                UseShellExecute = true,
                                                WorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
                                            };
                                            Process.Start(startInfo);

                                            // Exit the current application
                                            currentProcess.CloseMainWindow();
                                            currentProcess.Close();
                                            File.Delete(Assembly.GetEntryAssembly().Location);
                                            Environment.Exit(0);
                                        }
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show(rm.GetString("messageNoVersion"), rm.GetString("captionNoVersion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // Display an error message if the new release package does not contain an executable file
                            MessageBox.Show("Failed to find an executable file in the new release package.", rm.GetString("generalErrorCaption"));
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("{0} {1}", rm.GetString("generalError"), ex.ToString()), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show(rm.GetString("messageNoInternet"), rm.GetString("captionNoInternet"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                switch (comboBox.SelectedIndex)
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

        private void textBoxDirectory_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GamePath = textBoxDirectory.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxDirectory_DragEnter(object sender, DragEventArgs e)
        {
            var textBox = (TextBox)sender;
            var effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path) && Directory.Exists(Path.Combine(path, "OPUS Rocket of Whispers_data")))
                {
                    effects = DragDropEffects.Copy;
                }
            }
            e.Effect = effects;
            if (e.Effect == DragDropEffects.None)
            {
                toolTipDragDrop.Active = true;
                toolTipDragDrop.Show(rm.GetString("toolTipDragDrop"), textBox, 0, -20);
            }
        }

        private void textBoxDirectory_MouseEnter(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            toolTipEnter.Active = true;
            if (string.IsNullOrEmpty(toolTipEnter.GetToolTip(textBox)))
            {
                toolTipEnter.Show(rm.GetString("toolTipEnter"), textBox, 0, -20);
            }


        }

        private void textBoxDirectory_MouseLeave(object sender, EventArgs e)
        {
            toolTipEnter.Active = false;
        }

        private void textBoxDirectory_DragLeave(object sender, EventArgs e)
        {
            toolTipDragDrop.Active = false;
        }

        private void textBoxDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            Console.WriteLine(string.IsNullOrEmpty(Properties.Settings.Default.GamePath));
            folderDialog.InitialDirectory = string.IsNullOrEmpty(Properties.Settings.Default.GamePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : Properties.Settings.Default.GamePath;
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.Description = rm.GetString("toolTipDragDrop");
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Path.Combine(folderDialog.SelectedPath, "OPUS Rocket Of Whispers_Data")))
                {
                    textBoxDirectory.Text = folderDialog.SelectedPath;
                    return;
                }
                MessageBox.Show(rm.GetString("gameNotFound"), rm.GetString("captionGameNotFound"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}