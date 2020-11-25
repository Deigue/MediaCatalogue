using MediaCatalogue.Components;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using MediaCatalogue.Interfaces;

namespace MediaCatalogue.ViewModels
{
    public class MenuItemViewModel : ViewModel
    {
        [Reactive] public IMenuItem MenuItem { get; set; }

        public ICommand? ClickCommand { get; }

        public MenuItemViewModel(IMenuItem menuItem, ICommand? clickCommand)
        {
            MenuItem = menuItem;
            ClickCommand = clickCommand;
        }
    }
}