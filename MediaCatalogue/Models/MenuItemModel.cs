using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace MediaCatalogue.Models
{
    public class MenuItemModel : ReactiveObject
    {
        [Reactive] public string Header { get; set; }
        [Reactive] public string ToolTip { get; set; }
        [Reactive] public ObservableCollection<MenuItemModel>? Children { get; set; }
        [Reactive] public bool ReadOnly { get; set; }

        public MenuItemModel(string header, string toolTip, bool readOnly)
        {
            Header = header;
            ToolTip = toolTip;
            ReadOnly = readOnly;
            Children = new ObservableCollection<MenuItemModel>();
        }

        public MenuItemModel(string header, string toolTip, bool readOnly, ObservableCollection<MenuItemModel> children)
        {
            Header = header;
            ToolTip = toolTip;
            ReadOnly = readOnly;
            Children = children;
        }
    }
}