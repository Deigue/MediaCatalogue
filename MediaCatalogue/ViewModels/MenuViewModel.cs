using System.Collections.Generic;
using MediaCatalogue.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using DynamicData;
using MediaCatalogue.Interfaces;
using MediaCatalogue.Models.Builders;
using MediaCatalogue.Models.Directors;

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
            MenuItems = SetupMenuItems();

            // TODO: Replace with SeriLog affirmation here.
            Debug.WriteLine("Setup menu items done!");
        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            MenuItemModels.Add(MenuDirector.MakeWithBuilder(new FileMenuItemBuilder()));

            var menuItems = new ObservableCollection<MenuItemViewModel>(MenuItemModels.AsEnumerable()
                .Select(ConvertToViewModelRecursively));
            
            return menuItems;
        }

        private MenuItemViewModel ConvertToViewModelRecursively(IMenuItem menuItemModel)
        {
            var menuCommand = this.GetMenuCommand(menuItemModel.Header);
            var menuItemViewModel = new MenuItemViewModel(menuItemModel, menuCommand);
            menuItemViewModel.Children.Value.AddRange(menuItemModel.Children.Value
                .Select(ConvertToViewModelRecursively));
            menuCommand?.DisposeWith(menuItemViewModel.CompositeDisposable);
            return menuItemViewModel;
        }
    }
}