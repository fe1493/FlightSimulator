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
        Boolean isConnect = false;

        public void Connect(string ip, int port)
        {
            try
            {
                if (!isConnect)
                {
                    clientSocket.Connect(ip, port);
                    sr = new StreamReader(clientSocket.GetStream());
                    sw = new StreamWriter(clientSocket.GetStream());
                    isConnect = true;
                }
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
                if (isConnect)
                {
                    mutex.WaitOne();
                    sw.WriteLine(command);
                    sw.Flush();
                    Console.WriteLine("Sent: " + command);
                    mutex.ReleaseMutex();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
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
                if (isConnect)
                {
                    string data = sr.ReadLine();
                    return data;
                }
                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public void Disconnect()
        {
            if (isConnect)
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
                if (clientSocket != null)
                    clientSocket.Close();
                isConnect = false;
            }
            
        }
    }
}
