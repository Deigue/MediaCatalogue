using System.ComponentModel;
using MediaCatalogue.Models;

namespace MediaCatalogue.Interfaces
{
    public interface IMenuItemBuilder
    {
        void IsEnabled();
        void SetToolTip();
        void SetForeground();
        void SetBackground();
        void SetupSubMenus();
        IMenuItem Build();
    }
}