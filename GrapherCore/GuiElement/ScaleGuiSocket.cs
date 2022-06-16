using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.GuiElement.ScaleSettings
{
    public partial class ScaleGuiSocket : UserControl
    {
        public ScaleGuiSocket()
        {
            InitializeComponent();
        }

        public void Set(Control control)
        {
            this.Controls.Clear();
            this.Controls.Add(control);
            this.Invalidate();
        }
    }
}
