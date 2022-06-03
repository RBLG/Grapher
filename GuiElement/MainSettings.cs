﻿using Grapher.Modules;
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

        private void button1_Click(object sender, EventArgs e)
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

        private WaveOut waveOut;
        private SharedStuff shared = new SharedStuff(440, new DefaultPitchModule());

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
                output.SetWaveFormat(Canvas3D.samplerate, 1); // 16kHz mono
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

        private MidiNoteScale midi = new MidiNoteScale();

        private IModule Input { get => shared.Module; set => shared.Module = value; }

        private ModuleForm mform = null;

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            var control = Input.GetControl();
            if (control != null &&( mform == null || mform.IsDisposed))
            {
                ModuleForm moduleform = new ModuleForm(control, Input.GetName());
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
            shared.Pitch = midi.GetUnscaled((int)NoteUpDown.Value);
        }
    }
}
