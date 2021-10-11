using FlightSimulator.Model;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    class ViewModleSettingsConnect
    {
        private ICommand _settingsBTNCommand;
        private ICommand _connectBTNCommand;
        private WindowSettings _windowSettings;
        private static bool _connected = false;
        private ServerTCP _serverTCP;
        private static bool _serverOpen = false;

        static public bool Connected
        {
            get
            {
                return _connected;
            }
            set
            {
                _connected = value;
            }
        }

        public ICommand SettingsBTNCommand
        {
            get
            {
                ICommand command = _settingsBTNCommand;
                if (command != null)
                {
                    return command;
                }
                return (_settingsBTNCommand = new CommandHandler(ClickedSettings));
            }
        }

        private void ClickedSettings()
        {
            _windowSettings = new WindowSettings();
            _windowSettings.ShowDialog();
        }

        public ICommand ConnectBTNCommand
        {
            get
            {
                ICommand command = _connectBTNCommand;
                if (command != null)
                {
                    return command;
                }
                return (_connectBTNCommand = new CommandHandler(ClickedConnect));
            }
        }

        private void ClickedConnect()
        {            
            if (!_serverOpen)
            {
                _serverTCP = new ServerTCP();
                _serverTCP.ConnectServerTCP();
                _serverOpen = true;
            }                     
            if (!_connected)
            {
                _connected = ClientTCP.Instance.ConnectClientTCP();
            }           
        }
    }
}
