using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Autonet
{
    class CRecog
    { 
        private int port;

        public void Init(int Port)
        {
            port = Port;
        }

        public string ColorRecog()
        {
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

            byte[] msg = Encoding.UTF8.GetBytes("c");

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            Thread.Sleep(100);

            // Освобождаем сокет

            return (Encoding.UTF8.GetString(bytes, 0, bytesRec));
        }


        public string RunRecog()
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
