using System;
using System.IO.Ports;
using System.Threading;

namespace Autonet
{
    class Arduino
    {/*
        public Arduino(String Port)
        {
            SPort.PortName = Port;
            SPort.BaudRate = 9600;
            SPort.Open();
            Thread.Sleep(100);

        }
        */
        protected SerialPort SPort = new SerialPort();
        
        public void Init(String Port)
        {
            SPort.PortName = Port;
            SPort.BaudRate = 9600;
            SPort.Open();
            Thread.Sleep(100);

        }

        public void DigitalWrite(int Pin, int Level)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<DigitalWrite>", Level.ToString(), Pin.ToString()));
            Thread.Sleep(10);
        }

        public void AnalogWrite(int Pin, int Level)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<AnalogWrite>", Level.ToString(), Pin.ToString()));
            Thread.Sleep(10);
        }

        public void PinMode(int Pin, int Mode)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<PinMode>", Mode.ToString(), Pin.ToString()));
            Thread.Sleep(10);
        }

        public int DigitalRead(int Pin)
        {
            SPort.WriteLine(String.Format("[{0}]<DigitalRead>", Pin.ToString()));
            Thread.Sleep(10);
            return int.Parse(SPort.ReadLine());
        }

        public int AnalogRead(int Pin)
        {
            SPort.WriteLine(String.Format("[{0}]<AnalogRead>", Pin.ToString()));
            Thread.Sleep(10);
            return int.Parse(SPort.ReadLine());
        }

        public int GetHue()
        {
            SPort.WriteLine(String.Format("<GetHue>"));
            Thread.Sleep(50);
            return int.Parse(SPort.ReadLine());
        }
    }
}
