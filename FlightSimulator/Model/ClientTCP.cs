using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ClientTCP
    {
        private NetworkStream _stream;
        private TcpClient _tcpClient;
        private object _locker;
        private List<string> _commands;
        private static ClientTCP _instance = null;

        private void ThreadStart()
        {
            int _latency = 2000;
            _locker = new object();
            foreach (string _command in _commands)
            {
                lock (_locker)
                {
                    SendSingelCommand(_command);
                }
                Thread.Sleep(_latency);
            }
        }

        public static ClientTCP Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClientTCP();
                }
                return _instance;
            }
        }

        public ClientTCP()
        {
            _tcpClient = new TcpClient();
        }

        public bool ConnectClientTCP()
        {
            IPEndPoint _iPEndPoint = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
                ApplicationSettingsModel.Instance.FlightCommandPort);
            try
            {
                while (!_tcpClient.Connected)
                {
                    _tcpClient.Connect(_iPEndPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return _tcpClient.Connected;
        }

        public void SendSingelCommand(string _command)
        {
            if (!_tcpClient.Connected)
            {
                return;
            }           
            _stream = _tcpClient.GetStream();
            byte[] _sendCommand = Encoding.ASCII.GetBytes(_command);
            _stream.Write(_sendCommand, 0, _sendCommand.Length); // send to the server
        }

        public void SendCommands(List<string> commands)
        {           
            _commands = new List<string>(commands);           
            Thread thread = new Thread(ThreadStart);
            thread.Start();
        }

        public void StopConnection()
        {
            _tcpClient.Close();
        }

    }
}


