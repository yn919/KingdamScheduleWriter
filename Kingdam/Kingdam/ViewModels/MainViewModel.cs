using Kingdam.Views;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;
using WriterCore.Models;
using Xamarin.Forms;

namespace Kingdam.ViewModels
{
    class MainViewModel : PropertyChangeObj, IDisposable
    {
        private MainModel InnerModel;

        public ReadOnlyReactiveCollection<ScheduleDataViewModel> Schedules { get; }

        public ReactiveCommand AddCommand { get; }
        public ReactiveCommand<ScheduleDataViewModel> RemoveCommand { get; }
        public ReactiveCommand ExportCommand { get; }
        public ReactiveCommand<ScheduleDataViewModel> SelectedItemCommand { get; }

        public MainViewModel()
        {
            InnerModel = new MainModel();
            InnerModel.Writer.CompleteWrite += Writer_CompleteWrite;

            Schedules = InnerModel.Schedules.ToReadOnlyReactiveCollection(x => new ScheduleDataViewModel(x));

            AddCommand = new ReactiveCommand();
            AddCommand.Subscribe(() => InnerModel.AddSchedule());

            RemoveCommand = new ReactiveCommand<ScheduleDataViewModel>();
            RemoveCommand.Subscribe(x => InnerModel.RemoveSchedule(x.GetInnerModel()));

            ExportCommand = new ReactiveCommand();
            ExportCommand.Subscribe(() => InnerModel.Writer.Write());

            SelectedItemCommand = new ReactiveCommand<ScheduleDataViewModel>();
            SelectedItemCommand.Subscribe(async x =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditSchedulePage());

                System.Diagnostics.Debug.WriteLine("open page");
            });
        }

        private void Writer_CompleteWrite(string text)
        {
            
        }

        public void Start()
        {
            InnerModel.Start();
        }

        public void End()
        {
            InnerModel.End();

            foreach (var schedule in Schedules)
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
            SelectedItemCommand.Dispose();
            Schedules.Dispose();
        }
    }
}
