using MediaCatalogue.Interfaces;

namespace MediaCatalogue.Models.Directors
{
    public class MenuDirector
    {
        private readonly IMenuItemBuilder _builder;

        public static IMenuItem MakeWithBuilder(IMenuItemBuilder menuItemBuilder)
        {
            var director = new MenuDirector(menuItemBuilder);
            director.Construct();
            return director.GetMenuItem();
        }

        private MenuDirector(IMenuItemBuilder menuItemBuilder)
        {
            _builder = menuItemBuilder;
        }

        private void Construct()
        {
            _builder.IsEnabled();
            _builder.SetToolTip();
            _builder.SetForeground();
            _builder.SetBackground();
            _builder.SetupSubMenus();
        }

        private IMenuItem GetMenuItem()
        {
            return _builder.Build();
        }
    }
}