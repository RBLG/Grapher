using Grapher.Modes;
using Grapher.Modules;
using Grapher.Scale;
using Grapher.Scale.Related;
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
    public partial class ScalesSettingsControl : UserControl
    {

        // to settup controls values in the constructor without triggering events
        private Boolean inInit = true; // readonly is unecessary but its supress a msg

        public ScalesSettingsControl()
        {
            InitializeComponent();
        }
        public ScalesSettingsControl(Graph3DEditor neditor)
        {
            Editor = neditor;
            InitializeComponent();
            ActualConstructor(neditor);
        }

        /// <summary>
        /// no idea how to pass the editor in the real constructor
        /// without breaking the windows form visual editor stuff, so its here. 
        /// calling this is mandatory
        /// </summary>
        public void ActualConstructor(Graph3DEditor neditor)
        {
            var scales = AvailableInputScales.scales;
            Editor = neditor;
            WidthComboBox.ValueMember = "Factory";
            WidthComboBox.DisplayMember = "Name";
            WidthComboBox.Items.AddRange(scales.ToArray());
            WidthComboBox.SelectedIndex = AvailableInputScales.GetIndex(WidthAxis.GetType());
            WidthComboBox.DropDownHeight = scales.Count * 20;
            oldwidth = WidthComboBox.SelectedIndex;
            WidthSocket.Set(WidthAxis.GetControl());

            LengthComboBox.ValueMember = "Factory";
            LengthComboBox.DisplayMember = "Name";
            LengthComboBox.Items.AddRange(scales.ToArray());
            LengthComboBox.SelectedIndex = AvailableInputScales.GetIndex(LengthAxis.GetType());
            LengthComboBox.DropDownHeight = scales.Count * 20;
            oldlength = LengthComboBox.SelectedIndex;
            LengthSocket.Set(LengthAxis.GetControl());

            HeightComboBox.ValueMember = "Factory";
            HeightComboBox.DisplayMember = "Name";
            HeightComboBox.Items.AddRange(AvailableOutputScales.scales.ToArray());
            HeightComboBox.SelectedIndex = AvailableOutputScales.GetIndex(HeightAxis.GetType());
            HeightComboBox.DropDownHeight = AvailableOutputScales.scales.Count * 20;
            oldheight = HeightComboBox.SelectedIndex;
            HeightSocket.Set(HeightAxis.GetControl());

            ModeComboBox.ValueMember = "Factory";
            ModeComboBox.DisplayMember = "Name";
            ModeComboBox.Items.AddRange(AvailableModes.modes.ToArray());
            ModeComboBox.SelectedIndex = AvailableModes.GetIndex(Mode.GetType());
            //ModeComboBox.DropDownHeight = AvailableModes.modes.Count * 20; useless for now
            oldmode = ModeComboBox.SelectedIndex;
            ModeSocket.Set(Mode.GetControl());
            inInit = false;
        }

        //nullable till i know better
        public Graph3DEditor? Editor { get; set; }
        private TableModule Module { get => (Editor ?? throw new NullReferenceException("null Editor in use")).canvas3D1.module; }

        private IInputScale WidthAxis { get => Module.Wscale; set => Module.Wscale = value; }
        private IInputScale LengthAxis { get => Module.Lscale; set => Module.Lscale = value; }
        private IOutputScale HeightAxis { get => Module.Hscale; set => Module.Hscale = value; }
        private IMode Mode { get => Module.Table.Mode; set => Module.Table.Mode = value; }


        private int oldwidth;
        private void WidthComboBox_Enter(object sender, EventArgs e)
        { oldwidth = WidthComboBox.SelectedIndex; }
        private void WidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; } // avoid reseting stuff if in the constructor
            var nwscale = AvailableInputScales.Get(WidthComboBox.SelectedIndex);
            var nwa = nwscale.Factory();
            if (nwa == null) // if not selectable
            { WidthComboBox.SelectedIndex = oldwidth; }
            else if (oldwidth != WidthComboBox.SelectedIndex) // if actually changed
            {
                oldwidth = WidthComboBox.SelectedIndex;
                WidthAxis = nwa;
                WidthSocket.Set(nwa.GetControl());

                Editor!.canvas3D1.Invalidate();
            }
        }

        private int oldlength;
        private void LengthComboBox_Enter(object sender, EventArgs e)
        { oldlength = LengthComboBox.SelectedIndex; }
        private void LengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var nlscale = AvailableInputScales.Get(LengthComboBox.SelectedIndex);
            var nla = nlscale.Factory();
            if (nla == null)
            { LengthComboBox.SelectedIndex = oldlength; }
            else if (oldlength != LengthComboBox.SelectedIndex)
            {
                oldlength = LengthComboBox.SelectedIndex;
                LengthAxis = nla;
                LengthSocket.Set(nla.GetControl());

                Editor!.canvas3D1.Invalidate();
            }
        }

        private int oldheight;
        private void HeightComboBox_Enter(object sender, EventArgs e)
        { oldheight = HeightComboBox.SelectedIndex; }
        private void HeightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var nha = AvailableOutputScales.Get(HeightComboBox.SelectedIndex).Factory();
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
