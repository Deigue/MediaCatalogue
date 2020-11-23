using MediaCatalogue.Models;

namespace MediaCatalogue.Interfaces
{
    public interface IMenuItemBuilder
    {
        void Enable();
        void SetToolTip();
        void SetForeground();
        void SetBackground();
        void SetupSubMenus();
        MenuItemModel Build();
    }
}