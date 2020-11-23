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
        
        public MenuDirector(IMenuItemBuilder menuItemBuilder)
        {
            _builder = menuItemBuilder;
        }
        public void Construct()
        {
            _builder.Enable();
            _builder.SetToolTip();
            _builder.SetForeground();
            _builder.SetBackground();
            _builder.SetupSubMenus();
        }

        public IMenuItem GetMenuItem()
        {
            return _builder.Build();
        }
    }
}