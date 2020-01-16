using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace Autonet
{
    class Program
    {
        const int OUTPUT = 1;
        const int INPUT = 0;

        static CRobot Robot = new CRobot();
        static void Main(string[] args)
        {


            Robot.Init("COM30");

            Robot.DigitalWrite(4, 1);
            Robot.DigitalWrite(7, 0);

            while (true)
            {

                if (Robot.DigitalRead(22) == 1)
                {
                    Robot.SetGeneralPower(0, 255);
                }
                else
                {
                    Robot.SetGeneralPower(255, 0);
                }
            }
            
                       Robot.PinMode(4, 1);
            Robot.PinMode(5, 1);
            Robot.PinMode(6, 1);
            Robot.PinMode(7, 1);
            Robot.DigitalWrite(4, 1);
            Robot.DigitalWrite(7, 0);
            Robot.AnalogWrite(5,128);
            Robot.AnalogWrite(6,128);
            Console.ReadLine();
            Robot.AnalogWrite(5, 0);
            Robot.AnalogWrite(6, 0);
            

 /*           
            Robot.PinMode(51, 0);
            Robot.PinMode(52, 0);
            Robot.PinMode(53, 0);
            String r = Recog(9090);
            switch (r[1])
            {
                case 'r':
                    Robot.DigitalWrite(51, 1);
                    Robot.DigitalWrite(52, 0);
                    Robot.DigitalWrite(53, 0);
                    Console.WriteLine("Red");
                    break;
                case 'b':
                    Robot.DigitalWrite(51, 0);
                    Robot.DigitalWrite(52, 1);
                    Robot.DigitalWrite(53, 0);
                    Console.WriteLine("Blue");
                    break;
                case 'g':
                    Robot.DigitalWrite(51, 0);
                    Robot.DigitalWrite(52, 0);
                    Robot.DigitalWrite(53, 1);
                    Console.WriteLine("Green");
                    break;
                case 'y':
                    Robot.DigitalWrite(51, 1);
                    Robot.DigitalWrite(52, 0);
                    Robot.DigitalWrite(53, 1);
                    Console.WriteLine("Yellow");
                    break;

                case 'o':
                    Robot.DigitalWrite(51, 1);
                    Robot.DigitalWrite(52, 0);
                    Robot.DigitalWrite(53, 0);
                    Console.WriteLine("Orange");
                    break;
                default:
                    Robot.DigitalWrite(51, 0);
                    Robot.DigitalWrite(52, 0);
                    Robot.DigitalWrite(53, 0);
                    Console.WriteLine("Nothing Detected");
                    break;

            }
            //  Console.WriteLine(Robot.Init());
            // Console.WriteLine(Recog(9090));
            Console.WriteLine(r[0]);
            Console.ReadLine();
            */
        }

        static string Recog(int port)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[64];
            byte[] ipad = new byte[] { 127, 0, 0, 1 }; 


            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = new IPAddress(ipad);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            byte[] msg = Encoding.UTF8.GetBytes(" ");

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            Thread.Sleep(100);
       
            // Освобождаем сокет
          
            return (Encoding.UTF8.GetString(bytes, 0, bytesRec));
        }
    }
    
}
