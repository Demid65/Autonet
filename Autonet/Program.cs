﻿namespace Autonet
{
    class Program
    {
        static CRobot Robot = new CRobot();
        static CRecog Recog = new CRecog();
        static CAutonomous Autonomous = new Point2();

        static void Main(string[] args)
        {
            
            
            Recog.Init(9090);
            /*
            Robot.Init("COM30");
            Robot.PinMode(PinDefs.MotorLR, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorLF, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorRR, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorRF, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorGU, Arduino.OUTPUT);
            Robot.PinMode(PinDefs.MotorGD, Arduino.OUTPUT);
            */
            Autonomous.Run(Robot, Recog);



            /*           
                       Robot.PinMode(51, 0);
                       Robot.PinMode(52, 0);
                       Robot.PinMode(53, 0);
                       String r = Recog(9090);
                       switch (r[1])
                       {
                           case 'r':
                               Robot.DigitalWrite(51, 1);
                               Robot.DigitalWrite(52, 0);
                               Robot.DigitalWrite(53, 0);
                               Console.WriteLine("Red");
                               break;
                           case 'b':
                               Robot.DigitalWrite(51, 0);
                               Robot.DigitalWrite(52, 1);
                               Robot.DigitalWrite(53, 0);
                               Console.WriteLine("Blue");
                               break;
                           case 'g':
                               Robot.DigitalWrite(51, 0);
                               Robot.DigitalWrite(52, 0);
                               Robot.DigitalWrite(53, 1);
                               Console.WriteLine("Green");
                               break;
                           case 'y':
                               Robot.DigitalWrite(51, 1);
                               Robot.DigitalWrite(52, 0);
                               Robot.DigitalWrite(53, 1);
                               Console.WriteLine("Yellow");
                               break;

                           case 'o':
                               Robot.DigitalWrite(51, 1);
                               Robot.DigitalWrite(52, 0);
                               Robot.DigitalWrite(53, 0);
                               Console.WriteLine("Orange");
                               break;
                           default:
                               Robot.DigitalWrite(51, 0);
                               Robot.DigitalWrite(52, 0);
                               Robot.DigitalWrite(53, 0);
                               Console.WriteLine("Nothing Detected");
                               break;

                       }
                       //  Console.WriteLine(Robot.Init());
                       // Console.WriteLine(Recog(9090));
                       Console.WriteLine(r[0]);
                       Console.ReadLine();
                       */
        }

    }
    
}
