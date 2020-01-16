using System;
using System.Threading;

namespace Autonet
{
    class CRobot : Arduino
    {
        const int OUTPUT = 1;
        const int INPUT = 0;

        public void Init(String Port) {

            SPort.PortName = Port;
            SPort.BaudRate = 9600;
            SPort.Open();
            Thread.Sleep(100);
            
            PinMode(22, INPUT);
            PinMode(5, OUTPUT);     //LR 
            PinMode(6, OUTPUT);     //LF
            PinMode(7, OUTPUT);     //RR
            PinMode(8, OUTPUT);     //RF
        }

        public void SetLeftPower(int power)
        {
            if (power >= 0)
            {
                DigitalWrite(5, 0);
                DigitalWrite(6, power);
            }
            else
            {
                DigitalWrite(5, power);
                DigitalWrite(6, 0);
            }
        }

        public void SetRightPower(int power)
        {
            if (power >= 0)
            {
                DigitalWrite(7, 0);
                DigitalWrite(8, power);
            }
            else
            {
                DigitalWrite(7, power);
                DigitalWrite(8, 0);
            }
        }

        public void SetGeneralPower(int L, int R)
        {
            SetLeftPower(L);
            SetRightPower(R);
        }


    }
}
