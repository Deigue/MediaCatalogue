using System;
using MediaCatalogue.Components;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MediaDataViewModel : ViewModel
    {
        private MainViewModel MainViewModel { get; }

        [Reactive] private MenuViewModel MainMenu { get; set; }

        [Reactive] public bool PathReadOnly { get; set; } = true;

        [Reactive]
        public String Path { get; set; }

        public MediaDataViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            MainMenu = new MenuViewModel(this);
        }
    }
}