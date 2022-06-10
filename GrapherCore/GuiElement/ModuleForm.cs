using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.GuiElement
{
    public partial class ModuleForm : Form
    {
        private UserControl Control { get; set; }

        //replace parameters by module (maybe)
        public ModuleForm(UserControl ncontrol,String name)
        {
            Control = ncontrol;
            Control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            Control.Location = new System.Drawing.Point(0, 0);
            Control.Name = "control";
            Control.Size = new System.Drawing.Size(875, 475);
            Control.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Control.TabIndex = 0;
            Text = name;
            Controls.Add(Control);
            InitializeComponent();
        }


    }
}
