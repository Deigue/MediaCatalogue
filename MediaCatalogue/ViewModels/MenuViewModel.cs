using MediaCatalogue.Components;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;

namespace MediaCatalogue.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ObservableCollection<MenuItemViewModel> MenuItems { get; }
        public ViewModel Parent { get; }

        public MenuViewModel(ViewModel parent)
        {
            Parent = parent;
            
            // TODO: Link MenuItemModel to this ViewModel, and leverage those observable properties directly.
            MenuItems = SetupMenuItems();
        }

        private ObservableCollection<MenuItemViewModel> SetupMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItemViewModel>();

            /*
            ReactiveCommand<Unit, MessageDialogResult> newFile = ReactiveCommand.CreateFromTask<MessageDialogResult>(() =>
            {
                return Application.Current.Windows.OfType<MetroWindow>().First(w => w.IsActive).ShowMessageAsync("New file", "make new file?",
                    MessageDialogStyle.AffirmativeAndNegative);
            });
            */


            var newFile = ReactiveCommand.Create(() =>
            {
                var saveDialog = new CommonSaveFileDialog();
                saveDialog.ShowDialog();
            });

            var fileMenu = new MenuItemViewModel("_File", newFile, null, new SolidColorBrush(Colors.Red));
            menuItems.Add(fileMenu);
            menuItems.Add(new MenuItemViewModel("_Settings", newFile,
                new ObservableCollection<MenuItemViewModel>(){fileMenu, fileMenu},
                new SolidColorBrush(Colors.DimGray)));

            return menuItems;
        }
    }
}