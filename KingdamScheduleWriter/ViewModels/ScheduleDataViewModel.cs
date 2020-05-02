using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using KingdamScheduleWriter.Models;

namespace KingdamScheduleWriter.ViewModels
{
    class ScheduleDataViewModel : IDisposable
    {
        private ScheduleData InnerModel;
        public ScheduleData GetInnerModel() => InnerModel;

        public string[] Places = new string[]
        {
            "スポセン第1",
            "スポセン第2",
            "上納池"
        };

        public string[] Times = new string[]
        {
            "19-21",
            "17-19",
            "15-17",
            "13-15",
            "11-13",
            "9-11",
        };

        public ReactiveProperty<DateTime> Date { get; }
        public ReactiveProperty<string> Place { get; }
        public ReactiveProperty<string> Time { get; }

        public ScheduleDataViewModel(ScheduleData innerModel)
        {
            this.InnerModel = innerModel;

            Date = InnerModel.ToReactivePropertyAsSynchronized(x => x.Date);
            Place = InnerModel.ToReactivePropertyAsSynchronized(x => x.Place);
            Time = InnerModel.ToReactivePropertyAsSynchronized(x => x.Time);
        }

        public void Dispose()
        {
            Date.Dispose();
            Place.Dispose();
            Time.Dispose();
        }
    }
}
