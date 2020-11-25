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
        private readonly MenuItemModel _newMenuItem;

        public NewMenuItemBuilder()
        {
            _newMenuItem = new MenuItemModel("_New");
        }

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

        public IMenuItem Build()
        {
            return _newMenuItem;
        }
    }
}