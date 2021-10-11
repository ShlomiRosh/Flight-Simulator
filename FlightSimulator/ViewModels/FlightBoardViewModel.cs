using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private double _lon;
        private double _lat;

        #region Singleton
        private static FlightBoardViewModel _instance = null;
        public static FlightBoardViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlightBoardViewModel();
                }
                return _instance;
            }
        }
        #endregion
        public double Lon
        {
            get {
                return _lon;
            }
            set
            {
                _lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get {
                return _lat;
            }
            set
            {
                _lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
    }
}
