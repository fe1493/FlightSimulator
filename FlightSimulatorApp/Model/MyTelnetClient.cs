using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace FlightSimulatorApp.Model
{
    public class MyTelnetClient
    {
        TcpClient clientSocket = new TcpClient();
        StreamReader sr;
        StreamWriter sw;
        private Mutex mutex = new Mutex();

        public void Connect(string ip, int port)
        {
            try
            {
                clientSocket.Connect(ip, port);
                sr = new StreamReader(clientSocket.GetStream());
                sw = new StreamWriter(clientSocket.GetStream());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Write(string command)
        {
            try
            {
                mutex.WaitOne();
                sw.WriteLine(command);
                sw.Flush();
                mutex.ReleaseMutex();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public string Read()
        {
            try
            {
                string data = sr.ReadLine();
                return data;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public void Disconnect()
        {
            sr.Close();
            sw.Close();
            clientSocket.Close();
        }
    }
}
