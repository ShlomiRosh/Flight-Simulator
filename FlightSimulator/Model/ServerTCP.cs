using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
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
    class ServerTCP
    {
        private TcpListener tcpListener;
        private object _locker;
        private BinaryReader _reader;
        private NetworkStream _networkStream;

        public ServerTCP()
        {
            tcpListener = new TcpListener(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
                ApplicationSettingsModel.Instance.FlightInfoPort);
        }

        public void ConnectServerTCP()
        {
            Thread thread = new Thread(ThreadStart);
            thread.Start();
        }

        private void ThreadStart()
        {
            ConnectServer();
        }

        public void ConnectServer()
        {
            tcpListener.Start();
            while (true)
            {
                TcpClient _tcpClient = tcpListener.AcceptTcpClient();
                while (_tcpClient.Connected)
                {
                    _networkStream = _tcpClient.GetStream();
                    if (!_networkStream.DataAvailable)
                    {
                        continue;
                    }
                    string[] separatedParam = GetString().Split(',');
                    _locker = new object();
                    lock (_locker)
                    {
                        FlightBoardViewModel.Instance.Lon = Double.Parse(separatedParam[0]);
                        FlightBoardViewModel.Instance.Lat = Double.Parse(separatedParam[1]);                      
                    }
                }
                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                }
            }
        }

        private string GetString()
        {
            _reader = new BinaryReader(_networkStream);
            string _recived = "";
            char _letter;
            while ((_letter = _reader.ReadChar()) != '\n')
            {
                _recived += _letter;
            }
            return _recived;
        }
    }
}

