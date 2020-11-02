using MediaCatalogue.Components;
using MediaCatalogue.ViewModels;
using ReactiveUI;

namespace MediaCatalogue.Views
{
    public class MenuViewBase : RxUserControl<MainViewModel> { };

    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : MenuViewBase
    { 
        public MenuView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                //this.WhenAnyValue(x => x.Con)
            });
        }
    }
}
