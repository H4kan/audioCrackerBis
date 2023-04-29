using audioCracker.Decoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.Decoder
{
    public class MassReader
    {
        private WavDecoder decoder = new WavDecoder();


        public DirectoryModel ReadFromDirectory(string path)
        {
            var files = Directory.GetFiles(path);

            var model = new DirectoryModel();

            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file);

                if (fileInfo.Extension != ".wav") continue;

                var name  = fileInfo.Name.Split("_")[0];

                if (!model.Model.TryGetValue(name, out _))
                {
                    var fModel = new FileModel();

                    fModel.Name = name;
                    fModel.Amps = this.decoder.ReadAmplitudesFromFile(fileInfo.FullName).ToList();
                      

                    model.Model[name] = fModel;
                }
            }

            return model;
        }

    }
}
