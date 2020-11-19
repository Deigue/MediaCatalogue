using MediaCatalogue.Components;
using MediaCatalogue.Views;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainWindow MainWindow { get; }

        [Reactive] public ViewModel ActivePane { get; private set; }

        public MainViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            // TODO: SQLiteConnection connection from default configuration.

            var mediaDataViewModel = new MediaDataViewModel(this);
            NavigateToPane(mediaDataViewModel);
        }

        public void NavigateToPane(ViewModel viewModel)
        {
            ActivePane = viewModel;
        }
    }
}