using System.Threading;
using System;
namespace Autonet
{
    class Demo : CAutonomous
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
             Console.WriteLine("Recog result: "+recData);
            
            //Thread.Sleep(100000);

            Robot.SetGeneralPower(60,150);
            Thread.Sleep(3500);
            Robot.SetGeneralPower(60, 20);

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
                Console.WriteLine("Target:"+recData);
                
                    int cid = int.Parse(Recog.ColorRecog());
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

            Robot.SetGeneralPower(50, 50);
            while (Robot.AnalogRead(PinDefs.RightLightW) > 400) ;
            Robot.SetGeneralPower(0, 0);

        }
    }
}
