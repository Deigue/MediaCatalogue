using MediaCatalogue.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;

namespace MediaCatalogue.Views
{
    public class MainViewBase : ReactiveUserControl<MainViewModel>
    {
    };

    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.WhenAnyValue(view => view.ViewModel!.ActivePane)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .BindTo(this, view => view.ContentPane.Content);
            });
        }
    }
}