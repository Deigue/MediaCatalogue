using System;
using System.Collections.Generic;
using MediaCatalogue.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;
using MediaCatalogue.Interfaces;
using MediaCatalogue.Models;
using MediaCatalogue.Models.Builders;
using MediaCatalogue.Models.Directors;
using Microsoft.Win32;
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
            
            /* try 1
            var menuItems = new ObservableCollection<MenuItemViewModel>(MenuItemModels.AsEnumerable()
                .Select(menuItemModel =>
                    new MenuItemViewModel(menuItemModel, MediaMenuCommand.GetMenuCommand(menuItemModel.Header))));
            */
            
            // try 2
            var menuItems = new ObservableCollection<MenuItemViewModel>(MenuItemModels.AsEnumerable()
                .Select(menuItemModel =>
                {
                    var command = ReactiveCommand.Create(MediaMenuCommand.NewFileCommand());
                    command.ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe(path =>
                        {
                            MediaVm.Path = path;
                        });
                    return new MenuItemViewModel(menuItemModel, command);
                }));
            
            
            // try 3
            /*
            var menuItems = new ObservableCollection<MenuItemViewModel>(MenuItemModels.AsEnumerable()
                .Select(menuItemModel =>
                {
                    var command = ReactiveCommand.Create(() =>
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
                            DefaultDirectory = documentsPath,
                            Filters = {new CommonFileDialogFilter("SQLite Database", "*.db")}
                        };
                        try
                        {
                            if (saveDialog.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                Console.WriteLine(saveDialog.FileName);
                                MediaVm.Path = saveDialog.FileName;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    });
                    return new MenuItemViewModel(menuItemModel, command);
                }));
            */
            
                    
                        

            return menuItems;
        }
    }
}