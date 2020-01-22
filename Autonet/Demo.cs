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
            Console.WriteLine(Recog.ColorRecog());
            Console.ReadLine();
        }
    }
}
