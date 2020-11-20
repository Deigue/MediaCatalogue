using System.Reactive.Disposables;
using System.Reactive.Linq;
using MediaCatalogue.Components;
using MediaCatalogue.ViewModels;
using ReactiveUI;

namespace MediaCatalogue.Views
{
    public class MediaDataViewBase : RxUserControl<MediaDataViewModel>
    {
    }

    /// <summary>
    /// Interaction logic for MediaDataView.xaml
    /// </summary>
    public partial class MediaDataView : MediaDataViewBase
    {
        public MediaDataView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                // Setup the Main Menu.
                this.WhenAnyValue(view => view.ViewModel!.MainMenu)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .BindTo(this, view => view.MainMenu.DataContext)
                    .DisposeWith(disposable);

                // Path Related.
                this.OneWayBind(this.ViewModel, vm => vm.PathReadOnly, v => v.TextDbPath.IsReadOnly)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, vm => vm.Path, v => v.TextDbPath.Text)
                    .DisposeWith(disposable);
            });
        }
    }
}