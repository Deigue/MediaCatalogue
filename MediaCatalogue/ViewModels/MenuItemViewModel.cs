using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    class MenuItemViewModel : ReactiveObject
    {
        [Reactive]
        public string Header { get; set; }

        public MenuItemViewModel()
        {
            IObservable<string> headerObservable = this.WhenAnyValue(x => x.Header);
        }
    }
}
