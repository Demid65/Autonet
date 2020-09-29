using System;
using System.Threading;
using MRI_Core_Library;

namespace Autonet
{
    class CRobot : CArduino
    {

        public CoreLegacyModule LegoController;
        public void Init(string ArduinoPort, string LegoPort)
        {
           
            LegoController = new CoreLegacyModule(LegoPort);
            Init(ArduinoPort);
        }




    }
}
