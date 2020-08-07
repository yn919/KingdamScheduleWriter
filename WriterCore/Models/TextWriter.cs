using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace WriterCore.Models
{
    public class TextWriter
    {
        public event Action<string> CompleteWrite;

        private ObservableCollection<ScheduleData> Schedules;

        public TextWriter(ObservableCollection<ScheduleData> schedules)
        {
            this.Schedules = schedules;
        }

        public void Write()
        {
            if (Schedules.Count <= 0) return;

            string exportText = string.Empty;

            var firstData = Schedules[0];
            var month = $"{firstData.Date.Month}月の予定\r\n";
            exportText += month;

            foreach (var schedule in Schedules)
            {
                var scheduleText = $"{schedule.Date.ToString("M/d(ddd)", System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP"))} {schedule.Place} {schedule.Time}";
                exportText += $"{scheduleText}\r\n";
            }

            CompleteWrite?.Invoke(exportText);
        }
    }
}
