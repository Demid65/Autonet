using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet
{
    abstract class CManuever
    {
        public abstract void Run(CRobot Robot, CRecog Recog, CCard TargetCard);
    }

    class Point2Rollout : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class GrabManuever : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class GrabSkip : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class DebugManuever : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class NorthPass : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class GreenStreet1 : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }

    class ParkParallel1 : CManuever
    {
        public override void Run(CRobot Robot, CRecog Recog, CCard TargetCard)
        {
            throw new NotImplementedException();
        }
    }
}