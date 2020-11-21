using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Media;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.Models
{
    public class MenuItemModel
    {
        public string Header { get; set; }
        public bool IsEnabled { get; set; } = true;
        public SolidColorBrush? Foreground { get; set; } = default;
        public SolidColorBrush? Background { get; set; } = default;
        public string? ToolTip { get; set; } = null;
        public ObservableCollection<MenuItemModel>? Children { get; set; }
        
        public MenuItemModel(string header)
        {
            Header = header;
            Children = new ObservableCollection<MenuItemModel>();
        }

        public MenuItemModel(string header, string toolTip, ObservableCollection<MenuItemModel> children, bool isEnabled)
        {
            Header = header;
            ToolTip = toolTip;
            Children = children;
            IsEnabled = isEnabled;
        }
    }
}