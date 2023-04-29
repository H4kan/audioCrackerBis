using audioCracker.Decoder;
using audioCrackerBis.Decoder;
using audioCrackerBis.DetectEngine;
using audioCrackerBis.Record;
using audioCrackerBis.Representation;

namespace audioCrackerBis
{
    public partial class Form1 : Form
    {
        private Engine engine = new Engine();
        private PlotBuilder plotBuilder;

        private FolderBrowserDialog dictFileDialog = new FolderBrowserDialog();
        private OpenFileDialog targetFileDialog = new OpenFileDialog();

        private Recorder recorder = new Recorder();

        private long currentMs = 0;

        public Form1()
        {
            InitializeComponent();

            this.targetFileDialog.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*;";
            this.plotBuilder = new PlotBuilder(this.corrPlot);

            this.recorder.timer.Tick += new EventHandler(TimerTick);
        }

        private void dictSelectBtn_Click(object sender, EventArgs e)
        {
            if (this.dictFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(this.dictFileDialog.SelectedPath))
                {
                    this.numOfWordsLabel.Text = $"Num of words: {this.engine.SetupModel(this.dictFileDialog.SelectedPath)}";
                    this.numOfWordsLabel.Show();
                    this.RefreshAnalysisButton();
                }

            }
        }

        private void selectTargetBtn_Click(object sender, EventArgs e)
        {
            if (this.targetFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fName = this.engine.SetupTarget(this.targetFileDialog.FileName);
                this.filenameLabel.Text = fName;
                this.filenameLabel.Show();
                this.RefreshAnalysisButton();
            }
        }

        private void analyzeBtn_Click(object sender, EventArgs e)
        {
            this.bestLabel.Text = $"Loading...";
            this.bestLabel.Show();
            this.LockUI();
            Task.Run(() =>
            {
                var datas = engine.RunEngine((int)this.frameCountUpDown.Value);

                this.Invoke(new Action(() =>
                {
                    this.plotBuilder.DisplayData(datas);
                    this.bestLabel.Text = $"Best matching: {datas.First().Name}";
                    this.LockUI(false);
                }));
            });
        }

        private void LockUI(bool locked = true)
        {
            this.analyzeBtn.Enabled = !locked;
            this.dictSelectBtn.Enabled = !locked;
            this.selectTargetBtn.Enabled = !locked;
            this.recordBtn.Enabled = !locked;
            this.frameCountUpDown.Enabled = !locked;
        }

        private void RefreshAnalysisButton()
        {
            this.analyzeBtn.Enabled = this.engine.IsReady();
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (this.recorder.IsRecording)
            {
                var targetPath = this.recorder.StopRecording();

                this.engine.SetupTarget(targetPath);

                this.recordBtn.Text = "Record";

                this.RefreshAnalysisButton();
            }
            else
            {
                this.currentMs = 0;
                this.durationLabel.Show();
                this.recorder.StartRecording();
                this.recordBtn.Text = "Stop";
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var nextCurrent = this.currentMs + 1000;

            this.durationLabel.Text = String.Format("{0:D2}:{1:D2}", currentMs / 60000, (currentMs / 1000) % 60);

            this.currentMs = nextCurrent;

        }
    }
}