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
        public ViewModel Parent { get; }

        public MenuViewModel(ViewModel parent)
        {
            Parent = parent;

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
            
            // Short circuit old implementation for new replacement.
            /*
                var newFile = ReactiveCommand.Create(() =>
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var saveDialog = new CommonSaveFileDialog()
                {
                    Title = "Create Media Database File",
                    ShowHiddenItems = false,
                    AddToMostRecentlyUsedList = false,
                    ShowPlacesList = true,
                    CreatePrompt = false,
                    DefaultExtension = ".db",
                    DefaultFileName = "MediaCatalogue",
                    DefaultDirectory = documentsPath
                };
                try
                {
                    Console.WriteLine("About to open file dialog");
                    if (saveDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        Console.WriteLine(saveDialog.FileName);
                        return saveDialog.FileName;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return null;
            
            });

            var fileMenu = new MenuItemViewModel("_File", newFile, null, new SolidColorBrush(Colors.Red));

            ObservableCollection<MenuItemViewModel> menuItems = new ObservableCollection<MenuItemViewModel>();
            menuItems.Add(fileMenu);
            menuItems.Add(new MenuItemViewModel("_Settings", newFile,
                new ObservableCollection<MenuItemViewModel>(){fileMenu, fileMenu},
                new SolidColorBrush(Colors.BlueViolet)));
            */

            return menuItems;
        }
    }
}