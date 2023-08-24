using Grapher.Modes;
using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grapher.GuiElement.ScaleSettings
{
    public partial class FrequencyInputGui : UserControl
    {
        private readonly FrequencyInputScale scale;
        public FrequencyInputGui(FrequencyInputScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            UnitComboBox.DataSource = Enum.GetValues(typeof(FrequencyUnit));
            UnitComboBox.SelectedItem = scale.Unit;
        }

        private void UnitComboBox_ValueChanged2(object sender, EventArgs e)
        {
            Enum.TryParse<FrequencyUnit>(UnitComboBox.SelectedValue.ToString(), out var val);
            scale.Unit = val;
        }
    }
}
