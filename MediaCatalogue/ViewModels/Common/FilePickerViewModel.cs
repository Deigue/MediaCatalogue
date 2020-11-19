using System.Windows.Input;
using MediaCatalogue.Components;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;

namespace MediaCatalogue.ViewModels.Common
{
    // To be replacing as util VM for all places where file picker needs to be utilized.
    public class FilePickerViewModel : ViewModel
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