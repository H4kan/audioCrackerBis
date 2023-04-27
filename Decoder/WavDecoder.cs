using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace audioCracker.Decoder
{
    public class WavDecoder
    {
        
        public IEnumerable<float> ReadAmplitudesFromFile(string path)
        {
            string fileName = path;
            var soundFile = new FileInfo(fileName);
            return Normalize(AmplitudesFromFile(soundFile));
        }

        // https://stackoverflow.com/questions/19896149/read-in-a-wav-file-and-get-amplitudes
        private IEnumerable<float> AmplitudesFromFile(FileInfo soundFile)
        {
            var reader = new AudioFileReader(soundFile.FullName);
            int count = 4096; // arbitrary
            float[] buffer = new float[count];
            int offset = 0;
            int numRead = 0;
            while ((numRead = reader.Read(buffer, offset, count)) > 0)
            {
                foreach (float amp in buffer.Take(numRead))
                {
                    yield return amp;
                }
            }
        }

        private IEnumerable<float> Normalize(IEnumerable<float> amplitudes)
        {
            var max = amplitudes.Select(a => Math.Abs(a)).Max();

            return amplitudes.Select(a => a / max);
        }
    }
}
