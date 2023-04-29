using audioCracker.Decoder;
using audioCrackerBis.Decoder;
using audioCrackerBis.DTW;
using audioCrackerBis.Representation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.DetectEngine
{
    public class Engine
    {

        private MassReader massReader = new MassReader();

        private DirectoryModel directoryModel;
        private FileModel targetModel;

        private WavDecoder wavDecoder = new WavDecoder();

        public Engine() { 
        }

        public int SetupModel(string path)
        {
            this.directoryModel = massReader.ReadFromDirectory(path);
            return this.directoryModel.Model.Keys.Count;
        }

        public string SetupTarget(string path)
        {
            this.targetModel = new FileModel();
            this.targetModel.Name = "target";

            this.targetModel.Amps = this.wavDecoder.ReadAmplitudesFromFile(path).ToList();

            return new FileInfo(path).Name;
        }

        public bool IsReady()
        {
            return targetModel != null && directoryModel != null;
        }


        public IEnumerable<PlotValue> RunEngine(int framesCount)
        {
            var model = ProcessModel(framesCount);
            var algorithm = new Algorithm();

            var tasks = model.GetLabels().Select(name =>
            {
                return (name, algorithm.ConductAlgorithm(model.GetFileModel(name), targetModel));
            });

            Task.WaitAll(tasks.Select(t => t.Item2).ToArray());

            return tasks.Select(t => new PlotValue() { Name = t.name, Value = t.Item2.Result })
                .OrderBy(t => t.Value);
           
        }

        private DirectoryModel ProcessModel(int framesCount)
        {
            var model = new DirectoryModel();
            foreach (var key in this.directoryModel.Model.Keys)
            {
                model.Model[key] = ProcessFileModel(this.directoryModel.Model[key], framesCount);
            }

            return model;
        }

        private FileModel ProcessFileModel(FileModel fileModel, int framesCount)
        {
            var model = new FileModel();
            model.Name = fileModel.Name;

            model.Amps = this.wavDecoder.DivideIntoFrames(model.Amps, framesCount).Select(f => f.Average()).ToList();

            return model;
        }
    }
}
