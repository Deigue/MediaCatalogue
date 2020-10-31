using ControlzEx.Theming;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue.ViewModels
{
    class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            ClearPath = ReactiveCommand.Create(() => { Path = string.Empty; });
            //Path = ReactiveProep

           
        }

        public ReactiveCommand<Unit, Unit> ClearPath { get; }

        private string path = string.Empty;
        public string Path
        {
            get => path;
            set => this.RaiseAndSetIfChanged(ref path, value);
        }
    }
}
