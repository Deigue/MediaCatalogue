using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MediaCatalogue.Interfaces;

namespace MediaCatalogue.Models
{
    public class MenuItemModel : IMenuItem
    {
        public string Header { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string? ToolTip { get; set; }
        public SolidColorBrush? Foreground { get; set; }
        public SolidColorBrush? Background { get; set; }
        public Action? ClickAction { get; set; }
        public Lazy<ObservableCollection<IMenuItem>>? Children { get; set; }

        public MenuItemModel(string header)
        {
            Header = header;
        }

        public override string ToString()
        {
            return $"'{Header}' Menu Item";
        }
    }
}