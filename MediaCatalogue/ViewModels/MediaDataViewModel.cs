using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MediaCatalogue.Components;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaCatalogue.ViewModels
{
    public class MediaDataViewModel : ViewModel
    {
        public MainViewModel MainViewModel { get; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }

        [Reactive]
        public bool PathIsReadOnly { get; set; }

        public MediaDataViewModel(MainViewModel mainVM)
        {
            MainViewModel = mainVM;
            MenuItems = SetupMenuItems();
            PathIsReadOnly = true;

        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItemViewModel>();

            ReactiveCommand<Unit, MessageDialogResult> newFile = ReactiveCommand.CreateFromTask<MessageDialogResult>(
                () =>
                {
                    return Application.Current.Windows.OfType<MetroWindow>().First(w => w.IsActive).ShowMessageAsync("New file", "make new file?",
                       MessageDialogStyle.AffirmativeAndNegative);
                });


            var fileMenu = new MenuItemViewModel("_File",newFile);
            menuItems.Add(fileMenu);

            return menuItems;
        }
    }
}

