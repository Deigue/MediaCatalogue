using MediaCatalogue.Components;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    class MediaDataViewModel : ViewModel
    {
        public MainViewModel MainViewModel { get; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }

        public MediaDataViewModel(MainViewModel mainVM)
        {
            MainViewModel = mainVM;
            MenuItems = SetupMenuItems();

        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItemViewModel>();
            var fileMenu = new MenuItemViewModel("_File");

            menuItems.Add(fileMenu);
            return menuItems;

        }
    }
}

