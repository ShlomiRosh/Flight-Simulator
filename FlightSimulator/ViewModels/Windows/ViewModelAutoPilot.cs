using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels.Windows
{
    class ViewModelAutoPilot : BaseNotify
    {
        private string _simulatorCommands;
        private ICommand _okCommand;
        private ICommand _clearCommand;
        private Brush _colorBackgruond;
        private ModelAutoPilot _modelAutoPilot;

        public ViewModelAutoPilot()
        {
            _colorBackgruond = Brushes.White;
            _modelAutoPilot = new ModelAutoPilot();
        }

        public string SimulatorCommands
        {
            get
            {
                return _simulatorCommands;
            }

            set
            {
                _simulatorCommands = value;
                ColorChange(_simulatorCommands);
            }
        }

        public Brush ColorBackgruond
        {
            get
            {
                return _colorBackgruond;
            }
            set
            {
                _colorBackgruond = value;
                NotifyPropertyChanged("ColorBackgruond"); // Notify for the Binding property
            }
        }

        public ICommand OKCommand
        {
            get
            {
                ICommand command = _okCommand;
                if (command != null)
                {
                    return command;
                }
                return (_okCommand = new CommandHandler(OkClick));
            }
        }

        private void OkClick()
        {
            if (_simulatorCommands == "")
            {
                return;
            }
            string _commandToSend = _simulatorCommands; // clear the txt box
            _simulatorCommands = "";
            NotifyPropertyChanged(_simulatorCommands);
            _colorBackgruond = Brushes.White; // return color to white and send commands to simulator
            NotifyPropertyChanged("ColorBackgruond");
            _modelAutoPilot.SendCommandsToClient(_commandToSend);        
        }

        public ICommand ClearCommand
        {
            get
            {                
                ICommand command = _clearCommand; 
                if (command != null)
                {
                    return command;
                }
                return (_clearCommand = new CommandHandler(ClearClick));
            }
        }

        private void ClearClick()
        {
            _simulatorCommands = ""; // clear the txt box
            _colorBackgruond = Brushes.White;
            NotifyPropertyChanged(_simulatorCommands);
            NotifyPropertyChanged("ColorBackgruond");        
        }

        // Changes color when there are new commands
        private void ColorChange(string simulatorCommands)
        {
            if (ColorBackgruond != Brushes.White || _simulatorCommands == "")
            {
                if (_simulatorCommands == "")
                {
                    ColorBackgruond = Brushes.White;
                }
            }
            else
            {
                ColorBackgruond = Brushes.Pink;
            }
        }
    }
}
