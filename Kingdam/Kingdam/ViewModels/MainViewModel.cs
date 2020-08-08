using Kingdam.Views;
using Reactive.Bindings;
using System;
using WriterCore.Models;
using Xamarin.Essentials;
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
        public ReactiveCommand<ScheduleDataViewModel> ShowItemMenuCommand { get; }

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
                EditSchedulePage editPage = new EditSchedulePage();
                editPage.BindingContext = x;

                await Application.Current.MainPage.Navigation.PushModalAsync(editPage);
            });

            ShowItemMenuCommand = new ReactiveCommand<ScheduleDataViewModel>();
            ShowItemMenuCommand.Subscribe(async x =>
            {
                bool action = await Application.Current.MainPage.DisplayAlert(null, "削除しますか？", "はい", "いいえ");
                if (action == true)
                {
                    InnerModel.RemoveSchedule(x.GetInnerModel());
                }
            });
        }

        private async void Writer_CompleteWrite(string text)
        {
            await Share.RequestAsync(new ShareTextRequest()
            {
                Text = text
            });
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
            ShowItemMenuCommand.Dispose();
            Schedules.Dispose();
        }
    }
}
