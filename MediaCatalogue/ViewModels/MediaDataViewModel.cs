using System;
using System.Web.UI.WebControls;
using MediaCatalogue.Components;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MediaDataViewModel : ViewModel
    {
        private MainViewModel MainViewModel { get; }

        [Reactive] public MenuViewModel MainMenu { get; set; }

        [Reactive] public bool PathReadOnly { get; set; } = true;

        [Reactive] public string Path { get; set; }

        public MediaDataViewModel(MainViewModel mainViewModel, string path)
        {
            MainViewModel = mainViewModel;
            // TODO: Have this populate some default path using an externally saved configuration file.
            // TODO: SQLiteConnection connection based on this path. Will populate rest of potential information here.
            Path = path;
            MainMenu = new MenuViewModel(this);

        } 
    }
}