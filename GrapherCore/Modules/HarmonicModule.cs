using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    /// <summary>
    /// a basic harmonic handling module, might be deleted later when TableModule handle generation
    /// </summary>
    public class HarmonicModule : TableModule
    {
        //to reference specific stuff of the harmonic scale, not used rn tho
        private new HarmonicScale Wscale { get; set; }
        public HarmonicModule() : base()
        {
            MTable.Length = 1;
            Wscale = new HarmonicScale();
            base.Wscale = Wscale;
            //Lscale = null;
            //Input = null;
            MTable.Interpolation = Table.InterpolationType.None;
            Name = "Harmonic " + Name;
            foreach (Table3DDot dot in MTable.dots[0])
            {
                dot.Y = Table.MIN;
            }
            MTable.dots[0][0].Y = Table.MAX;
        }

        private readonly Spectrum wavstock = new();
        private readonly Spectrum buffer = new();

        public override Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed)
        {
            UpdateStock();
            buffer.Waves.Clear();
            buffer.Time = time;
            buffer.TimeOff = timeoff;
            buffer.BasePitch = bpitch;
            buffer.NoteSeed = seed;
            int it = 0;
            foreach (Table3DDot dot in MTable.dots[0])
            {
                double wval = MTable.Get01ValueFrom0101(it / (double)MTable.Width, 0);
                if (wval > 0)
                {
                    Wave wav = wavstock.Waves[it];
                    wav.Frequency = (it + 1) * bpitch;
                    wav.Amplitude = wval / (it + 1); //temporary, it is to ensure harmonics arent too loud
                    buffer.Waves.Add(wav);
                }
                it++;
            }
            return buffer;
        }

        public override UserControl GetControl()
        {
            var control = new Graph3DEditor(this);
            control.InputComboBox.Visible = false;
            control.InputLabel.Visible = false;
            control.EditInputButton.Visible = false;
            control.numLength.Visible = false;
            control.LengthLabel.Visible = false;
            control.AxisSettingsButton.Visible = false;
            return control;
        }

        /// <summary>
        /// update the amount of waves in the buffer spectrum
        /// </summary>
        public void UpdateStock()
        {
            int goal = MTable.Width;
            int current = wavstock.Waves.Count;
            if (goal == current) { }
            else if (goal < current)
            { wavstock.Waves.RemoveRange(goal, current - goal); }
            else
            {
                for (int itx = 0; itx < goal - current; itx++)
                { wavstock.Waves.Add(new Wave(WaveType.Sinus, 0, 0)); }
            }
        }

        public override void SetInput(IModule modude)
        { return; }

    }
}
