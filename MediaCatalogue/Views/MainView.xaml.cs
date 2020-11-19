using MediaCatalogue.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;
using MediaCatalogue.Components;

namespace MediaCatalogue.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : RxUserControl<MainViewModel>
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