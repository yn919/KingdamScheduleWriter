using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Linq;
using KingdamScheduleWriter.Models;

namespace KingdamScheduleWriter.ViewModels
{
    class MainViewModel : PropertyChangeObj, IDisposable
    {
        private MainModel InnerModel;

        public ReadOnlyReactiveCollection<ScheduleDataViewModel> Schedules { get; }

        public ReactiveCommand AddCommand { get; }
        public ReactiveCommand<ScheduleDataViewModel> RemoveCommand { get; }
        public ReactiveCommand ExportCommand { get; }

        public MainViewModel()
        {
            InnerModel = new MainModel();

            Schedules = InnerModel.Schedules.ToReadOnlyReactiveCollection(x => new ScheduleDataViewModel(x));

            AddCommand = new ReactiveCommand();
            AddCommand.Subscribe(() => InnerModel.AddSchedule());

            RemoveCommand = new ReactiveCommand<ScheduleDataViewModel>();
            RemoveCommand.Subscribe(x => InnerModel.RemoveSchedule(x.GetInnerModel()));

            ExportCommand = new ReactiveCommand();
            ExportCommand.Subscribe(() => InnerModel.Writer.Write());
        }

        public void Start()
        {
            InnerModel.Start();
        }

        public void End()
        {
            InnerModel.End();

            foreach(var schedule in Schedules)
            {
                schedule.Dispose();
            }

            Dispose();
        }

        public void Dispose()
        {
            AddCommand.Dispose();
            RemoveCommand.Dispose();
            ExportCommand.Dispose();
            Schedules.Dispose();
        }
    }
}
