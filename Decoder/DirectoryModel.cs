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
        public Dictionary<string, FileModel>? Model = new Dictionary<string, FileModel>();

        public FileModel GetFileModel(string key)
        {
            if (Model == null || Model[key] == null)
            {
                throw new Exception("Audio data not exist");
            }
            return Model[key];
        }

        public IEnumerable<string> GetLabels()
        {
            return Model.Keys;
        }
    }


    public class FileModel
    {
        public string? Name { get; set; }


        public List<float> Amps { get; set; }

    }
}
