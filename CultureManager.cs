using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace OpusTool
{
    public class CultureManager<T> where T : Control
    {
        private T tControl { get; set; }
        public ResourceManager rm { get; set; }

        public CultureManager(T control)
        {
            this.tControl = control;
            setCultureInfo();
        }
        public void updateCurrentControlCulture()
        {
            foreach (Control control in tControl.Controls)
            {
                UpdateControlText(control);
            }

        }
        //recursive task to update all the text of the buttons and labels and its childs
        private void UpdateControlText(Control control)
        {
            if (control is Label || control is Button)
            {
                control.Text = rm.GetString(control.Name);
            }
            foreach (Control childControl in control.Controls)
            {
                UpdateControlText(childControl);
            }
        }
        public void setCultureInfo()
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.CultureInfo);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            rm = new ResourceManager("OpusTool.Properties.Resources", tControl.GetType().Assembly);
        }
    }
}
