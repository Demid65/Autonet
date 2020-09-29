using System;
using System.Collections.Generic;
using System.Threading;
namespace Autonet
{
    class Program
    {
        static CRobot Robot = new CRobot();
        static CRecog Recog = new CRecog();
        static CGraph Graph = new CGraph();
        static PathFinder PathFinder = new PathFinder();

        static void Main(string[] args)
        {



            Robot.Init(ConfigDefs.ArduinoPort, ConfigDefs.LegacyPort);


            while (true) ;

            CCard TargetCard = new CCard();

            Robot.Init(ConfigDefs.ArduinoPort,ConfigDefs.LegacyPort);
            Recog.Init(9090);

            Thread.Sleep(3000);

            TargetCard.Parse(Recog.RunRecog());

            while (TargetCard.CID == -1)
            {
                TargetCard.Parse(Recog.RunRecog());
            }

            PathFinder.LoadGraph(Graph);
            List<CManuever> ManueverMap = PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.StartPoint, ConfigDefs.GrabPoint));
            ManueverMap.Add(new GrabManuever());

            switch (TargetCard.CID)
            {
                case 0:
                    if (new List<int>{ 1, 3, 5, 7, 9 }.Contains(TargetCard.Num))
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Red1Start)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Red1Start, (int)CGraph.Points.Red1End)));
                    } else
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Red2)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Red2, (int)CGraph.Points.Green2)));
                    }
                    break;
                case 1:
                    if (new List<int> { 1, 3, 5, 7, 9 }.Contains(TargetCard.Num))
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Blue1)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Blue1, (int)CGraph.Points.Red2)));
                    }
                    else
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Blue2Start)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Blue2Start, (int)CGraph.Points.Blue2End)));
                    }
                    break;
                case 2:
                    if (new List<int> { 1, 3, 5, 7, 9 }.Contains(TargetCard.Num))
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Green1Start)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Green1Start, (int)CGraph.Points.Green1End)));
                    }
                    else
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Green2)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Green2, (int)CGraph.Points.Orange2)));
                    }
                    break;
                case 3:
                    if (new List<int> { 1, 3, 5, 7, 9 }.Contains(TargetCard.Num))
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Yellow1)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Yellow1, (int)CGraph.Points.TrafficSouth)));
                    }
                    else
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Yellow2Start)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Yellow2Start, (int)CGraph.Points.Yellow2End)));
                    }
                    break;
                case 4:
                    if (new List<int> { 1, 3, 5, 7, 9 }.Contains(TargetCard.Num))
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Orange1Start)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Orange1Start, (int)CGraph.Points.Orange1End)));
                    }
                    else
                    {
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind(ConfigDefs.AfterGrabPoint, (int)CGraph.Points.Orange2)));
                        ManueverMap.AddRange(PathFinder.GetManueverMap(PathFinder.Pathfind((int)CGraph.Points.Orange2, (int)CGraph.Points.Blue1)));
                    }
                    break;
            }

            for (int i = 0; i < ManueverMap.Count; i++)
                ManueverMap[i].Run(Robot, Recog, TargetCard);

            Console.ReadLine();
        }

    }

}
