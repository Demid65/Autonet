using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet
{
    class Demo : CAutonomous
    {
       
        public override void Run(CRobot Robot, CRecog Recog)
        {

            Robot.PinMode(PinDefs.MidLight, Arduino.INPUT);
            Robot.PinMode(PinDefs.LeftLight, Arduino.INPUT);
            Robot.PinMode(PinDefs.RightLight, Arduino.INPUT);

            Robot.PinMode(PinDefs.MotorA1, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorA2, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorB1, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorB2, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorC1, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorC2, Arduino.OUTPUT);




        }
    }
}
