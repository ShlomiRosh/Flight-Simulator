﻿using FlightSimulator.ViewModels.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for SubWinJoystickAuto.xaml
    /// </summary>
    public partial class SubWinJoystickAuto : UserControl
    {
        public SubWinJoystickAuto()
        {
            InitializeComponent();
            DataContext = new ViewModelAutoPilot();
        }
    }
}
