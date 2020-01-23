using System;
using System.Threading;


namespace Autonet
{
    class CRobot : Arduino
    {
       

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
                AnalogWrite(7, 0);
                AnalogWrite(8, power);
            }
            else
            {
                AnalogWrite(7, -power);
                AnalogWrite(8, 0);
            }
        }

        public void SetRightPower(int power)
        {
            if (power >= 0)
            {
                AnalogWrite(5, 0);
                AnalogWrite(6, power);
            }
            else
            {
                AnalogWrite(5, -power);
                AnalogWrite(6, 0);
            }
        }

        public void SetGeneralPower(int L, int R)
        {
            SetLeftPower(L);
            SetRightPower(R);
        }

        public void SGPnoNeg(int L, int R)
        {
            if (L < 0) L = 0;
            if (R < 0) R = 0;

            if (R > 255) R = 255;
            if (L > 255) L = 255;


            SetLeftPower(L);
            SetRightPower(R);
        }

        

        public int GetODS()
        {
            return AnalogRead(PinDefs.ODS);
        }

    }
}
