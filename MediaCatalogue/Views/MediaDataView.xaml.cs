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
        }
    }
}