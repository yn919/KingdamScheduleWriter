using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace KingdamScheduleWriter.Models
{
    public class TextWriter
    {
        private ObservableCollection<ScheduleData> Schedules;

        public TextWriter(ObservableCollection<ScheduleData> schedules)
        {
            this.Schedules = schedules;
        }

        public void Write()
        {
            if (Schedules.Count <= 0) return;

            using (StreamWriter sw = new StreamWriter(
                    Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "KingdamShedule.txt"),
                    true,
                    Encoding.UTF8))
            {
                var firstData = Schedules[0];
                var month = $"{firstData.Date.Month}月の予定";
                sw.WriteLine(month);

                foreach(var schedule in Schedules)
                {
                    var scheduleText = $"{schedule.Date.ToString("M/d(ddd)")} {schedule.Place} {schedule.Time}";
                    sw.WriteLine(scheduleText);
                }
            }
        }
    }
}
