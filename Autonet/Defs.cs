namespace Autonet
{
    class PinDefs
    {

        public const int LeftLightW = 5 ; //<---Analog
        public const int LeftLightB = 4; //<---Analog

        public const int RightLightW = 3;    //<---Analog
        public const int RightLightB = 2; //<---Analog

        public const int MotorRF = 8;
        public const int MotorRR = 7;
        public const int MotorLF = 6;
        public const int MotorLR = 5;
        public const int MotorGU = 3;
        public const int MotorGD = 2;

        public const int LightServoL = 11; // 180 = Open, 0 = Close
        public const int LightServoR = 10; // 0 = Open, 180 = Close
        public const int GrabServoL = 9; // 180 = Open, 0 = Close
        public const int GrabServoR = 8; // 0 = Open, 180 = Close
    }

    class ConfigDefs
    {

        public const string ArduinoPort = "COM22";
        public const string LegacyPort = "COM23";

        public const int StartPoint = (int) CGraph.Points.Start1;
        public const int GrabPoint = (int)CGraph.Points.GrabStart;
       // CManuever GrabManuever = GrabManuever;
        public const int AfterGrabPoint = (int)CGraph.Points.GrabEnd;

        public const bool ParkDecision = false;
        public const int ParkPoint = (int)CGraph.Points.ParkPerpendicular;
       



    }


}
