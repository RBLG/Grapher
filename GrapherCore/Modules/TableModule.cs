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

        public IInputScale Wscale { get => Table.Wscale; set { Table.Wscale = value; /**UpdateUniqueScales();*/ } }
        public IInputScale Lscale { get => Table.Lscale; set { Table.Lscale = value; /**UpdateUniqueScales();*/ } }
        public IOutputScale Hscale { get => Table.Hscale; set { Table.Hscale = value; /**UpdateUniqueScales();*/ } }

        public TableModule()
        {
            //UpdateUniqueScales();
        }

        public virtual Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed)
        {
            Spectrum buffer = Input.GetSpectrum(time, timeoff, bpitch, seed);
            foreach (Wave w in buffer.Waves)
            {
                Table.Apply(w, buffer);
            }
            return buffer;
        }

        /// <summary>
        /// non null if width or length is a time scale
        /// </summary>
        //private ITimeScale? timescale;

        /// <summary>
        /// in case of scale with specific properties, store a casted ref separately for convenience.
        /// for example time scales with envelloppe handling
        /// </summary>
        //private void UpdateUniqueScales()
        //{
        //    CandidateForUniqueScale(Table.Wscale);
        //    CandidateForUniqueScale(Table.Lscale);
        //}

        //private void CandidateForUniqueScale(IScaleCore scale)
        //{
        //    if (scale is ITimeScale tscale)
        //    { timescale = tscale; }
        //    //else if(...){...}
        //}

        /// <summary>
        /// 
        /// </summary>
        public virtual UserControl? GetControl()
        { this.Table.UpdateAll(); return new Graph3DEditor(this); }

        public String Name { get; set; } = "Editor " + count++;
        private static int count = 0;

        public virtual void SetInput(IModule input)
        { Input = input; }

    }
}
