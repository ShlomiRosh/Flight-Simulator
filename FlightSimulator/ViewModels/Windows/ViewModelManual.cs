using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels.Windows
{
    class ViewModelManual
    {
        private double _rudder = 0;
        private double _throttle = 0;
        private double _aileron = 0;
        private double _elevator = 0;
        private string _throttlePath = "set controls/engines/current-engine/throttle ";
        private string _rudderPath = "set controls/flight/rudder ";
        private string _aileronPath = "set controls/flight/aileron ";
        private string _elevatorPath = "set controls/flight/elevator ";

        public double Rudder
        {
            set
            {
                _rudder = value;
                SendCommand(_rudderPath, _rudder);
            }
            get
            {
                return _rudder;
            }
        }

        public double Throttle
        {
            set
            {
                _throttle = value;
                SendCommand(_throttlePath, _throttle);
            }
            get
            {
                return _throttle;
            }
        }

        public double Aileron
        {
            set
            {
                _aileron = value;
                SendCommand(_aileronPath, _aileron);
            }
            get
            {
                return _aileron;
            }
        }

        public double Elevator
        {
            set
            {
                _elevator = value;
                SendCommand(_elevatorPath, _elevator);
            }
            get
            {
                return _elevator;
            }
        }

        // send command to Client if it connected
        private void SendCommand(string _path, double _val)
        {          
            if (ViewModleSettingsConnect.Connected)
            {
                ClientTCP.Instance.SendSingelCommand(_path + (_val) + "\r\n");
            }
        }
    }
}

