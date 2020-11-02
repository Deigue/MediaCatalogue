using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.Components
{
    public class RxUserControl<TViewModel> : ReactiveUserControl<TViewModel>
        where TViewModel : class
    {
    }
}
