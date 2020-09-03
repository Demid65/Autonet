using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autonet
{
    class Point2 : CAutonomous 
    {
        public override void Run(CRobot Robot, CRecog Recog)
        {
            Console.WriteLine("Recog in 3 seconds...");
            Thread.Sleep(2000);
            Console.WriteLine("1 sec left");
            Thread.Sleep(1000);
            Console.WriteLine("Connecting");
            String recData = Recog.RunRecog();
            Console.WriteLine("Recog result: " + recData);

            Console.WriteLine("Recog in 3 seconds...");
            Thread.Sleep(2000);
            Console.WriteLine("1 sec left");
            Thread.Sleep(1000);
            Console.WriteLine("Connecting");
            recData = Recog.RunRecog();
            Console.WriteLine("Recog result: " + recData);
        }
    }
}
