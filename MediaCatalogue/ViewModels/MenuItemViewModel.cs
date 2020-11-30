using System;
using System.Collections.ObjectModel;
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

        public Lazy<ObservableCollection<MenuItemViewModel>> Children { get; } =
            new Lazy<ObservableCollection<MenuItemViewModel>>();

        public MenuItemViewModel(IMenuItem menuItem, ICommand? clickCommand)
        {
            MenuItem = menuItem;
            ClickCommand = clickCommand;
        }

        public override string ToString()
        {
            return MenuItem.ToString();
        }
    }
}