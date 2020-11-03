using MediaCatalogue.Components;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    public class MenuItemViewModel : ViewModel
    {
        [Reactive]
        public string Header { get; set; }

        public MenuItemViewModel(string header)
        {
            Header = header;
            IObservable<string> headerObservable = this.WhenAnyValue(x => x.Header);
            //headerObservable.Subscribe()
        }
    }
}
