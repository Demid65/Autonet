using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autonet
{
    class Demo : CAutonomous
    {
        CCard TargetCard = new CCard();
        public override void Run(CRobot Robot, CRecog Recog)
        {
            Console.WriteLine("Recog in 5 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("Recog in 4 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("Recog in 3 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("Recog in 2 seconds");
            Thread.Sleep(1000);
            Console.WriteLine("Recog in 1 second");
            Thread.Sleep(1000);
            Console.WriteLine("Running Recog");
            TargetCard.Parse(Recog.RunRecog());
            Console.WriteLine(""+TargetCard.Num+' '+TargetCard.CID);
            Console.ReadLine();
        }
    }
}
