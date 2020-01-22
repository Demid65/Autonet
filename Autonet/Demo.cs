using System.Threading;
using System;
namespace Autonet
{
    class Demo : CAutonomous
    {
        CCard TargetCard = new CCard();
        public override void Run(CRobot Robot, CRecog Recog)
        {
           Console.WriteLine("Recog in 5 seconds...");
            Thread.Sleep(5000);
             Console.WriteLine("Recog result: "+Recog.RunRecog());
             Thread.Sleep(3000);
            while (true)
            {
                
                   int x = (Robot.GetRightLS()-300)/2;
                Console.Clear();
                Console.WriteLine(x);
                if (x < 100) // White
                    Robot.SetGeneralPower(150, -85);
                else
                    Robot.SetGeneralPower(-100, 150);
                
                Console.WriteLine(Robot.GetLeftLS());
               /*
                * 
                * if(Robot.GetLeftLS()>500)
                    Robot.SGPnoNeg(150, -150);
                else
                    Robot.SGPnoNeg(-255, 150);
                    */
            }
        }
    }
}
