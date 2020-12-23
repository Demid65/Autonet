using System;
using System.Collections.Generic;
using System.Threading;
namespace Autonet
{
    class Program
    {
        static CRobot Robot = new CRobot();
        static CRecog Recog = new CRecog();
       // static CGraph Graph = new CGraph();
       // static PathFinder PathFinder = new PathFinder();

        static void Main(string[] args)
        {

            Robot.Init(ConfigDefs.ArduinoPort);



            Thread.Sleep(200);

            Robot.AnalogWrite(8, 0);
            Robot.AnalogWrite(6, 0);
            Robot.AnalogWrite(7, 0);
            Robot.AnalogWrite(5, 0);

            Thread.Sleep(500);
            Robot.AnalogWrite(3, 150);
            Thread.Sleep(500);

            Robot.DigitalWrite(3, 0);
            Thread.Sleep(1000);

            Robot.SetServo(3, 180);
            Thread.Sleep(100);
            Robot.SetServo(4, 180);
            Thread.Sleep(500);

            Robot.DigitalWrite(2, 1);
            Thread.Sleep(1000);
            Robot.DigitalWrite(2, 0);

            Robot.SetServo(3, 160);
            Robot.SetServo(4, 160);
            Thread.Sleep(500);

            Robot.SetServo(1, 90);
            Robot.SetServo(2, 90);
            Thread.Sleep(1500);

            Robot.SetServo(1, 20);
            Robot.SetServo(2, 160);

            Robot.SetServo(1, 90);
            Robot.SetServo(2, 90);
            Thread.Sleep(1500);

            Robot.SetServo(1, 20);
            Robot.SetServo(2, 160);

            Thread.Sleep(100000);



            demoSel1:

            int counter = 0;
            bool flag = true;

            Robot.AnalogWrite(8, 0);
            Robot.AnalogWrite(6, 0);
            Robot.AnalogWrite(7, 75);
            Robot.AnalogWrite(5, 75);
            Robot.SetServo(1, 20);
            Robot.SetServo(2, 160);
            Robot.SetServo(3, 145);
            Robot.SetServo(4, 145);

            while (counter < 2)
            {
                int Angle = 90;
                int SensorW = Robot.AnalogRead(4);
                int SensorB = Robot.AnalogRead(5);

                if (SensorW > 50)
                {
                    Angle = 170;
                }
                if (SensorB < 50)
                {
                    Angle = 10;
                }
                Robot.SetServo(0, Angle);

                Console.SetCursorPosition(0, 0);
               // for (int i = 0; i < 6; i++)
               //     Console.WriteLine("A" + i + ":" + (Robot.AnalogRead(i) + 1000));
                Console.WriteLine("Sonic:" + (Robot.GetSonic() + 1000));
                Console.WriteLine("Counter:" + counter);

                if (Robot.GetSonic() < 30)
                {
                    if (flag)
                    {
                        counter++;
                        flag = false;
                    }
                }
                else
                {
                    flag = true;
                }

            };
                Thread.Sleep(200);

                Robot.AnalogWrite(8, 0);
                Robot.AnalogWrite(6, 0);
                Robot.AnalogWrite(7, 0);
                Robot.AnalogWrite(5, 0);

                Thread.Sleep(500);
                Robot.AnalogWrite(3, 150);
                Thread.Sleep(500);

                Robot.DigitalWrite(3, 0);
                Thread.Sleep(1000);

                Robot.SetServo(3, 180);
                 Thread.Sleep(100);
                Robot.SetServo(4, 180);
                Thread.Sleep(500);

                Robot.DigitalWrite(2, 1);
                Thread.Sleep(1000);
                Robot.DigitalWrite(2, 0);

                Robot.SetServo(3, 160);
                Robot.SetServo(4, 160);
                Thread.Sleep(500);

                Robot.SetServo(1, 90);
                Robot.SetServo(2, 90);
                Thread.Sleep(1500);

                Robot.SetServo(1, 20);
                Robot.SetServo(2, 160);

            Robot.SetServo(1, 90);
            Robot.SetServo(2, 90);
            Thread.Sleep(1500);

            Robot.SetServo(1, 20);
            Robot.SetServo(2, 160);

            Thread.Sleep(100000);



            while (counter < 1000)
            {

                int Angle = 90;
                int SensorW = Robot.AnalogRead(4);
                int SensorB = Robot.AnalogRead(5);

                if (SensorW > 50)
                {
                    Angle = 170;
                }
                if (SensorB < 50)
                {
                    Angle = 10;
                }
                Robot.SetServo(0, Angle);

                Console.SetCursorPosition(0, 0);
                // for (int i = 0; i < 6; i++)
                //     Console.WriteLine("A" + i + ":" + (Robot.AnalogRead(i) + 1000));
                Console.WriteLine("Sonic:" + (Robot.GetSonic() + 1000));
                Console.WriteLine("Counter:" + counter);

                
                        
                    

            };


            /*
            int SensorW = Robot.AnalogRead(4);
            int SensorB = Robot.AnalogRead(5);
            int DSensorW = 2*(SensorW - 40);
            int DSensorB = SensorB - 700;

            Console.WriteLine("B"+DSensorB);
            Console.WriteLine("W"+DSensorW);

            int val = DSensorB + DSensorW;
            double DAngle = 0.13 * val;
            int Angle = (int) Math.Round(DAngle + 90);
            Console.WriteLine(Angle);
            //Console.WriteLine(Robot.GetSonic());
            Robot.SetServo(0, Angle);
            */


            Robot.AnalogWrite(8, 0);
            Robot.AnalogWrite(6, 0);
            Robot.AnalogWrite(7, 0);
            Robot.AnalogWrite(5, 0);


            /*
            CCard TargetCard = new CCard();

            Robot.Init(ConfigDefs.ArduinoPort);
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

            Console.ReadLine();*/
        }

    }

}
