using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MediaCatalogue.Components;
using Microsoft.WindowsAPICodePack.Dialogs;
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
        [Reactive] public MenuViewModel MainMenu { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }

        [Reactive] public bool PathIsReadOnly { get; set; }

        public MediaDataViewModel(MainViewModel mainVM)
        {
            MainViewModel = mainVM;
            MenuItems = SetupMenuItems();
            PathIsReadOnly = true;
            MainMenu = new MenuViewModel(this);
        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItemViewModel>();

            /*
            ReactiveCommand<Unit, MessageDialogResult> newFile = ReactiveCommand.CreateFromTask<MessageDialogResult>(() =>
            {
                return Application.Current.Windows.OfType<MetroWindow>().First(w => w.IsActive).ShowMessageAsync("New file", "make new file?",
                    MessageDialogStyle.AffirmativeAndNegative);
            });
            */


            var newFile = ReactiveCommand.Create(() =>
            {
                var saveDialog = new CommonSaveFileDialog();
                saveDialog.ShowDialog();
            });

            var fileMenu = new MenuItemViewModel("_File", newFile);
            menuItems.Add(fileMenu);

            return menuItems;
        }
    }
}