using Grapher.GuiElement;
using Grapher.Modes;
using Grapher.Modules;
using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher
{
    public class TableModule : IModule
    {
        public IModule Input { get; set; } = new DefaultPitchModule();
        public Table MTable { get; set; } = new Table();
        public IMode Mode { get; set; } = new MultiplyProcesser();

        private IScale wscale = new ExponantialFrequencyScale();
        private IScale lscale = new LoopingTimeScale();
        private IScale hscale = new LinearAmplitudeScale();
        public IScale Wscale { get => wscale; set { wscale = value; UpdateUniqueScales(); } }
        public IScale Lscale { get => lscale; set { lscale = value; UpdateUniqueScales(); } }
        public IScale Hscale { get => hscale; set { hscale = value; UpdateUniqueScales(); } }

        public TableModule()
        {
            UpdateUniqueScales();
        }

        public virtual Spectrum GetSpectrum(double time, double timeoff, double bpitch)
        {
            Spectrum buffer = Input.GetSpectrum(time, timeoff, bpitch);
            foreach (Wave w in buffer.Waves)
            {
                //TODO implement the effect of IScale.IsContinuous
                //TODO remove the convertion to 01 by using ScaleTo
                double wval = Wscale.ScaleTo01(Wscale.PickValue(w, time, buffer));
                double lval = Lscale.ScaleTo01(Lscale.PickValue(w, time, buffer));

                //TODO and replace by Get01ValueFromWL
                double tval = MTable.Get01ValueFrom0101(wval, lval);

                double hval = Hscale.Scale(Hscale.PickValue(w, time, buffer));
                hval = Hscale.Unscale(Mode.Process(hval, tval));
                Hscale.SetValue(hval, w, time, buffer);
            }
            return buffer;
        }

        /// <summary>
        /// non null if width or length is a time scale
        /// </summary>
        private ITimeScale? timescale;

        /// <summary>
        /// in case of scale with specific properties, store a casted ref separately for convenience.
        /// for example time scales with envelloppe handling
        /// </summary>
        private void UpdateUniqueScales()
        {
            CandidateForUniqueScale(wscale);
            CandidateForUniqueScale(lscale);
        }

        private void CandidateForUniqueScale(IScale scale)
        {
            if (scale is ITimeScale tscale)
            { timescale = tscale; }
            //else if(...){...}
        }

        public virtual UserControl? GetControl()
        { return new Graph3DEditor(this); }

        public String Name { get; set; } = "Editor " + count++;
        private static int count = 0;

        public virtual void SetInput(IModule input)
        { Input = input; }

        public EnvStatus IsOver(double time, double timeoff)
        {
            var status1 = Input.IsOver(time, timeoff); //timescale could be defaulted to hide the need to handle null
            var status2 = (timescale == null) ? EnvStatus.NotHandled : timescale.GetEnvStatus(time, timeoff);
            return status1 | status2;
        }
    }
}
