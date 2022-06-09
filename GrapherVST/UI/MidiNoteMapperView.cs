using Grapher;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrapherVST.UI
{
    /// <summary>
    /// The plugin custom editor UI.
    /// </summary>
    internal sealed partial class MidiNoteMapperView : UserControl
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public MidiNoteMapperView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Contains a queue with note-on note numbers currently playing.
        /// </summary>
        //public Queue<byte>? NoteOnEvents { get; set; }

        /// <summary>
        /// Updates the UI with the <see cref="NoteOnEvents"/>.
        /// </summary>
        public void ProcessIdle()
        {
            //if (NoteOnEvents != null &&
            //    NoteOnEvents.Count > 0)
            //{
            //    byte noteNo;

            //    lock (((ICollection)NoteOnEvents).SyncRoot)
            //    { noteNo = NoteOnEvents.Dequeue(); }
            //    SelectNoteMapItem(noteNo);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = new();
            form.Show();
        }
    }
}
