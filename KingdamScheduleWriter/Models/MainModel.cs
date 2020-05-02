using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KingdamScheduleWriter.Models
{
    public class MainModel
    {
        public ObservableCollection<ScheduleData> Schedules { get; set; }

        public MainModel()
        {
            Schedules = new ObservableCollection<ScheduleData>();
        }

        public void Start()
        {

        }

        public void End()
        {

        }
    }
}
