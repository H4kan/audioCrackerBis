using audioCracker.Decoder;
using audioCrackerBis.Decoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioCrackerBis.DetectEngine
{
    public class Engine
    {

        private MassReader massReader = new MassReader();

        public Engine() { 
        }


        public void RunEngine()
        {
            var model = massReader.ReadFromDirectory("C:\\Users\\Szymon\\Desktop\\Znormalizowane");


        }
    }
}
