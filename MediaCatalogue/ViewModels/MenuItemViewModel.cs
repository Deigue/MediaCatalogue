using MediaCatalogue.Components;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaCatalogue.ViewModels
{
    public class MenuItemViewModel : ViewModel
    {
        [Reactive]
        public string Header { get; set; }

        public ICommand ClickCommand { get; }

        public MenuItemViewModel(string header, ICommand clickCommand)
        {
            Header = header;
            ClickCommand = clickCommand;
            //IObservable<string> headerObservable = this.WhenAnyValue(x => x.Header);
            //headerObservable.Subscribe()
        }
    }
}
