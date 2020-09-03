using System.Threading;
using System;
namespace Autonet
{
    class Demo : CAutonomous
    {
        public override void Run(CRobot Robot, CRecog Recog)
        {
            Robot.SetServo(PinDefs.LightServoL, 180);
            Robot.SetServo(PinDefs.LightServoR, 5);
                while (true)
                {
                if (Robot.AnalogRead(PinDefs.RightLightB) > 100 && Robot.AnalogRead(PinDefs.RightLightW) > 100)
                 Robot.SetGeneralPower(100, 25);
                if (Robot.AnalogRead(PinDefs.RightLightB) < 100 && Robot.AnalogRead(PinDefs.RightLightW) > 100)
                 Robot.SetGeneralPower(50, 60);
                if (Robot.AnalogRead(PinDefs.RightLightB) < 100 && Robot.AnalogRead(PinDefs.RightLightW) < 100)
                 Robot.SetGeneralPower(25, 100);
                if (Robot.AnalogRead(PinDefs.RightLightB) > 100 && Robot.AnalogRead(PinDefs.RightLightW) < 100)
                Robot.SetGeneralPower(100, 25);

             /*   else if (Robot.AnalogRead(PinDefs.RightLightB) > 100)
                    Robot.SetGeneralPower(100, 0);
                else if (Robot.AnalogRead(PinDefs.RightLightW) < 100)
                    Robot.SetGeneralPower(0, 100);*/
            }
        }

    }
}
