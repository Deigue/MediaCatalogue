using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    class MenuItemViewModel : ReactiveObject
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public MenuItemViewModel()
        {
            // initialize complex obj like collection/refs etc.

        }
    }
}
