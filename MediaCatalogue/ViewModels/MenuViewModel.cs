using MediaCatalogue.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ViewModel Parent { get; }
        public MenuViewModel(ViewModel parent)
        {
            Parent = parent;
        }
    }
}
