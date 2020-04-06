using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;


namespace FlightSimulatorApp.Model
{
    public class MyTelnetClient
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readdata = null;

        public void connect(string ip, int port)
        {
            clientSocket.Connect(ip, port);
            Thread ctThread = new Thread(getMassage);
            ctThread.Start();
        }
        private void getMassage()
        {
            string returndata;
            while (true)
            {
                serverStream = clientSocket.GetStream();
                var buffsize = clientSocket.ReceiveBufferSize;
                byte[] instream = new byte[buffsize];
                serverStream.Read(instream, 0, buffsize);

                returndata = System.Text.Encoding.ASCII.GetString(instream);

                readdata = returndata;
                read();
            }
        }
        public void write(string command)
        {
            byte[] outstream = Encoding.ASCII.GetBytes(command);
            serverStream.Write(outstream, 0, outstream.Length);
            serverStream.Flush();
        }
        public string read()
        {
            return this.readdata;
        }
        public void disconnect()
        {

        }
    }
}
