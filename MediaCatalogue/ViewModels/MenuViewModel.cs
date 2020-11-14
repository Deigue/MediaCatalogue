using MediaCatalogue.Components;
using System.Collections.ObjectModel;

namespace MediaCatalogue.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }
        public ViewModel Parent { get; }
        public MenuViewModel(ViewModel parent)
        {
            Parent = parent;
        }
    }
}
