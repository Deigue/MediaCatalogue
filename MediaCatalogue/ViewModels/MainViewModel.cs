using MediaCatalogue.Components;
using MediaCatalogue.Views;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainWindow MainWindow { get; }

        [Reactive] public ViewModel? ActivePane { get; private set; }

        public MainViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;


            // TODO: Establish SQLite Database path from preset/default configuration and send it down to MediaDataViewModel.
            // Sending random empty path for now ...
            var mediaDataViewModel = new MediaDataViewModel(this, "<empty>");
            NavigateToPane(mediaDataViewModel);
        }

        public void NavigateToPane(ViewModel viewModel)
        {
            ActivePane = viewModel;
        }
    }
}