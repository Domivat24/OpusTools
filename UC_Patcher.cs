using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Net;
using System.Diagnostics;
using System.Security.Policy;
using System.IO;

namespace OpusTool
{
    public partial class UC_Patcher : UserControl
    {
        private CultureManager<UC_Patcher> _cultureManager;
        public ResourceManager rm;
        public UC_Patcher()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<UC_Patcher>(this);
            _cultureManager.updateCurrentControlCulture();
            rm = _cultureManager.rm;
        }

        private async void btnPatcher_Click(object sender, EventArgs e)
        {
            var gamePath = Properties.Settings.Default.GamePath;
            if (string.IsNullOrEmpty(gamePath) || !Directory.Exists(Path.Combine(gamePath, "Opus Rocket Of Whispers_data")))
            {
                MessageBox.Show(rm.GetString("gamePathMissing"), rm.GetString("captionGamePathMissing"), MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (!UC_Settings.isInternetAvailable())
            {
                MessageBox.Show(rm.GetString("messageNoInternet"), rm.GetString("captionNoInternet"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filePath = "path/to/file.txt";

            string urlAssembly = $"https://github.com/Domivat24/OpusTools/raw/main/Resources/Assembly-CSharp.dll";
            string urlTranslation = $"https://github.com/Domivat24/OpusTools/raw/main/Resources/translation.json";

            string assemblyDestination = Path.Combine(gamePath, "Opus Rocket of Whispers_data", "Managed", "Assembly-CSharp.dll");
            string translationDestination = Path.Combine(gamePath, "translation.json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(urlAssembly);
                    response.EnsureSuccessStatusCode();

                    using (var fileStream = new FileStream(assemblyDestination, FileMode.Create))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }

                    Debug.WriteLine("Assembly downloaded successfully!");
                    var responseJson = await client.GetAsync(urlTranslation);

                    responseJson.EnsureSuccessStatusCode();

                    using (var fileStream2 = new FileStream(translationDestination, FileMode.Create))
                    using (var writer = new StreamWriter(fileStream2))
                    {
                        var content = await responseJson.Content.ReadAsStringAsync();
                        await writer.WriteAsync(content);
                        await writer.FlushAsync();

                    }
                    Debug.WriteLine("Translation downloaded successfully!");
                    MessageBox.Show(rm.GetString("messagePatcherSuccess"), rm.GetString("captionPatcherSuccess"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("{0} {1}", rm.GetString("generalError"), ex.ToString()), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


    }
}
