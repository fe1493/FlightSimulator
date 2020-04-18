using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace FlightSimulatorApp.Model
{
    public class MyTelnetClient
    {
        TcpClient clientSocket;
        StreamReader sr;
        StreamWriter sw;
        private Mutex mutex;
        public Boolean isConnect = false;

        public void Connect(string ip, int port)
        {
            try
            {
                if (!isConnect)
                {
                    clientSocket = new TcpClient();
                    mutex = new Mutex();
                    // try to connect
                    var result = clientSocket.BeginConnect(ip, port, null, null);
                    // wait 1 seconds if the server is not responding
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    // if failed, throw exception
                    if (!success)
                    {
                        throw new Exception("Failed to connect.");
                    }

                    // we have connected
                    clientSocket.EndConnect(result);
                    sr = new StreamReader(clientSocket.GetStream());
                    sw = new StreamWriter(clientSocket.GetStream());
                    isConnect = true;
                    (Application.Current as App).MainViewModel.model.Error = "Connection Established!\n";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Write(string command)
        {
            try
            {
                if (isConnect)
                {
                    sw.WriteLine(command);
                    sw.Flush();
                    Console.WriteLine("Sent: " + command);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string Read()
        {
            try
            {
                if (isConnect)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    string data = sr.ReadLine();
                    // check if the server is not responsing for 10 seconds
                    if (stopWatch.ElapsedMilliseconds > 10000)
                    {
                        (Application.Current as App).MainViewModel.model.Error = "Server slows down\n";
                        return data;
                    }
                    if (data == "ERR")
                    {
                        return null;
                    }
                    return data;
                }
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
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
