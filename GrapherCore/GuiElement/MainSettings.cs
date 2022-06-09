using Grapher.Modules;
using Grapher.Scale;
using Grapher.SoundProcessing;
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

namespace Grapher.GuiElement
{
    public partial class MainSettings : UserControl
    {
        public MainSettings()
        {
            InitializeComponent();

            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            InputComboBox.SelectedIndex = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "running")
            {
                button1.Text = "running";
            }
            else
            {
                button1.Text = "start";
            }
            StartStopSineWave();
        }

        private WaveOut? waveOut;
        private SharedStuff shared = new(440, new DefaultPitchModule());
        public static readonly int samplerate = 32000;//32kHz
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
                var output = new OutputWaveProvider32(shared);
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

        private MidiNoteScale midi = new();

        private IModule Input { get => shared.Module; set => shared.Module = value; }

        private ModuleForm? mform = null;

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            var control = Input.GetControl();
            if (control != null && (mform == null || mform.IsDisposed))
            {
                ModuleForm moduleform = new(control, Input.GetName());
                mform = moduleform;
                //here: if is 3Deditor, set it input to harmonics editor
                moduleform.Show();
            }
        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            Input = item.Factory();
        }

        private void NoteUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePitch();
        }

        private void Detuner_Scroll(object sender, EventArgs e)
        {
            UpdatePitch();
        }

        private void UpdatePitch()
        {
            shared.Pitch = midi.GetUnscaled((double)NoteUpDown.Value + (Detuner.Value / 100d));
        }
    }
}
