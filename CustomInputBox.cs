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
using System.Globalization;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpusTool
{
    public partial class CustomInputBox : Form
    {
        private CultureManager<CustomInputBox> _cultureManager;
        private ResourceManager rm;
        public int languageOriginalIndex;
        public int languageCommentIndex;
        public string projectId;
        public string projectEmail;
        public string languageCode;
        public CustomInputBox()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<CustomInputBox>(this);
            rm = _cultureManager.rm;
            _cultureManager.updateCurrentControlCulture();
            languageListOriginal.Items.Clear();
            languageListOriginal.Items.Add(rm.GetString("languageCHT"));
            languageListOriginal.Items.Add(rm.GetString("languageEn"));
            languageListOriginal.Items.Add(rm.GetString("languageJP"));
            languageListOriginal.Items.Add(rm.GetString("languageCHS"));
            languageListOriginal.Items.Add(rm.GetString("languageJPSWITCH"));
            languageListOriginal.Items.Add(rm.GetString("languageKR"));
            languageListComment.Items.Clear();
            languageListComment.Items.Add(rm.GetString("languageCHT"));
            languageListComment.Items.Add(rm.GetString("languageEn"));
            languageListComment.Items.Add(rm.GetString("languageJP"));
            languageListComment.Items.Add(rm.GetString("languageCHS"));
            languageListComment.Items.Add(rm.GetString("languageJPSWITCH"));
            languageListComment.Items.Add(rm.GetString("languageKR"));
            languageListComment.Items.Add(rm.GetString("labelNoComment"));

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if(!validateData())
            {
                this.DialogResult= DialogResult.None;
            }

        }
        private bool validateData()
        {
            if(string.IsNullOrEmpty(textBoxProjectID.Text) || languageListComment.SelectedIndex==-1 || languageListOriginal.SelectedIndex==-1 || string.IsNullOrEmpty(textBoxLanguage.Text))
            {
                MessageBox.Show(rm.GetString("messageFillError"), rm.GetString("captionFillError"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            languageCode = textBoxLanguage.Text;
            languageOriginalIndex= languageListOriginal.SelectedIndex;
            languageCommentIndex= languageListComment.SelectedIndex;
            projectEmail = textBoxEmail.Text;
            projectId = textBoxProjectID.Text;
            //if the code is correct, then the configuration is over, and if it's not, returns false
            return validateISOLanguageCode();

        }
        private bool validateISOLanguageCode()
        {
            try
            {
                CultureInfo.GetCultureInfo(textBoxLanguage.Text);
                return true;
            }
            catch (CultureNotFoundException)
            {
                MessageBox.Show(rm.GetString("messageLanguageError"), rm.GetString("generalErrorCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                    OpenUrl("http://www.lingoes.net/en/translator/langcode.htm");
                return false;
            }
        }
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
