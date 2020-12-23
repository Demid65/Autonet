using System;
using System.IO.Ports;
using System.Threading;
using System.Timers;

namespace Autonet
{
    class CArduino
    {
       /* public Arduino(String Port)
        {
            SPort.PortName = Port;
            SPort.BaudRate = 9600;
            SPort.Open();
            Thread.Sleep(100);

        }*/
        

        public const int OUTPUT = 1;
        public const int INPUT = 0;

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
        }

        public void AnalogWrite(int Pin, int Level)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<AnalogWrite>", Level.ToString(), Pin.ToString()));
        }

        public void PinMode(int Pin, int Mode)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<PinMode>", Mode.ToString(), Pin.ToString()));
        }

        public int DigitalRead(int Pin)
        {
            SPort.WriteLine(String.Format("[{0}]<DigitalRead>", Pin.ToString()));
            return int.Parse(SPort.ReadLine());
        }

        public int AnalogRead(int Pin)
        {
            SPort.WriteLine(String.Format("[{0}]<AnalogRead>", Pin.ToString()));
            return int.Parse(SPort.ReadLine());
        }

        public void SetServo(int Servo, int Angle)
        {
            SPort.WriteLine(String.Format("({0})[{1}]<SetServo>", Angle.ToString(), Servo.ToString()));
        }

        public int GetHue()
        {
            SPort.WriteLine(String.Format("<GetHue>"));
            Thread.Sleep(30);
            return int.Parse(SPort.ReadLine());
        }

        public int GetSonic()
        {
            SPort.WriteLine(String.Format("<GetSonic>"));
            return int.Parse(SPort.ReadLine());
        }
    }
}
