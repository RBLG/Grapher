using Grapher.Scale;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "running")
            { button1.Text = "running"; }
            else
            { button1.Text = "test"; }
            StartStopSineWave();
        }

        private WaveOut? waveOut;
        public static readonly int samplerate = 44000;//32kHz
        public static readonly int channels = 1;//mono

        public void Graph3DEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("pressed");
            StartStopSineWave();
        }

        private void StartStopSineWave()
        {
            if (waveOut == null)
            {
                Console.WriteLine("start");
                var output = new OutputWaveProvider32(mainSettings1.shared);
                output.SetWaveFormat(samplerate, channels);
                waveOut = new WaveOut();
                waveOut.Init(output);
                waveOut.Play();
            }
            else
            {
                Console.WriteLine("stop");
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private readonly MidiNoteScale midi = new();

        private void NoteUpDown_ValueChanged(object sender, EventArgs e)
        { UpdatePitch(); }

        private void Detuner_Scroll(object sender, EventArgs e)
        { UpdatePitch(); }

        private void UpdatePitch()
        {
            mainSettings1.shared.Pitch = midi.Unscale((double)NoteUpDown.Value + (mainSettings1.Detuner.Value / 100d));
        }



    }
}
