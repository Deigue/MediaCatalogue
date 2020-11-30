using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MediaCatalogue.Interfaces;

namespace MediaCatalogue.Models
{
    public class MenuItemModel : IMenuItem, IComparable<MenuItemModel>, IComparable
    {
        public string Header { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string? ToolTip { get; set; }
        public SolidColorBrush? Foreground { get; set; }
        public SolidColorBrush? Background { get; set; }
        public Action? ClickAction { get; set; }
        public Lazy<ObservableCollection<IMenuItem>> Children { get; } = new Lazy<ObservableCollection<IMenuItem>>();

        public MenuItemModel(string header)
        {
            Header = header;
        }

        public override string ToString()
        {
            return $"'{Header}' Menu Item";
        }

        public int CompareTo(MenuItemModel? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var headerComparison = string.Compare(Header, other.Header, StringComparison.Ordinal);
            if (headerComparison != 0) return headerComparison;
            var isEnabledComparison = IsEnabled.CompareTo(other.IsEnabled);
            if (isEnabledComparison != 0) return isEnabledComparison;
            return string.Compare(ToolTip, other.ToolTip, StringComparison.Ordinal);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is MenuItemModel other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(MenuItemModel)}");
        }
    }
}