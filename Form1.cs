using audioCracker.Decoder;
using audioCrackerBis.Decoder;
using audioCrackerBis.DetectEngine;
using audioCrackerBis.Representation;

namespace audioCrackerBis
{
    public partial class Form1 : Form
    {
        private Engine engine = new Engine();
        private PlotBuilder plotBuilder;

        private FolderBrowserDialog dictFileDialog = new FolderBrowserDialog();
        private OpenFileDialog targetFileDialog = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();

            this.targetFileDialog.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*;";
            this.plotBuilder = new PlotBuilder(this.corrPlot);
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
                    this.bestLabel.Text = $"Best matching: {datas.First().Name}";
                    this.plotBuilder.DisplayData(datas);
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
    }
}