using MediaCatalogue.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
    public class MainViewBase : ReactiveUserControl<MainViewModel> { };

    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MainViewBase
    {
        public MainView()
        {
            InitializeComponent();
            this.WhenActivated(diposable =>
            {
                this.WhenAnyValue(view => view.ViewModel!.ActivePane)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .BindTo(this, view => view.ContentPane.Content);
            });
        }
    }
}
