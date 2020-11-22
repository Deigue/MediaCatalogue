using System.Windows.Media;
using MediaCatalogue.Interfaces;
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
                var saveDialog = new CommonSaveFileDialog();
                saveDialog.ShowDialog();
            };
        }

        public MenuItemModel Build()
        {
            return _newMenuItem;
        }
    }
}