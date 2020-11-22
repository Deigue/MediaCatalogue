using System;
using MediaCatalogue.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media;
using MediaCatalogue.Models;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }
        public ViewModel Parent { get; }

        public MenuViewModel(ViewModel parent)
        {
            Parent = parent;
            
            // TODO: Link MenuItemModel to this ViewModel, and leverage those observable properties directly.
            MenuItems = SetupMenuItems();

            Debug.WriteLine("setup menu items done");
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
            menuItems.Add(fileMenu);
            menuItems.Add(new MenuItemViewModel("_Settings", newFile,
                new ObservableCollection<MenuItemViewModel>(){fileMenu, fileMenu},
                new SolidColorBrush(Colors.BlueViolet)));

            return menuItems;
        }
    }
}