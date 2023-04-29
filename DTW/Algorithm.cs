using audioCrackerBis.Decoder;
using audioCrackerBis.DTW.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.DTW
{
    public class Algorithm
    {

        private IMetric metric { get; set; }

        public Algorithm() {
            this.metric = new DirectMetric();
        }


        public Task<float> ConductAlgorithm(
            FileModel model1,
            FileModel model2
            )
        {
            return Task.Run(() =>
            {
                //return 400.0f;
                return this.ConductDTW(model1, model2);
            });
        }

        //private SignalMapping ConductDTW(FileModel model1, FileModel model2)
        //{
            
        //    var cMatrix = BuildCostMatrix(model1, model2);

        //    var dtwMatrix = BuildDTWMatrix(cMatrix, model1.Amps.Count, model2.Amps.Count);

        //    var mapping = RetrieveMappingFromDTW(dtwMatrix, model1.Amps.Count, model2.Amps.Count);

        //    return mapping;
        //}

        private float ConductDTW(FileModel model1, FileModel model2)
        {

            var cMatrix = BuildCostMatrix(model1, model2);

            var dtwMatrix = BuildDTWMatrix(cMatrix, model1.Amps.Count, model2.Amps.Count);

            return dtwMatrix[model1.Amps.Count - 1, model2.Amps.Count - 1];
        }


        private float[,] BuildCostMatrix(FileModel model1, FileModel model2)
        {
            var cMatrix = new float[model1.Amps.Count, model2.Amps.Count];

            for (int i = 0; i < model1.Amps.Count; i++)
            {
                for (int j = 0; j < model2.Amps.Count; j++)
                {
                    cMatrix[i, j] = this.metric.GetDistance(model1.Amps[i], model2.Amps[j]);
                }
            }

            return cMatrix;
        }

        private float[,] BuildDTWMatrix(float[,] cMatrix, int n, int m)
        {
            var dtwMatrix = new float[n, m];

            // fill first row and column
            var currSum = 0.0f;
            for (int i = 0; i < n; i++)
            {
                currSum += cMatrix[i, 0];

                dtwMatrix[i, 0] = currSum;
            }
            currSum = 0.0f;
            for (int j = 0; j < m; j++)
            {
                currSum += cMatrix[0, j];

                dtwMatrix[0, j] = currSum;
            }

            // recurrent filling rest of dtw
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    dtwMatrix[i, j] = Math.Min(
                        dtwMatrix[i - 1, j - 1],
                        Math.Min(dtwMatrix[i - 1, j],
                        dtwMatrix[i, j - 1]
                        )) + cMatrix[i, j];
                }
            }

            return dtwMatrix;
        }

        private SignalMapping RetrieveMappingFromDTW(float[,] dtwMatrix, int n, int m)
        {
            SignalMapping mapping = new SignalMapping();

            mapping.AppendMatch(n - 1, m - 1);

            int currentX = n - 1;
            int currentY = m - 1;

            while (currentX > 0 && currentY > 0)
            {
                // diagonal
                if (dtwMatrix[currentX - 1, currentY - 1] <= dtwMatrix[currentX - 1, currentY]
                    && dtwMatrix[currentX - 1, currentY - 1] <= dtwMatrix[currentX, currentY - 1])
                {
                    currentX--;
                    currentY--;
                }
                // over x
                else if (dtwMatrix[currentX - 1, currentY] < dtwMatrix[currentX, currentY - 1])
                {
                    currentX--;
                    
                }
                // over y
                else
                {
                    currentY--;
                }

                mapping.AppendMatch(currentX, currentY);
            }

            while (currentX > 0)
            {
                currentX--;

                mapping.AppendMatch(currentX, currentY);
            }
            while (currentY > 0)
            {
                currentY--;

                mapping.AppendMatch(currentX, currentY);
            }

            return mapping;
        }

    }
}
