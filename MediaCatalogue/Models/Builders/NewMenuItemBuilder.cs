using System;
using System.IO;
using System.Windows.Media;
using MediaCatalogue.Interfaces;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MediaCatalogue.Models.Builders
{
    public class NewMenuItemBuilder : IMenuItemBuilder
    {
        private MenuItemModel _newMenuItem = new MenuItemModel("New");

        public void Enable()
        {
            _newMenuItem.IsEnabled = true;
        }

        public void SetToolTip()
        {
            _newMenuItem.ToolTip = "Create a new Media Database file.";
        }

        public void SetForeground()
        {
            _newMenuItem.Foreground = new SolidColorBrush(Colors.YellowGreen);
        }

        public void SetBackground()
        {
            _newMenuItem.Background = new SolidColorBrush(Colors.DarkOliveGreen);
        }

        public void SetupSubMenus()
        {
        }

        public void SetClickAction()
        {
            _newMenuItem.ClickAction = () =>
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
                saveDialog.ShowDialog();

                //return saveDialog.FileName;
            };
        }

        public MenuItemModel Build()
        {
            return _newMenuItem;
        }
    }
}