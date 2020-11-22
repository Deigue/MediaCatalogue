using MediaCatalogue.Components;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using MediaCatalogue.Interfaces;
using MediaCatalogue.Models;

namespace MediaCatalogue.ViewModels
{
    public class MenuItemViewModel : ViewModel
    {
        [Reactive]
        public string Header { get; set; }

        public ICommand ClickCommand { get; }
        

        public ObservableCollection<MenuItemViewModel>? Children { get; set; }

        public SolidColorBrush Foreground { get; set; }

        public MenuItemViewModel(string header, ICommand clickCommand, ObservableCollection<MenuItemViewModel>? childs, SolidColorBrush foreground)
        {
            Header = header;
            ClickCommand = clickCommand;
            Foreground = foreground;
            
            Children = childs ?? new ObservableCollection<MenuItemViewModel>();


        }
    }
}
