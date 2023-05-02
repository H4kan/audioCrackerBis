using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.Representation
{
    public class PlotBuilder
    {

        private ScottPlot.FormsPlot plot;
        private int topV = 10;

        public PlotBuilder(ScottPlot.FormsPlot plot) { 
            this.plot = plot;

            this.plot.Plot.XLabel("Phrases");
            this.plot.Plot.YLabel("DTW");
            
        }


        public void DisplayData(IEnumerable<PlotValue> data)
        {
            this.plot.Reset();
            var topData = data.Take(topV);
            var positions = Enumerable.Range(0, topData.Count())
                .Select(d => 2 * (double)d).ToArray();

            var labels = topData.Select(x => x.Name).ToArray();

            var values = topData.Select(x => x.Value).ToArray();

  

            this.plot.Plot.AddBar(values, positions);
            this.plot.Plot.XTicks(positions, labels);
            this.plot.Plot.SetAxisLimits(yMin: 0);

            this.plot.Show();

            this.plot.Refresh();
        }

        public void SavePlot(string filePath)
        {
            this.plot.Plot.Style(figureBackground: Color.White);
            var bmp = this.plot.Plot.Render();
            bmp.Save(filePath.Replace(".wav", ".jpg"));
        }
    }
}
