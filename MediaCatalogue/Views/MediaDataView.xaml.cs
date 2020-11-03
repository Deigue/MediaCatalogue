using MediaCatalogue.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaCatalogue.Views
{
    public class MediaDataViewBase : ReactiveUserControl<MediaDataViewModel> { };
    /// <summary>
    /// Interaction logic for MediaDataView.xaml
    /// </summary>
    public partial class MediaDataView : MediaDataViewBase
    {
        public MediaDataView()
        {
            InitializeComponent();
            
        }
    }
}
