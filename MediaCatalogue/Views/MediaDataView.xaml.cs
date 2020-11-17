using System.Reactive.Disposables;
using MediaCatalogue.ViewModels;
using ReactiveUI;

namespace MediaCatalogue.Views
{
    public class MediaDataViewBase : ReactiveUserControl<MediaDataViewModel>
    {
    };

    /// <summary>
    /// Interaction logic for MediaDataView.xaml
    /// </summary>
    public partial class MediaDataView
    {
        public MediaDataView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.PathReadOnly, v => v.TextDbPath.IsReadOnly)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, vm => vm.Path, v => v.TextDbPath.Text)
                    .DisposeWith(disposable);
            });
        }
    }
}