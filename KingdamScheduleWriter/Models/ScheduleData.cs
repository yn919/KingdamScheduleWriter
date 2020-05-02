using System;
using System.Collections.Generic;
using System.Text;

namespace KingdamScheduleWriter.Models
{
    public class ScheduleData : PropertyChangeObj
    {
        private DateTime _Date = DateTime.Today;
        public DateTime Date
        {
            get => _Date;
            set
            {
                if(_Date != value)
                {
                    _Date = value;
                    RaisePropertyChange();
                }
            }
        }

        private String _Place = string.Empty;
        public String Place
        {
            get => _Place;
            set
            {
                if(_Place != value)
                {
                    _Place = value;
                    RaisePropertyChange();
                }
            }
        }

        private string _Time = string.Empty;
        public string Time
        {
            get => _Time;
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    RaisePropertyChange();
                }
            }
        }
    }
}
