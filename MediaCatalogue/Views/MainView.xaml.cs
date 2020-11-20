using MediaCatalogue.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;
using MediaCatalogue.Components;

namespace MediaCatalogue.Views
{
    public class MainViewBase : RxUserControl<MainViewModel>
    {
    }

    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MainViewBase
    {
        public MainView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                // Active pane switching.
                this.WhenAnyValue(view => view.ViewModel!.ActivePane)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .BindTo(this, view => view.ContentPane.Content);
            });
        }
    }
}