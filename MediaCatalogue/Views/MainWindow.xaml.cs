using ControlzEx.Theming;
using MahApps.Metro.Controls;

namespace MediaCatalogue.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            // Use for changing theme in settings later.
            ThemeManager.Current.ChangeTheme(this, "Dark.Crimson");
            //GlowBrush.se = "Green";
        }
    }
}
