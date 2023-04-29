using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace audioCrackerBis.Record
{
    public class Recorder
    {

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public bool IsRecording { get; private set; }

        public System.Windows.Forms.Timer timer { get; private set; }

        public Recorder() { 
            
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 1000;
        }

        public void StartRecording()
        {
            this.IsRecording = true;

            this.timer.Start();

            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
        }

        public string StopRecording()
        {
            this.IsRecording = false;

            this.timer.Stop();

            var targetPath = Directory.GetCurrentDirectory() + "\\record.wav";
            record($"save recsound {targetPath}", "", 0, 0);
            record("close recsound", "", 0, 0);
            return targetPath;
        }

    }
}
