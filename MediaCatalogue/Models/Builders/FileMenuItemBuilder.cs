using System.Windows.Media;
using MediaCatalogue.Interfaces;
using MediaCatalogue.Models.Directors;

namespace MediaCatalogue.Models.Builders
{
    public class FileMenuItemBuilder : IMenuItemBuilder
    {
        private readonly MenuItemModel _fileMenuItem;

        public FileMenuItemBuilder()
        {
            _fileMenuItem = new MenuItemModel("_File");
        }
        public void IsEnabled()
        {
            _fileMenuItem.IsEnabled = true;
        }

        public void SetToolTip()
        {
        }

        public void SetForeground()
        {
            _fileMenuItem.Foreground = new SolidColorBrush(Colors.White);
        }

        public void SetBackground()
        {
            _fileMenuItem.Background = new SolidColorBrush(Colors.Black);
        }

        public void SetupSubMenus()
        {
            _fileMenuItem.Children.Value.Add(MenuDirector.MakeWithBuilder(new NewMenuItemBuilder()));
        }

        public IMenuItem Build()
        {
            return _fileMenuItem;
        }
    }
}