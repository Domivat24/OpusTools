using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpusTool
{
    public partial class UC_About : UserControl
    {
        private CultureManager<UC_About> _cultureManager;
        public UC_About()
        {
            InitializeComponent();
            _cultureManager = new CultureManager<UC_About>(this);
        }
    }
}
