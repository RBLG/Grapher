using Grapher.Modes;
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
    public class TableModule : IModule
    {
        public IModule Input { get; set; } = new DefaultPitchModule();
        public Table MTable { get; set; } = new Table();//the grid handler
        public IMode Mode { get; set; } = new MultiplyMode();

        private IScale wscale = new FrequencyExponantialScale();
        private IScale lscale = new TimeLinearScale();
        private IScale hscale = new AmplitudeLinearScale();
        public IScale Wscale { get => wscale; set { wscale = value; UpdateUniqueScales(); } }
        public IScale Lscale { get => lscale; set { lscale = value; UpdateUniqueScales(); } }
        public IScale Hscale { get => hscale; set { hscale = value; UpdateUniqueScales(); } }

        public TableModule()
        {
            UpdateUniqueScales();
        }

        public virtual Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed)
        {
            Spectrum buffer = Input.GetSpectrum(time, timeoff, bpitch, seed);
            foreach (Wave w in buffer.Waves)
            {
                
                //TODO implement the effect of IScale.IsContinuous
                double wval = Wscale.PickValueTo(w, buffer, MTable.Width);
                double lval = Lscale.PickValueTo(w, buffer, MTable.Length);

                double tval = MTable.Get01ValueFromWL(wval, lval);

                Hscale.ProcessValue(w, buffer, MTable.Height, Mode, tval);
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
        { this.MTable.UpdateAll(); return new Graph3DEditor(this); }

        public String Name { get; set; } = "Editor " + count++;
        private static int count = 0;

        public virtual void SetInput(IModule input)
        { Input = input; }


        /// <summary>
        /// will probably get removed
        /// </summary>
        public virtual EnvStatus IsOver(double time, double timeoff)
        {
            var status1 = Input.IsOver(time, timeoff); //timescale could be defaulted to hide the need to handle null
            var status2 = (timescale == null) ? EnvStatus.NotHandled : timescale.GetEnvStatus(time, timeoff);
            return status1 | status2;
        }
    }
}
