using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for WindowSettings.xaml
    /// creat a windowSsettings and give the option to close it
    /// </summary>
    public partial class WindowSettings : Window
    {
        private SettingsWindowViewModel _settingsWindowViewModel;
        public WindowSettings()
        {
            InitializeComponent();
            _settingsWindowViewModel = new SettingsWindowViewModel(new ApplicationSettingsModel());
            this.DataContext = _settingsWindowViewModel;
            if (_settingsWindowViewModel.GetCloseAction() == null) // Action for window closer
            {
                _settingsWindowViewModel.SetCloseAction(new Action(this.Close));
            }
        }
    }
}
