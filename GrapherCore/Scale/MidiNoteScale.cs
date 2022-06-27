using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    //not usable rn, just there to stock what i know so far about midi format
    public class MidiNoteScale : IInputScale
    {
        public enum Note
        {
            C1, D1, E1, F1, A1, B1,//
            C2, D2, E2, F2, A2, B2,//
            C3, D3, E3, F3, A3, B3,//
            C4, D4, E4, F4, A4, B4,//
            C5, D5, E5, F5, A5, B5,//
            C6, D6, E6, F6, A6, B6,//
            C7, D7, E7, F7, A7, B7,
        }
        public static readonly double STANDARD_PITCH = 440;

        public double Max => 127;
        public double Min => 0;

        public double BaseFrequency { get; set; }

        public MidiNoteScale(double basefreq)
        {
            BaseFrequency = basefreq;
        }

        public MidiNoteScale() : this(STANDARD_PITCH) { }


        public double Scale(double notscaled)
        {
            return Math.Log(2, notscaled / BaseFrequency) * 12 + 69;
        }
        public double Unscale(double scaled)//?
        {
            return BaseFrequency * Math.Pow(2, ((scaled - 69) / 12d));
        }

        public double ScaleTo01(double notscaled)
        {
            return Scale(notscaled) / Max;
        }
        public double UnscaleFrom01(double scaled)
        {
            return Unscale(scaled * Max);
        }

        public double ScaleTo(double notscaled, double size)
        {
            return ScaleTo01(notscaled) * size;
        }
        public double UnscaleFrom(double scaled, double size)
        {
            return UnscaleFrom01(scaled / size);
        }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Frequency, size); }
        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.BlankScaleGui();
        }

        public bool Continuous => false;
        public string Label => "midi notes";
    }
}
