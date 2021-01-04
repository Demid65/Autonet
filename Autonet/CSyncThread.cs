using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Autonet
{
    class CSyncThread
    {
        public int CardNum = -1;
        public int CardCID = -1;
        public int LineVal = -1;
        private int port;
        private bool Alive = true;

       
        private Thread SyncThread;

        public void Init(int Port)
        {
            port = Port;
            SyncThread = new Thread(SyncLoop);
            SyncThread.Start();
        }

        public void Kill()
        {
            Alive = false;
            SyncThread.Join();
        }


        private void SyncLoop()
        {
            while (Alive) 
            { 
                Sync();
                Thread.Sleep(10);
            }
        }

        private void Sync()
        {
            IPAddress ipAddr = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            Socket socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipEndPoint);
            byte[] bytes = new byte[64];
            socket.Send(Encoding.UTF8.GetBytes(" "));
            int bytesRec = socket.Receive(bytes);
            String str = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            if(str != "Empty")
            {
                CardNum = str[0];
                switch (str[1])
                {
                    case 'r':
                        CardCID = 0;
                        break;
                    case 'b':
                        CardCID = 1;
                        break;
                    case 'g':
                        CardCID = 2;
                        break;
                    case 'y':
                        CardCID = 3;
                        break;
                    case 'o':
                        CardCID = 4;
                        break;
                }
            }
            Thread.Sleep(10);
            bytes = new byte[64];
            socket.Send(Encoding.UTF8.GetBytes("l"));
            bytesRec = socket.Receive(bytes);
            int.TryParse(Encoding.UTF8.GetString(bytes, 0, bytesRec), out LineVal);
        }
    }
}
