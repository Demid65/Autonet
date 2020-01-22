using System.Threading;

namespace Autonet
{
    class Demo : CAutonomous
    {
        CCard TargetCard = new CCard();
        public override void Run(CRobot Robot, CRecog Recog)
        {
            while (true)
            {
                if (Robot.GetRightLS() == 1)
                    Robot.SetGeneralPower(0, 255);
                else
                    Robot.SetGeneralPower(255, 0);
            }
        }
    }
}
