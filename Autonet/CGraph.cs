using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet
{
    class CGraph
    {
       public class Connection
        {
            public int Cost = -1;
            public CManuever Manuever;
        }



       public Connection[,] Connections = new Connection[sizeof(Points), sizeof(Points)];
       public enum Points : int
        {
            //Primary points
            Start1,
            Start2,
            GrabStart,
            GrabEnd,
            ParkParallel,
            ParkPerpendicular,
            TrafficNorth,
            TrafficEast,
            TrafficSouth,
            TrafficWest,
            //Secondary points
            Green1Start,
            Green1End,
            Red1Transfer,
            Red1Start,
            Red1End,
            Blue2Start,
            Blue2End,
            Green2,
            Orange2,
            Blue1,
            Red2,
            Orange1Start,
            Orange1End,
            Yellow2Start,
            Yellow2End,
            Yellow1

        }

        public CGraph()
        {
            for (int i = 0; i < sizeof(Points); i++)
                for (int j = 0; j < sizeof(Points); j++)
                    Connections[i, j] = new Connection();


            Connections[(int)Points.Start1, (int)Points.GrabStart].Cost = 1;
            Connections[(int)Points.Start1, (int)Points.GrabStart].Manuever = new Point2Rollout();

            Connections[(int)Points.GrabStart, (int)Points.GrabEnd].Cost = 1;
            Connections[(int)Points.GrabStart, (int)Points.GrabEnd].Manuever = new GrabSkip();

            Connections[(int)Points.GrabEnd, (int)Points.Green1Start].Cost = 1;
            Connections[(int)Points.GrabEnd, (int)Points.Green1Start].Manuever = new NorthPass();

            Connections[(int)Points.Green1Start, (int)Points.Green1End].Cost = 1;
            Connections[(int)Points.Green1Start, (int)Points.Green1End].Manuever = new GreenStreet1();

            Connections[(int)Points.Green1End, (int)Points.ParkParallel].Cost = 1;
            Connections[(int)Points.Green1End, (int)Points.ParkParallel].Manuever = new ParkParallel1();
/*
            Connections[(int)Points.ParkParallel, (int)Points.Red1Transfer].Cost = 1;
            Connections[(int)Points.ParkParallel, (int)Points.Red1Transfer].Manuever = new yahz();

            Connections[(int)Points.Red1Transfer, (int)Points.Red1End].Cost = 1;
            Connections[(int)Points.Red1Transfer, (int)Points.Red1End].Manuever = new yahz();

            Connections[(int)Points.Red1End, (int)Points.Blue2Start].Cost = 1;
            Connections[(int)Points.Red1End, (int)Points.Blue2Start].Manuever = new yahz();

            Connections[(int)Points.Blue2Start, (int)Points.Blue2End].Cost = 1;
            Connections[(int)Points.Blue2Start, (int)Points.Blue2End].Manuever = new yahz();

            Connections[(int)Points.Blue2End, (int)Points.GrabStart].Cost = 1;
            Connections[(int)Points.Blue2End, (int)Points.GrabStart].Manuever = new yahz();

            Connections[(int)Points.Blue2End, (int)Points.GrabStart].Cost = 1;
            Connections[(int)Points.Blue2End, (int)Points.GrabStart].Manuever = new yahz();
       */     

        }





    }

    

  
}
