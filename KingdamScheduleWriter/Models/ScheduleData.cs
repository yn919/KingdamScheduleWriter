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

        private int _StartTime = 0;
        public int StartTime
        {
            get => _StartTime;
            set
            {
                if(_StartTime != value)
                {
                    _StartTime = value;
                    RaisePropertyChange();
                }
            }
        }

        private int _EndTime = 0;
        public int EndTime
        {
            get => _EndTime;
            set
            {
                if (_EndTime != value)
                {
                    _EndTime = value;
                    RaisePropertyChange();
                }
            }
        }
    }
}
