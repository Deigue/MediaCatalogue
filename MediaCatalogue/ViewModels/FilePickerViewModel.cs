using MediaCatalogue.Components;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaCatalogue.ViewModels
{
    // To be replacing as util VM for all places where file picker needs to be utilized.
    class FilePickerViewModel : ViewModel
    {
        public FilePickerViewModel()
        {
            
        }

        public ICommand ShowOpenFileDialog()
        {
            return ReactiveCommand.Create(() =>
            {
                CommonFileDialog openFileDialog = new CommonOpenFileDialog();
            });
        }

    }
}
