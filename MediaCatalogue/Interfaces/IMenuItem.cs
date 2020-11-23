using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ControlzEx.Behaviors;

namespace MediaCatalogue.Interfaces
{
    public interface IMenuItem
    {
        string Header { get; set; }
        bool IsEnabled { get; set; }
        string? ToolTip { get; set; }
        SolidColorBrush? Foreground { get; set; }
        SolidColorBrush? Background { get; set; }
        Lazy<ObservableCollection<IMenuItem>>? Children { get; set; }
    }
}