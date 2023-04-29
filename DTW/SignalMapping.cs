using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.DTW
{
    public class SignalMapping
    {
        private List<(int, int)> mapping { get; set; }

        public SignalMapping() { 
            this.mapping = new List<(int, int)> ();
        }

        public int GetMatchingSecond(int first)
        {
            return mapping.Where(x => x.Item1 == first).First().Item2;
        }

        public int GetMatchingFirst(int second)
        {
            return mapping.Where(x => x.Item2 == second).First().Item1;
        }

        public void AppendMatch(int first, int second)
        {
            mapping.Add((first, second));
        }

    }
}
