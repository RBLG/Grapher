﻿using Grapher.GuiElement.ScaleSettings;
using Grapher.Modules;
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
    /// <summary>
    /// default time scale in milliseconds
    /// </summary>
    public class TimeLinearScale : IInputScale, ITimeScale
    {
        public double Duration { get; set; } = 1000; //duration of the table (in millis)
        public double Hold { get; set; } = 500; //if not looping, time where it wait the release event

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new TimeLinearGui(this);

        public string Label => "t(ms)";

        public bool Continuous => true;

        public bool IsLooping { get; set; } = true;


        public double PickValueTo(Wave wave, Spectrum spectrum, uint size)
        {
            double rtn = spectrum.SourceTime;
            if (IsLooping)
            {
                rtn /= Duration;
                rtn -= (int)rtn;//%= 1;//another faster modulo
            }
            else
            {
                //need a better way to handle when release happen before time reached hold
                // -> get closest pre hold index after release, reach it then interpolate on the next

                if (double.IsNaN(spectrum.TimeOff))
                { rtn = Math.Min(rtn, Hold); }
                else
                {
                    //if release event happenned before time reached the hold, use time instead of timeoff
                    rtn = Math.Min(spectrum.SourceTime, Hold + spectrum.TimeOff);
                    rtn = Math.Min(rtn, Duration - 1); //-1 because weird stuff happen at duration value, will check later
                }
                rtn /= Duration;
            }
            return rtn * size;
        }

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size) {
            double rtn = spectrum.SourceTime;
            if (IsLooping)
            {
                rtn /= Duration;
                rtn -= (int)rtn;//%= 1;//another faster modulo
                rtn *= size;
                return TableModule.PrepareInterpolation(rtn, size, IsLooping);
            }
            else
            {
                //need a better way to handle when release happen before time reached hold
                // -> get closest pre hold index after release, reach it then interpolate on the next

                if (double.IsNaN(spectrum.TimeOff))
                {
                    rtn = Math.Min(rtn, Hold);
                    rtn /= Duration;
                    rtn *= size;
                    return TableModule.PrepareInterpolation(rtn, size, IsLooping);
                }
                else
                {
                    double release = spectrum.SourceTime - spectrum.TimeOff;//remove calculations by having release time in wave?
                    if (release < Hold)
                    {
                        double realease = release - release % (Duration / size);
                        if (spectrum.SourceTime < realease)
                        {
                            double time1 = spectrum.SourceTime * size / Duration;
                            uint index1 = (uint)time1;
                            uint index2 = (uint)((Hold + spectrum.TimeOff) * size / Duration);
                            double mix = time1 - index1;

                            return (index1, index2, mix);
                        }
                    }

                    rtn = Hold + spectrum.TimeOff;

                    rtn = Math.Min(rtn, Duration - 1); //-1 because weird stuff happen at duration value, will check later
                    rtn /= Duration;
                    rtn *= size;
                    return TableModule.PrepareInterpolation(rtn, size, IsLooping);
                }

            }
        }

    }
}
