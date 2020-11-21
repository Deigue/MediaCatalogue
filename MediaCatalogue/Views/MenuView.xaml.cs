using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;
using MediaCatalogue.ViewModels;
using ReactiveUI;
using MediaCatalogue.Components;

namespace MediaCatalogue.Views
{
    public class MenuViewBase : RxUserControl<MenuViewModel>
    {
    }

    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : MenuViewBase
    {
        public MenuView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.WhenAnyValue(view => view.ViewModel!.MenuItems)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .BindTo(this, view => view.MediaMenu.ItemsSource)
                    .DisposeWith(disposable);
                
            });
        }
    }
}