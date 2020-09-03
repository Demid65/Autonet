using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Autonet
{
    class Point1 : CAutonomous
    {
        CCard TargetCard = new CCard();
        public override void Run(CRobot Robot, CRecog Recog)
        {

            Console.WriteLine("Recog in 15 seconds...");
            Thread.Sleep(15000);
            Console.WriteLine("1 sec left");
            Thread.Sleep(1000);
            Console.WriteLine("Frame Captured");
            String recData = Recog.RunRecog();
            Console.WriteLine("Recog result: " + recData);

            //Thread.Sleep(100000);

            Robot.SetGeneralPower(60, 150);
            Thread.Sleep(3500);
            Robot.SetGeneralPower(60, 20);
            int cid = -1;
            //while (Robot.AnalogRead(PinDefs.RightLightB)<400) ;
            while (true)
            {
                if (Robot.AnalogRead(PinDefs.RightLightB) > 400)
                    Robot.SetGeneralPower(-55, 105);
                else
                if (Robot.AnalogRead(PinDefs.RightLightW) < 400)
                    Robot.SetGeneralPower(105, -55);
                else
                    Robot.SetGeneralPower(105, 105);

                Console.Clear();
                //Console.WriteLine(Robot.GetODS());
                // Console.WriteLine("" + Robot.AnalogRead(PinDefs.RightLightB) + "B");
                // Console.WriteLine("" + Robot.AnalogRead(PinDefs.RightLightW) + "W");
                Console.WriteLine("Target:" + recData);
                int tcid = cid;
                cid = int.Parse(Recog.ColorRecog());
                if (cid == tcid)
                    switch (cid)
                    {
                        case 0:
                            Console.WriteLine("I see Red");
                            break;
                        case 1:
                            Console.WriteLine("I see Blue");
                            break;
                        case 2:
                            Console.WriteLine("I see Green");
                            break;
                        case 3:
                            Console.WriteLine("I see Yellow");
                            break;
                        case 4:
                            Console.WriteLine("I see Orange");
                            break;



                    }

                if (Robot.AnalogRead(PinDefs.LeftLightB) > 400) break;

            }

            Robot.SetGeneralPower(60, 50);
            Thread.Sleep(1000);
            while (Robot.AnalogRead(PinDefs.RightLightW) > 400) ;
            Robot.SetGeneralPower(0, 0);

        }

    }
}
