using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.Decoder
{
    public class DirectoryModel
    {
        public Dictionary<string, List<FileModel>>? Model = new Dictionary<string, List<FileModel>>();

        public IEnumerable<IEnumerable<float>> GetFileModels(string key)
        {
            if (Model == null || Model[key] == null)
            {
                throw new Exception("Audio data not exist");
            }
            return Model[key].Select(f => f.Amps);
        }

    }


    public class FileModel
    {
        public string? Name { get; set; }


        public List<float> Amps { get; set; }

    }
}
