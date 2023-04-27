using audioCrackerBis.DetectEngine;

namespace audioCrackerBis
{
    public partial class Form1 : Form
    {
        private Engine engine = new Engine();

        public Form1()
        {
            InitializeComponent();

            engine.RunEngine();
        }
    }
}