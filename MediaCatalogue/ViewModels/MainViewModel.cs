using MediaCatalogue.Components;
using MediaCatalogue.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;

namespace MediaCatalogue.ViewModels
{
    public class MainViewModel : ViewModel
    {

        public MainWindow MainWindow { get; }

        [Reactive]
        public ViewModel ActivePane { get; private set; }

        public ReactiveCommand<Unit, Unit> ClearPath { get; }

        private string path = string.Empty;
        public string Path
        {
            get => path;
            set => this.RaiseAndSetIfChanged(ref path, value);
        }

        public MainViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            //MenuItems = SetupMenuItems();

            ClearPath = ReactiveCommand.Create(() => { Path = string.Empty; });
            //Path = ReactiveProep
            //SQLiteConnection connection;

            var mediaDataViewModel = new MediaDataViewModel(this);
            NavigateToPane(mediaDataViewModel);
            //MenuItems = Observable.Create<MenuItemViewModel>()

        }

        public MainViewModel()
        {
        }

        public void NavigateToPane(ViewModel viewModel)
        {
            ActivePane = viewModel;
        }
    }
}
