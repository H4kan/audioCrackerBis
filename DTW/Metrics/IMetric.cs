using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.DTW.Metrics
{
    public interface IMetric
    {

        public float GetDistance(float x, float y);
    }
}
