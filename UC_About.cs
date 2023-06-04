using System.Resources;
using System.Net.NetworkInformation;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Diagnostics;
using Microsoft.Web.WebView2.Core;

namespace OpusTool
{
    public partial class UC_About : UserControl
    {
        private CultureManager<UC_About> _cultureManager;
        private ResourceManager rm;
        private static Timer timer;
        private Uri previousWebViewSource;

        public UC_About()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<UC_About>(this);
            _cultureManager.updateCurrentControlCulture();
            rm = _cultureManager.rm;
            webView.SourceChanged += WebViewSourceChanged;

            //First time checking before having to wait the timer
            if (UC_Settings.isInternetAvailable())
            {
                webView.Visible = true;
                labelNoInternet.Visible = false;
                webView.Source = new Uri(rm.GetString("webViewUrl"));
            }
            else
            {
                webView.Visible = false;
                labelNoInternet.Visible = true;
            }

            timer = new Timer(2000);
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }
        private void WebViewSourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            Invoke((MethodInvoker)(() =>
            {

                Uri currentSource = webView.Source;
                if (currentSource != previousWebViewSource)
                {
                    previousWebViewSource = currentSource;
                    if (!UC_Settings.isInternetAvailable())
                    {
                        webView.Visible = false;
                        labelNoInternet.Visible = true;
                        // Exit early if no internet connection
                        return;
                    }
                }

                webView.Visible = true;
                labelNoInternet.Visible = false;
               
            }));
        }


        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (UC_Settings.isInternetAvailable() && !webView.Visible)
            {
                Invoke((MethodInvoker)(() =>
                {
                    webView.Visible = true;
                    labelNoInternet.Visible = false;
                    webView.Source = new Uri(rm.GetString("webViewUrl"));
                }));
            }
            else if (webView.Source != previousWebViewSource)
            {
                Invoke((MethodInvoker)(() =>
                {
                    webView.Visible = false;
                    labelNoInternet.Visible = true;
                }));
            }
        }
    }
}