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
using static Grapher.Scale.AvailableScales;

namespace Grapher.GuiElement
{
    public partial class ScalesSettings : Form
    {
        // to settup controls values in the constructor without triggering events
        private readonly Boolean inInit = true; // readonly is unecessary but its supress a msg

        public ScalesSettings(Graph3DEditor neditor)
        {
            Editor = neditor;
            InitializeComponent();
            WidthComboBox.ValueMember = "Factory";
            WidthComboBox.DisplayMember = "Name";
            WidthComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            WidthComboBox.SelectedIndex = AvailableScales.GetIndex(WidthAxis.GetType());
            oldwidth = WidthComboBox.SelectedIndex;
            WidthSocket.Set(WidthAxis.GetControl());

            LengthComboBox.ValueMember = "Factory";
            LengthComboBox.DisplayMember = "Name";
            LengthComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            LengthComboBox.SelectedIndex = AvailableScales.GetIndex(LengthAxis.GetType());
            oldlength = LengthComboBox.SelectedIndex;
            LengthSocket.Set(LengthAxis.GetControl());

            HeightComboBox.ValueMember = "Factory";
            HeightComboBox.DisplayMember = "Name";
            HeightComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            HeightComboBox.SelectedIndex = AvailableScales.GetIndex(HeightAxis.GetType());
            oldheight = HeightComboBox.SelectedIndex;
            HeightSocket.Set(HeightAxis.GetControl());

            ModeComboBox.ValueMember = "Factory";
            ModeComboBox.DisplayMember = "Name";
            ModeComboBox.Items.AddRange(AvailableModes.modes.ToArray());
            ModeComboBox.SelectedIndex = AvailableModes.GetIndex(Mode.GetType());
            oldmode = ModeComboBox.SelectedIndex;
            ModeSocket.Set(Mode.GetControl());
            inInit = false;
        }
        public Graph3DEditor Editor { get; set; }
        private TableModule Module { get => Editor.canvas3D1.module; }

        private IScale WidthAxis { get => Module.Wscale; set => Module.Wscale = value; }
        private IScale LengthAxis { get => Module.Lscale; set => Module.Lscale = value; }
        private IScale HeightAxis { get => Module.Hscale; set => Module.Hscale = value; }
        private IMode Mode { get => Module.Mode; set => Module.Mode = value; }


        private int oldwidth;
        private void WidthComboBox_Enter(object sender, EventArgs e)
        { oldwidth = WidthComboBox.SelectedIndex; }
        private void WidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; } // avoid reseting stuff if in the constructor
            var nwscale = AvailableScales.Get(WidthComboBox.SelectedIndex);
            var nwa = nwscale.Factory();
            if (nwa == null) // if not selectable
            { WidthComboBox.SelectedIndex = oldwidth; }
            else if (oldwidth != WidthComboBox.SelectedIndex) // if actually changed
            {
                oldwidth = WidthComboBox.SelectedIndex;
                WidthAxis = nwa;
                WidthSocket.Set(nwa.GetControl());
            }
        }

        private int oldlength;
        private void LengthComboBox_Enter(object sender, EventArgs e)
        { oldlength = LengthComboBox.SelectedIndex; }
        private void LengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var nlscale = AvailableScales.Get(LengthComboBox.SelectedIndex);
            var nla = nlscale.Factory();
            if (nla == null)
            { LengthComboBox.SelectedIndex = oldlength; }
            else if (oldlength != LengthComboBox.SelectedIndex)
            {
                oldlength = LengthComboBox.SelectedIndex;
                LengthAxis = nla;
                LengthSocket.Set(nla.GetControl());
            }
        }

        private int oldheight;
        private void HeightComboBox_Enter(object sender, EventArgs e)
        { oldheight = HeightComboBox.SelectedIndex; }
        private void HeightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var nha = AvailableScales.Get(HeightComboBox.SelectedIndex).Factory();
            if (nha == null)
            { HeightComboBox.SelectedIndex = oldheight; }
            else if (oldheight != HeightComboBox.SelectedIndex)
            {
                oldheight = HeightComboBox.SelectedIndex;
                HeightAxis = nha;
                HeightSocket.Set(nha.GetControl());
            }
        }

        private int oldmode;
        private void ModeComboBox_Enter(object sender, EventArgs e)
        { oldmode = ModeComboBox.SelectedIndex; }
        private void ModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var nma = AvailableModes.Get(ModeComboBox.SelectedIndex).Factory();
            if (nma == null)
            { ModeComboBox.SelectedIndex = oldmode; }
            else if (oldmode != ModeComboBox.SelectedIndex)
            {
                oldmode = ModeComboBox.SelectedIndex;
                Mode = nma;
                ModeSocket.Set(nma.GetControl());
            }
        }


    }
}
