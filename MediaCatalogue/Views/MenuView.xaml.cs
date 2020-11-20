using MediaCatalogue.ViewModels;
using ReactiveUI;
using MediaCatalogue.Components;

namespace MediaCatalogue.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : RxUserControl<MenuViewModel>
    {
        public MenuView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                // map menu stuff here.
            });
        }
    }
}
