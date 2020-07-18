using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WriterCore.Models
{
    public class MainModel
    {
        public ObservableCollection<ScheduleData> Schedules { get; set; }
        public TextWriter Writer;

        public MainModel()
        {
            Schedules = new ObservableCollection<ScheduleData>();
            Writer = new TextWriter(Schedules);
        }

        public void Start()
        {
            Schedules.Clear();

            Schedules.Add(new ScheduleData());
            Schedules.Add(new ScheduleData());
            Schedules.Add(new ScheduleData());
            Schedules.Add(new ScheduleData());
        }

        public void End()
        {

        }

        public void AddSchedule()
        {
            Schedules.Add(new ScheduleData());
        }

        public void RemoveSchedule(ScheduleData schedule)
        {
            if(Schedules.Contains(schedule))
            {
                Schedules.Remove(schedule);
            }
        }
    }
}
