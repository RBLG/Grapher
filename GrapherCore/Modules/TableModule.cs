using Grapher.Modes;
using Grapher.Scale;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class TableModule : IModule
    {
        public IModule Input { get; set; } = new DefaultPitchModule();

        [JsonInclude]
        public Table Table { get; private set; } = new Table();//the grid handler

        public IInputScale Wscale { get => Table.Wscale; set { Table.Wscale = value; UpdateUniqueScales(); } }
        public IInputScale Lscale { get => Table.Lscale; set { Table.Lscale = value; UpdateUniqueScales(); } }
        public IOutputScale Hscale { get => Table.Hscale; set { Table.Hscale = value; UpdateUniqueScales(); } }

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
                //double wval = Wscale.PickValueTo(w, buffer, Table.Width);
                //double lval = Lscale.PickValueTo(w, buffer, Table.Length);
                //double tval = Table.Get01ValueFromWL(wval, lval);
                //Hscale.ProcessValue(w, buffer, Table.Height, Table.Mode, tval);

                Table.Apply(w, buffer);
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
            CandidateForUniqueScale(Table.Wscale);
            CandidateForUniqueScale(Table.Lscale);
        }

        private void CandidateForUniqueScale(IScaleCore scale)
        {
            if (scale is ITimeScale tscale)
            { timescale = tscale; }
            //else if(...){...}
        }

        public virtual UserControl? GetControl()
        { this.Table.UpdateAll(); return new Graph3DEditor(this); }

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
