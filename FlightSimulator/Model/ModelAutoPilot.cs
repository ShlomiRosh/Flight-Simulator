using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ModelAutoPilot : BaseNotify
    {
        public void SendCommandsToClient(string _commands)
        {

            if (_commands.Contains("\r\n")) // from windows
            {
                string[] _commandSend = _commands.Split(new[] { "\r\n" }, StringSplitOptions.None);
                ClientTCP.Instance.SendCommands(_commandSend.ToList());
            } 
            else if (_commands.Contains("\r")) //mac
            {
                string[] _commandSend = _commands.Split('\r');
                ClientTCP.Instance.SendCommands(_commandSend.ToList());
            }
            else // linoks
            {
                string[] _commandSend = _commands.Split('\n');
                ClientTCP.Instance.SendCommands(_commandSend.ToList());
            }
        }
    }
}
