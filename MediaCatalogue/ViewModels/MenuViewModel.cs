using System;
using System.Collections.Generic;
using MediaCatalogue.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using MediaCatalogue.Interfaces;
using MediaCatalogue.Models;
using MediaCatalogue.Models.Builders;
using MediaCatalogue.Models.Directors;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        private ISet<IMenuItem> MenuItemModels { get; set; } = new SortedSet<IMenuItem>();
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }
        public MediaDataViewModel MediaVm { get; }

        public MenuViewModel(MediaDataViewModel mediaVm)
        {
            MediaVm = mediaVm;

            // TODO: Link MenuItemModel to this ViewModel, and leverage those observable properties directly.
            MenuItems = SetupMenuItems();

            Debug.WriteLine("Setup menu items done!");
        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            MenuItemModels.Add(MenuDirector.MakeWithBuilder(new NewMenuItemBuilder()));

            var menuItems = new ObservableCollection<MenuItemViewModel>(MenuItemModels.AsEnumerable()
                .Select(menuItemModel =>
                    new MenuItemViewModel(menuItemModel, MediaMenuCommand.GetMenuCommand(menuItemModel.Header))));

            return menuItems;
        }
    }
}