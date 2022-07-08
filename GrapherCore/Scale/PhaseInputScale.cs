﻿using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class PhaseInputScale : IInputScale
    {
        //public double Min => 0;
        //public double Max => 1;

        public string Label => "Phase";

        public List<Graduation> GetMilestones()
        {
            return new()
            {
                new Graduation("0%", 0),
                new Graduation("50%", 0.5),
                new Graduation("100%", 1)
            };
        }

        public Control GetControl() => new PhaseInputGui(this);

        public bool Continuous => true;
        public bool IsLooping => true;

        public bool IsCumulative => false;

        public bool IsAbsolute { get; set; } = true;
        public double Multiplier { get; set; } = 1;// 1/Mult; for speed
        public double Detune { get; set; } = 0;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            if (IsAbsolute)
            {
                double val = GetAbsPhase(wave, spectrum);
                val -= (int)val;//modulo
                return val * size;
            }
            else
            { return wave.Phase; }
        }

        private double GetAbsPhase(Spectrum.Wave wave, Spectrum spectrum)
        {
            return Math.Max(1, wave.Frequency + Detune) * Multiplier * (spectrum.Time / 1000 + wave.Phase);
        }
    }
}