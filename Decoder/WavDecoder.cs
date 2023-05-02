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

        public static int frameLenInMs = 40;
        private const float frameOverLapPercentage = 0.1F;

        public IEnumerable<float> ReadAmplitudesFromFile(string path)
        {
            string fileName = path;
            var soundFile = new FileInfo(fileName);
            return TrimEndings( 
                Normalize(
                    AmplitudesFromFile(soundFile)
                ));
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

        public IEnumerable<IEnumerable<float>> DivideIntoFrames(IEnumerable<float> amplitudes, int frameCount)
        {
            int ampsPerFrame = amplitudes.Count() / frameCount;

            int frameLeap = (int)Math.Floor((1 - frameOverLapPercentage) * ampsPerFrame);

            int startIndex = 0;

            var frames = new List<IEnumerable<float>>();

            int boundaryIndex = amplitudes.Count() - ampsPerFrame;

            while (startIndex < boundaryIndex)
            {

                frames.Add(amplitudes.Skip(startIndex).Take(ampsPerFrame));
                startIndex += frameLeap;

            }

            return frames;

        }

        private IEnumerable<float> TrimEndings(IEnumerable<float> amplitudes)
        {
            var ampL = amplitudes.ToList();
            var firstIdx = ampL.FindIndex(a => a > 0.2);
            var lastIdx = ampL.FindLastIndex(a => a > 0.2);

            return amplitudes.Skip(firstIdx).Take(lastIdx - firstIdx + 1);
        }
    }
}
